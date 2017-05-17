using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Email_Url_Parser.Proxy;
using MailKit;

namespace Email_Url_Parser.Model
{
    public enum StatusType { Null, Pending, Activating, Activated, Failed};

    public class ParsedUrl
    {
        public string Url { get; set; }
        public UniqueId Uid { get; set; }
        public bool Verified { get; set; } = false;
        public string LastLog { get; set; }
        public GoProxy Proxy { get; set; }
        public delegate void LogAdded(LogModel log);

        public event LogAdded EventLogAdded;
        private StatusType _status = StatusType.Null;
        public StatusType Status
        {
            get
            {
                return _status;
            }
            set
            {
                StatsCollector.UpdateCount(_status, value);
                _status = value;
            }
        }

        public List<LogModel> EventLog = new List<LogModel>();

        public void AddLog(LoggerTypes type, string message, Exception exception = null)
        {
            LogModel newLog = new LogModel(type, message, exception);
            EventLog.Add(newLog);
            this.LastLog = newLog.ToString();
            OnEventLogAdded(newLog);
        }
        protected virtual void OnEventLogAdded(LogModel log)
        {
            EventLogAdded?.Invoke(log);
        }
        public Color GetStatusColor()
        {
            switch (Status)
            {
                case StatusType.Activating:
                    return Color.Green;
                case StatusType.Failed:
                    return Color.Yellow;
                case StatusType.Pending:
                    return Color.LightGreen;
                case StatusType.Activated:
                    return Color.DodgerBlue;
            }

            return SystemColors.WindowText;
        }

        public string ProxyToString => Proxy?.ToString() ?? "";
    }
}
