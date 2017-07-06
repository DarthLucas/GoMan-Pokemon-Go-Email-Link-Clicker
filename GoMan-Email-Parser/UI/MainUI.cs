using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Email_Url_Parser.Model;
using Email_Url_Parser.Proxy;
using GoMan.Imap;
using Newtonsoft.Json;
using ParsedUrl = Email_Url_Parser.Model.ParsedUrl;

namespace Email_Url_Parser.UI
{
    public partial class MainUi : Form
    {
        private static Dictionary<EmailUrlParserConfiguration, Parser> _parsers = new Dictionary<EmailUrlParserConfiguration, Parser>();
        private static Parser _currentParser;
        public MainUi()
        {
            InitializeComponent();
        }
        #region Proxy

        private void resetBanStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (GoProxy proxy in fastObjectListViewProxies.SelectedObjects)
            {
                ProxyHandlerSingleton.Instance.MarkOnCoolDown(proxy, false);
            }

            fastObjectListViewProxies.RefreshSelectedObjects();
        }
        private async void singleProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = Prompt.ShowDialog("Add proxy", "Proxy");

            if (String.IsNullOrEmpty(data))
            {
                return;
            }

            bool success = ProxyHandlerSingleton.Instance.AddProxy(data);

            if (!success)
            {
                MessageBox.Show("Invalid proxy format");
                return;
            }

            fastObjectListViewProxies.SetObjects(ProxyHandlerSingleton.Instance.Proxies);

            var returnTask = new List<Task>();
            lock (ProxyHandlerSingleton.Instance.Proxies)
            {
                foreach (var instanceProxy in ProxyHandlerSingleton.Instance.Proxies)
                {
                    returnTask.Add(ProxyHandlerSingleton.Instance.TestProxy(instanceProxy));
                }
            }

