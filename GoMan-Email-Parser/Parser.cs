using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Email_Url_Parser.Model;
using Email_Url_Parser.Proxy;
using GoMan.Imap;
using MailKit;

namespace Email_Url_Parser
{
    public class Parser
    {
        public EmailUrlParserConfiguration Settings { get; set; }
        private EmailUrlParser _worker;
        public HashSet<ParsedUrl> ParsedUrls { get; set; }
        private int _activatedCount = 0;
        private int _processedCount = 0;
        public int ActivatedCount => _activatedCount;

        public event Action<object, ParsedUrl> ParsedLinkEvent;
        public event Action<object, string> ImapEvent;


        public Parser()
        {
            ParsedUrls = new HashSet<ParsedUrl>();
        }

        public async void Start()
        {

            if (_worker == null)
            {
                _worker = new EmailUrlParser(Settings);
                _worker.ParsedLinkEvent += WorkerOnParsedLinkEvent;
                _worker.Client.Disconnected += OnClientDisconnectedClient;
                _worker.Client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            }


            if (!_worker.Client.IsConnected || !_worker.Client.IsAuthenticated)
            {
                await ReconnectClient().ConfigureAwait(false);
            }
            ImapEvent?.Invoke(this, "Parsing");
            await _worker.Dowork(ProcessedCallback);

        }

        private void ProcessedCallback(bool done)
        {
            Interlocked.Increment(ref _processedCount);
            if(!done)
                ImapEvent?.Invoke(this, $"A: {_activatedCount}, P: {_processedCount}, T: {_worker.TotalUids}");
            else
                ImapEvent?.Invoke(this, "DONE!!!");
        }

        private async void OnClientDisconnectedClient(object sender, EventArgs e)
        {
            ImapEvent?.Invoke(this, "Disconnected");
            await ReconnectClient();
        }

        private async Task ReconnectClient()
        {
            if (!_worker.Client.IsConnected)
            {
                ImapEvent?.Invoke(this, "Connecting");
                await _worker.Client.ConnectAsync(_worker.EmailUrlParserConfiguration.GetUri());
                ImapEvent?.Invoke(this, "Connected");
            }

            _worker.Client.AuthenticationMechanisms.Remove("XOAUTH2");
            try
            {
                ImapEvent?.Invoke(this, "Authenticating");
                await _worker.Client.AuthenticateAsync(_worker.EmailUrlParserConfiguration.GetCredential());
                ImapEvent?.Invoke(this, "Authenticated");
            }
            catch
            {
                //
            }
        }   
        private void WorkerOnParsedLinkEvent(object sender, ParsedUrlEventArgs parsedUrlEventArgs)
        {
            var parsedUrl = new ParsedUrl
            {
                Url = parsedUrlEventArgs.ParsedUrl,
                Uid = parsedUrlEventArgs.UniqueId,
                Status = StatusType.Pending
            };

            parsedUrl.AddLog(LoggerTypes.Success, $"URL TO: {parsedUrlEventArgs.To}, FROM: {parsedUrlEventArgs.From}");
            ParsedUrls.Add(parsedUrl);
            OnParsedLinkEvent(this, parsedUrl);
            ActivateQueue.AddToQueue(parsedUrl, Callback);
        }

        private async void Callback(ParsedUrl parsedUrl)
        {
            if (!parsedUrl.Verified)
            {
                ActivateQueue.AddToQueue(parsedUrl, Callback);
                ProxyHandlerSingleton.Instance.IncreaseFailCounter(parsedUrl.Proxy);
            }
            else 
            {
                try
                {
                    try
                    {
                        if (!_worker.Client.IsConnected)
                            await _worker.Client.ConnectAsync(_worker.EmailUrlParserConfiguration.GetUri())
                                .ConfigureAwait(false);
                        if (!_worker.Client.IsAuthenticated)
                            await _worker.Client.AuthenticateAsync(_worker.EmailUrlParserConfiguration.GetCredential());
                        if (!_worker.Client.Inbox.IsOpen)
                            await _worker.Client.Inbox.OpenAsync(FolderAccess.ReadWrite);
                    }
                    catch (Exception e)
                    {
                        parsedUrl.AddLog(LoggerTypes.Exception, $"Marked Uid {parsedUrl.Uid} as seen", e);
                    }

                    Interlocked.Increment(ref _activatedCount);
                    await _worker.Client.Inbox.AddFlagsAsync(parsedUrl.Uid, MessageFlags.Seen, true);
                    parsedUrl.AddLog(LoggerTypes.Debug, $"Marked Uid {parsedUrl.Uid} as seen");
                    parsedUrl.Proxy = null;
                }
                catch (Exception e)
                {
                    parsedUrl.AddLog(LoggerTypes.Exception, $"Marked Uid {parsedUrl.Uid} as seen", e);
                }

            }
        }

        public async void Stop()
        {
            if(_worker == null) return;
            await _worker.Client.Inbox.CloseAsync();
            await _worker.Client.DisconnectAsync(true);
            _worker.ParsedLinkEvent -= WorkerOnParsedLinkEvent;
            _worker.ParsedLinkEvent -= WorkerOnParsedLinkEvent;
            _worker.Client.Disconnected -= OnClientDisconnectedClient;

        }

        protected virtual void OnParsedLinkEvent(object arg1, ParsedUrl arg2)
        {
            ParsedLinkEvent?.Invoke(arg1, arg2);
        }

        protected virtual void OnImapEvent(object arg1, string arg2)
        {
            ImapEvent?.Invoke(arg1, arg2);
        }
    }
}
