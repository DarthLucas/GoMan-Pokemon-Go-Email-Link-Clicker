using System;
using System.Drawing;
using System.Windows.Forms;
using Email_Url_Parser.Model;

namespace Email_Url_Parser.UI
{
    public partial class LogForm : Form
    {
        private readonly ParsedUrl _parsedUrl;
        public LogForm(ParsedUrl account)
        {
            this._parsedUrl = account;
            InitializeComponent();
            this._parsedUrl.EventLogAdded += EventLogAdded;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            objectListView1.BackColor = Color.FromArgb(43, 43, 43);
            objectListView1.ForeColor = Color.LightGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void EventLogAdded(LogModel log)
        {
            objectListView1.AddObject(log);
        }

        private void objectListView1_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            LogModel log = (LogModel)e.Model;

             if (e.Column == olvMessage)
                {

                if (log == null)
                {
                    return;
                }

                e.SubItem.ForeColor = log.GetLogColor();
            }

        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            objectListView1.SetObjects(_parsedUrl.EventLog);
        }
        private void LogForm_Closing(object sender, EventArgs e)
        {
            this._parsedUrl.EventLogAdded -= EventLogAdded;
        }
    }
}
