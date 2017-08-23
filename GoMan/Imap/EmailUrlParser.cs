using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;

namespace GoMan.Imap
{
    public class EmailUrlParser
    {
        public readonly ImapClient Client = new ImapClient();
        public int TotalUids { get; set; }
        public EmailUrlParserConfiguration EmailUrlParserConfiguration { get; set; }

        private static readonly Regex _reg = new Regex("https://club.pokemon.com/.*/pokemon-trainer-club/activated/\\w+",
            RegexOptions.IgnoreCase);
        public event Action<object, ParsedUrlEventArgs> ParsedLinkEvent;

        public EmailUrlParser(EmailUrlParserConfiguration emailUrlParserConfiguration)
        {
            EmailUrlParserConfiguration = emailUrlParserConfiguration;
        }

        public async Task Dowork(Action<bool> callback)
        {
            await Client.Inbox.OpenAsync(FolderAccess.ReadWrite);
            var query = SearchQuery.NotSeen;//.And(SearchQuery.FromContains("noreply@pokemon.com")); //.And(SearchQuery.SubjectContains("Pokémon Trainer Club Activation").Or(SearchQuery.SubjectContains("Your account needs to be re-activated")));
            var uids = await Client.Inbox.SearchAsync(query);
            TotalUids = uids.Count;

            callback(false);

            foreach (var uid in uids)
            {
                try
                {
                    await Client.Inbox.GetMessageAsync(uid).ContinueWith(msg =>
                    {
                        if (msg.IsFaulted || msg.IsCanceled) return;
  
                        if (msg.Result.HtmlBody == null) return;
                        var matches = _reg.Matches(msg.Result.HtmlBody);
                        if (matches.Count == 0) return;
                        var url = matches[0].Value;

                        var clickedUrls = url;

                        var parsedUrlEventArgs = new ParsedUrlEventArgs(uid, clickedUrls, msg.Result.From.ToString(), msg.Result.To.ToString());
                        OnLinksParsed(this, parsedUrlEventArgs);

                    });
                    await Task.Delay(500);

                }
                catch (Exception ex)
                {
                    if (!Client.IsConnected)
                        await Client.ConnectAsync(EmailUrlParserConfiguration.GetUri())
                            .ConfigureAwait(false);
                    if (!Client.IsAuthenticated) 
                           await Client.AuthenticateAsync(EmailUrlParserConfiguration.GetCredential());
                    if (!Client.Inbox.IsOpen)
                        await Client.Inbox.OpenAsync(FolderAccess.ReadWrite);

                }
                callback(false);
            }

            callback(true);
            await Client.Inbox.CloseAsync(true);
        }

        protected virtual void OnLinksParsed(object arg1, ParsedUrlEventArgs arg2)
        {
            ParsedLinkEvent?.Invoke(arg1, arg2);
        }

        public async void SetConfiguration(EmailUrlParserConfiguration emailUrlParserConfiguration)
        {
            EmailUrlParserConfiguration = emailUrlParserConfiguration;

            if (Client.IsConnected && Client.IsAuthenticated)
            {
                await Client.DisconnectAsync(true);
            }
        }
    }
}
