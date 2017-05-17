using System;
using MailKit;

namespace GoMan.Imap
{

    public class ParsedUrlEventArgs : EventArgs
    {
        public string ParsedUrl { get; }
        public UniqueId UniqueId { get; }
        public string From { get; }
        public string To { get; }

        public ParsedUrlEventArgs(UniqueId uniqueId, string parsedUrl, string from, string to)
        {
            UniqueId = uniqueId;
            ParsedUrl = parsedUrl;
            From = from;
            To = to;
        }
    }
}