            await Task.WhenAll(returnTask);
        }
        private async void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = String.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Open proxy file";
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
            }

            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }

            try
            {
                string[] proxyData = File.ReadAllLines(fileName);

                int count = 0;

                foreach (string pData in proxyData)
                {
                    if (ProxyHandlerSingleton.Instance.AddProxy(pData))
                    {
                        ++count;
                    }
                }

                fastObjectListViewProxies.SetObjects(ProxyHandlerSingleton.Instance.Proxies);
                var returnTask = new List<Task>();
                lock (ProxyHandlerSingleton.Instance.Proxies)
                {
                    foreach (var instanceProxy in ProxyHandlerSingleton.Instance.Proxies)
                    {
                        returnTask.Add(ProxyHandlerSingleton.Instance.TestProxy(instanceProxy));
                    }
                }


                MessageBox.Show(String.Format("Imported {0} proxies", count), "Info");
                await Task.WhenAll(returnTask);


            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Failed to import proxy file. Ex: {0}", ex.Message), "Exception occured");
            }
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int count = fastObjectListViewProxies.SelectedObjects.Count;

            if (count == 0)
            {
                return;
            }

            DialogResult result = MessageBox.Show(String.Format("Are you sure you want to delete {0} proxies?", count), "Confirmation", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
            {
                return;
            }


            bool messageShown = false;

            foreach (GoProxy proxy in fastObjectListViewProxies.SelectedObjects)
            {
                if (proxy.CurrentCreations > 0)
                {
                    if (!messageShown)
                    {
                        messageShown = true;

                        MessageBox.Show("Only proxies with 0 accounts tied to them will be removed", "Information");
                    }

                    continue;
                }

                ProxyHandlerSingleton.Instance.RemoveProxy(proxy);
            }

            fastObjectListViewProxies.SetObjects(ProxyHandlerSingleton.Instance.Proxies);
        }
        private void maxConcurrentFailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = Prompt.ShowDialog("Max concurrent fails", "Set fails", "5");

            if (String.IsNullOrEmpty(data))
            {
                return;
            }

            int value = 0;

            if (!Int32.TryParse(data, out value) || value <= 0)
            {
                MessageBox.Show("Invalid value", "Warning");
                return;
            }

            foreach (GoProxy proxy in fastObjectListViewProxies.SelectedObjects)
            {
                proxy.MaxConcurrentFails = value;
            }

            fastObjectListViewProxies.RefreshSelectedObjects();
        }
        private void clearFailuresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (GoProxy proxy in fastObjectListViewProxies.SelectedObjects)
            {
                proxy.ClearFailCounter();
            }

            fastObjectListViewProxies.RefreshSelectedObjects();
        }
        private void clearUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (GoProxy proxy in fastObjectListViewProxies.SelectedObjects)
            {
                proxy.ClearUsageCounter();
            }

            fastObjectListViewProxies.RefreshSelectedObjects();
        }
        private void coolDownTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = Prompt.ShowDialog("Cool down timer", "Set cool down", "20");

            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            int value = 0;

            if (!Int32.TryParse(data, out value) || value < 0)
            {
                MessageBox.Show("Invalid value", "Warning");
                return;
            }

            foreach (GoProxy proxy in fastObjectListViewProxies.SelectedObjects)
            {
                proxy.CoolDownMinutes = value;
            }

            fastObjectListViewProxies.RefreshSelectedObjects();
        }
        private void maxAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = Prompt.ShowDialog("Max Accounts", "Set Accounts", "5");

            if (String.IsNullOrEmpty(data))
            {
                return;
            }

            int value = 0;

            if (!Int32.TryParse(data, out value) || value <= 0)
            {
                MessageBox.Show("Invalid value", "Warning");
                return;
            }

            foreach (GoProxy proxy in fastObjectListViewProxies.SelectedObjects)
            {
                proxy.MaxCreations = value;
            }

            fastObjectListViewProxies.RefreshSelectedObjects();
        }
        private void fastObjectListViewProxies_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            GoProxy proxy = (GoProxy)e.Model;

            if (e.Column == olvColumnCurrentFails)
            {
                if (proxy.CurrentConcurrentFails == 0)
                {
                    e.SubItem.ForeColor = Color.Green;
                }
                else if (proxy.CurrentConcurrentFails > 0)
                {
                    e.SubItem.ForeColor = Color.Yellow;
                }
                else if (proxy.CurrentConcurrentFails >= proxy.MaxConcurrentFails)
                {
                    e.SubItem.ForeColor = Color.Red;
                }
            }
            else if (e.Column == olvColumnTimeOut)
            {
                e.SubItem.ForeColor = proxy.CoolDownTimer.IsRunning ? Color.Red : Color.Green;
            }
            else if (e.Column == olvColumnUsageCount)
            {
                if (proxy.CurrentCreations == 0)
                {
                    e.SubItem.ForeColor = Color.Green;
                }
                else if (proxy.CurrentCreations <= proxy.MaxCreations)
                {
                    e.SubItem.ForeColor = Color.Yellow;
                }
                else
                {
                    e.SubItem.ForeColor = Color.Red;
                }
            }
            else if (e.Column == olvColumnStatu)
            {
                e.SubItem.ForeColor = proxy.GetStatusColor();
            }
        }

        #endregion
        #region UrlView

        private void fastObjectListViewUrl_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            var parsedUrl = (ParsedUrl)e.Model;
            if (parsedUrl == null) return;

            if (e.Column == olvColumnStatus)
            {
                e.SubItem.ForeColor = parsedUrl.GetStatusColor();
            }
            else if (e.Column == olvColumnLastLog)
            {
                LogModel log = parsedUrl.EventLog.LastOrDefault();

                if (log == null)
                {
                    return;
                }

                e.SubItem.ForeColor = log.GetLogColor();
            }
           // else if (e.Column == olvColumnProxyToString)
           // {
           //     e.SubItem.Text = parsedUrl.ProxyToString;
           // }
        }

        #endregion
        #region Treeview
        private void treeViewEmails_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeViewEmails.SelectedNode == null) return;
            if (_currentParser != null)
            {
                _currentParser.ParsedLinkEvent -= CurrentParserOnParsedLinkEvent;
                _currentParser = null;
            }

            var settings = (EmailUrlParserConfiguration) treeViewEmails.SelectedNode.Tag;
            fastObjectListViewUrl.ClearObjects();
        }
        private void treeViewEmails_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewEmails.SelectedNode == null) return;
            var settings = (EmailUrlParserConfiguration)treeViewEmails.SelectedNode.Tag;
            _currentParser = _parsers[settings];
            _currentParser.ParsedLinkEvent += CurrentParserOnParsedLinkEvent;
            fastObjectListViewUrl.SetObjects(_currentParser.ParsedUrls);
            tabPageSelectedNodeUrls.Text = settings.Username + " URLS";
        }
        
        private void CurrentParserOnParsedLinkEvent(object o, ParsedUrl url)
        {
            fastObjectListViewUrl.AddObject(url);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addEditDialog = new AddEditForm();
            addEditDialog.ShowDialog(this);
            if (addEditDialog.DialogResult == DialogResult.OK && addEditDialog.Settings != null)
            {
                AddParser(addEditDialog.Settings);
            }
            addEditDialog.Dispose();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (treeViewEmails.SelectedNode == null) return;

            EditSetting((EmailUrlParserConfiguration)treeViewEmails.SelectedNode.Tag);
        }

        private void EditSetting(EmailUrlParserConfiguration settings)
        {
            var addEditDialog = new AddEditForm(settings);
            addEditDialog.ShowDialog(this);
            if (addEditDialog.DialogResult == DialogResult.OK && addEditDialog.Settings != null)
            {
                RemoveParser(settings);
                AddParser(addEditDialog.Settings);
            }
            addEditDialog.Dispose();
        }
        private void RemoveParser(EmailUrlParserConfiguration settings)
        {
            var parser = _parsers[settings];
            parser.Stop();
            parser.ImapEvent -= ParserOnImapEvent;
            _parsers.Remove(settings);
            var nodeToRemove = treeViewEmails.Nodes.Find(settings.Username, false).First();
            treeViewEmails.Nodes.Remove(nodeToRemove);
        }
        private void AddParser(EmailUrlParserConfiguration settings)
        {
            if (_parsers.ContainsKey(settings)) return;
            Parser parser;

            parser = settings.IsPath ? new ListParser() {Settings = settings} : new Parser() { Settings = settings };

            parser.ImapEvent += ParserOnImapEvent;
            _parsers.Add(settings, parser);
            var newNode = new TreeNode(settings.Username) { Tag = settings , Name = settings.Username};
            treeViewEmails.Nodes.Add(newNode);
        }
        delegate void UpdateTreeNode(object o, string text);
        private void ParserOnImapEvent(object o, string s)
        {
            var parser = (Parser) o;
            if (parser == null) return;
            var nodeToChange = treeViewEmails.Nodes.Find(parser.Settings.Username, false).First();

            if (treeViewEmails.InvokeRequired)
            {
                UpdateTreeNode d = new UpdateTreeNode(ParserOnImapEvent);
                this.Invoke(d, new object[] { o, s });
            }
            else
            {
                nodeToChange.Text = parser.Settings.Username + " - " + s;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (treeViewEmails.SelectedNode == null) return;
            RemoveParser((EmailUrlParserConfiguration)treeViewEmails.SelectedNode.Tag);
        }
        private void buttonStartSelected_Click(object sender, EventArgs e)
        {
            if (treeViewEmails.SelectedNode == null) return;
            _parsers[(EmailUrlParserConfiguration)treeViewEmails.SelectedNode.Tag].Start();
        }
        #endregion
        private void timerUrlRefresher_Tick(object sender, EventArgs e)
        {
            activatingLabel.Text = $"Activating: {StatsCollector.ActivatingCount}";
            activatedLabel.Text = $"Activated: {StatsCollector.ActivatedCount}";
            pendingLabel.Text = $"Pending: {StatsCollector.PendingCount}";
            failedLabel.Text = $"Failed: {StatsCollector.FailedCount}";

            if (_currentParser != null && _currentParser.ParsedUrls.Count > 0)
                fastObjectListViewUrl.RefreshObject(_currentParser.ParsedUrls.First());

            if(ProxyHandlerSingleton.Instance.Proxies.Count > 0)
                fastObjectListViewProxies.RefreshObject(ProxyHandlerSingleton.Instance.Proxies.First());
        }
        private void fastObjectListViewUrl_DoubleClick(object sender, EventArgs e)
        {
            if (fastObjectListViewUrl.SelectedObjects.Count == 0) return;

            ParsedUrl parsedUrl = (ParsedUrl)fastObjectListViewUrl.SelectedObjects[0];
            using (var logDialog = new LogForm(parsedUrl))
            {
                logDialog.ShowDialog(this);
            }
        }

        private string _proxySaveLocation { get; set; } = "SavedProxies.json";
        private string _accountSaveLocation { get; set; } = "SavedAccounts.json";

        private async void MainUi_Load(object sender, EventArgs e)
        {

            fastObjectListViewUrl.PrimarySortColumn = olvColumnStatus;
            fastObjectListViewUrl.PrimarySortOrder = SortOrder.Ascending;

            try
            {
                if (File.Exists(_proxySaveLocation))
                {
                    HashSet<GoProxy> LoadedProxies;
                    using (var sr = new StreamReader(_proxySaveLocation))
                    {
                        LoadedProxies = JsonConvert.DeserializeObject<HashSet<GoProxy>>(await sr.ReadToEndAsync());
                    }

                    ProxyHandlerSingleton.Instance.AddProxy(LoadedProxies);
                }
            }
            catch 
            {
               //ignore
            }

            try
            {
                if (File.Exists(_accountSaveLocation))
            {
                List<EmailUrlParserConfiguration> LoadedAccounts;
                using (var sr = new StreamReader(_accountSaveLocation))
                {
                    LoadedAccounts =
                        JsonConvert.DeserializeObject<List<EmailUrlParserConfiguration>>(await sr.ReadToEndAsync());
                }
                foreach (var emailUrlParserConfiguration in LoadedAccounts)
                {
                    AddParser(emailUrlParserConfiguration);
                }
            }
            }
            catch 
            {
                //ignore
            }
            ProxyHandlerSingleton.Instance.AddProxy("127.0.0.1:8000:default:dontdelete");
            fastObjectListViewProxies.SetObjects(ProxyHandlerSingleton.Instance.Proxies.ToList());

            var returnTask = new List<Task>();
            lock (ProxyHandlerSingleton.Instance.Proxies)
            {
                foreach (var instanceProxy in ProxyHandlerSingleton.Instance.Proxies)
                {
                    returnTask.Add(ProxyHandlerSingleton.Instance.TestProxy(instanceProxy));
                }
            }

            await Task.WhenAll(returnTask);


            ActivateQueue.Start();
        }

        private async void MainUi_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var sw = new StreamWriter(_proxySaveLocation))
            {
                await sw.WriteLineAsync(JsonConvert.SerializeObject(ProxyHandlerSingleton.Instance.Proxies));
            }
            using (var sw = new StreamWriter(_accountSaveLocation))
            {
                await sw.WriteLineAsync(JsonConvert.SerializeObject(_parsers.Keys.ToList()));
            }
        }

        private void toolStripStatusLabelAccountCreator_Click(object sender, EventArgs e)
        {
            Process.Start("https://goman.io/product/goman-account-creator-beta/");
        }
        private void toolStripStatusLabelDonate_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/GoMan/");
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://goman.io");
        }

        private void toolStripStatusLabelDiscord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/2ZBB53e");
        }

        private void numericUpDownMaxthreads_ValueChanged(object sender, EventArgs e)
        {
            StatsCollector.Maxthreads = (int) numericUpDownMaxthreads.Value;
        }
    }
}
