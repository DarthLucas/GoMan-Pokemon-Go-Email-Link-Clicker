using System;
using System.Net;

namespace GoMan.Imap
{
    public class EmailUrlParserConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSsl { get; set; }
        public string ServerHostName { get; set; }
        public int Port { get; set; }

        public EmailUrlParserConfiguration(string username, string password, bool isSsl, string serverHostName, int? port)
        {
            Username = username;
            Password = password;
            IsSsl = isSsl;
            ServerHostName = serverHostName;
            if (port == null) port = 993;

            Port = (int) port;
        }
        public EmailUrlParserConfiguration()
        {
        }
        public NetworkCredential GetCredential()
        {
            return new NetworkCredential(Username, Password);
        }

        public Uri GetUri()
        {
            var protocol = IsSsl ? "imaps" : "imap";
            var url = !string.IsNullOrEmpty(Port.ToString()) ? $"{protocol}://{ServerHostName}:{Port}" : $"{protocol}://{ServerHostName}";
            return new Uri(url);
        }

    }
}
