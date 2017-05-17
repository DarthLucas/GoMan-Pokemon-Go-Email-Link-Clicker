using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;

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
            var query = SearchQuery.NotSeen.And(SearchQuery.SubjectContains("Trainer Club Activation"));
            var uids = await Client.Inbox.SearchAsync(query);
            TotalUids = uids.Count;

            callback(false);

            foreach (var uid in uids)
            {
                try
                {
                    var message = await Client.Inbox.GetMessageAsync(uid);
                    if (message.HtmlBody == null) continue;
                    var matches = _reg.Matches(message.HtmlBody);
                    if (matches.Count == 0) continue;
                    var url = matches[0].Value;

                    var clickedUrls = url;

                    var parsedUrlEventArgs = new ParsedUrlEventArgs(uid, clickedUrls, message.From.ToString(), message.To.ToString());
                    OnLinksParsed(this, parsedUrlEventArgs);
                    await Task.Delay(600);
 
                }
                catch (Exception ex)
                {
                    //if (ex.Message.Equals("The ImapClient is not authenticated."))
                    //    await Client.AuthenticateAsync(EmailUrlParserConfiguration.GetCredential());
                    Debug.WriteLine(ex.Message);
                }
                callback(false);
            }

            callback(true);
            await Client.Inbox.CloseAsync(false);
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