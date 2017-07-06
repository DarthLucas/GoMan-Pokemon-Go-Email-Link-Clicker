using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Email_Url_Parser.Model;
using Email_Url_Parser.Proxy;
using MailKit;

namespace Email_Url_Parser
{
    public class ListParser : Parser
    {
        private int _total;
        public new event Action<object, string> ImapEvent;
        private static readonly Regex _reg = new Regex("https://club.pokemon.com/.*/pokemon-trainer-club/activated/\\w+",
            RegexOptions.IgnoreCase);

        public override void Start()
        {
            var fileContent = "";
            using (var sr = new StreamReader(Settings.Path))
            {
                fileContent = sr.ReadToEnd();
            }
                var matches = _reg.Matches(fileContent);
            if (matches.Count == 0) return;
            _total = _total + matches.Count;
            ImapEvent?.Invoke(this, $"A: {_activatedCount}, P: {_processedCount}, T: {_total}");
            foreach (Match match in matches)
            {
                var url = match.Value;
                var parsedUrl = new ParsedUrl
                {
                    Url = url,
                    Status = StatusType.Pending
                };
                Interlocked.Increment(ref _processedCount);
                parsedUrl.AddLog(LoggerTypes.Success, $"Added url {url}");
                ParsedUrls.Add(parsedUrl);
                OnParsedLinkEvent(this, parsedUrl);
                ActivateQueue.AddToQueue(parsedUrl, Callback);
            }
            ImapEvent?.Invoke(this, $"A: {_activatedCount}, P: {_processedCount}, T: {_total}");
        }

        private void Callback(ParsedUrl parsedUrl)
        {
            if (!parsedUrl.Verified)
            {
                ActivateQueue.AddToQueue(parsedUrl, Callback);
                ProxyHandlerSingleton.Instance.IncreaseFailCounter(parsedUrl.Proxy);
            }
            else
            {
                Interlocked.Increment(ref _activatedCount);
                parsedUrl.AddLog(LoggerTypes.Debug, $"{parsedUrl.Url} was verified");
            }
        }

        protected override void OnImapEvent(object arg1, string arg2)
        {
            ImapEvent?.Invoke(arg1, arg2);
        }
    }
}
