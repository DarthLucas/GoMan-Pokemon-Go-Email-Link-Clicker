using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Email_Url_Parser.UI
{
    partial class MainUi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fastObjectListViewProxies = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnProxyIP = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnGoodProxy = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnProxyPort = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnProxyAuth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTimeOut = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnUsageCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCurrentFails = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStripProxy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxConcurrentFailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coolDownTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCoolDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearUsageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFailuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelListview = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSelectedNodeUrls = new System.Windows.Forms.TabPage();
            this.fastObjectListViewUrl = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumnStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnUrl = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnProxyToString = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLastLog = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabPageProxy = new System.Windows.Forms.TabPage();
            this.panelTreeview = new System.Windows.Forms.Panel();
            this.tableLayoutPanelTreeView = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewEmails = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelTreeViewControls = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonStartSelected = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.timerUrlRefresher = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.activatingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pendingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.activatedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.failedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDiscord = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDonate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAccountCreator = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCheapProxy = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewProxies)).BeginInit();
            this.contextMenuStripProxy.SuspendLayout();
            this.panelListview.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageSelectedNodeUrls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewUrl)).BeginInit();
            this.tabPageProxy.SuspendLayout();
            this.panelTreeview.SuspendLayout();
            this.tableLayoutPanelTreeView.SuspendLayout();
            this.tableLayoutPanelTreeViewControls.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fastObjectListViewProxies
            // 
            this.fastObjectListViewProxies.AllColumns.Add(this.olvColumnProxyIP);
            this.fastObjectListViewProxies.AllColumns.Add(this.olvColumnGoodProxy);
            this.fastObjectListViewProxies.AllColumns.Add(this.olvColumnProxyPort);
            this.fastObjectListViewProxies.AllColumns.Add(this.olvColumnProxyAuth);
            this.fastObjectListViewProxies.AllColumns.Add(this.olvColumnTimeOut);
            this.fastObjectListViewProxies.AllColumns.Add(this.olvColumnUsageCount);
            this.fastObjectListViewProxies.AllColumns.Add(this.olvColumnCurrentFails);
            this.fastObjectListViewProxies.AllowColumnReorder = true;
            this.fastObjectListViewProxies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjectListViewProxies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnProxyIP,
            this.olvColumnGoodProxy,
            this.olvColumnProxyPort,
            this.olvColumnProxyAuth,
            this.olvColumnTimeOut,
            this.olvColumnUsageCount,
            this.olvColumnCurrentFails});
            this.fastObjectListViewProxies.ContextMenuStrip = this.contextMenuStripProxy;
            this.fastObjectListViewProxies.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListViewProxies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListViewProxies.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjectListViewProxies.FullRowSelect = true;
            this.fastObjectListViewProxies.Location = new System.Drawing.Point(3, 3);
            this.fastObjectListViewProxies.Margin = new System.Windows.Forms.Padding(2);
            this.fastObjectListViewProxies.Name = "fastObjectListViewProxies";
            this.fastObjectListViewProxies.ShowGroups = false;
            this.fastObjectListViewProxies.Size = new System.Drawing.Size(992, 396);
            this.fastObjectListViewProxies.TabIndex = 2;
            this.fastObjectListViewProxies.UseCellFormatEvents = true;
            this.fastObjectListViewProxies.UseCompatibleStateImageBehavior = false;
            this.fastObjectListViewProxies.UseFiltering = true;
            this.fastObjectListViewProxies.View = System.Windows.Forms.View.Details;
            this.fastObjectListViewProxies.VirtualMode = true;
            this.fastObjectListViewProxies.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fastObjectListViewProxies_FormatCell);
            // 
            // olvColumnProxyIP
            // 
            this.olvColumnProxyIP.AspectName = "Address";
            this.olvColumnProxyIP.CellPadding = null;
            this.olvColumnProxyIP.Text = "Proxy";
            this.olvColumnProxyIP.Width = 124;
            // 
            // olvColumnGoodProxy
            // 
            this.olvColumnGoodProxy.AspectName = "GoodProxy";
            this.olvColumnGoodProxy.CellPadding = null;
            this.olvColumnGoodProxy.Text = "Good Proxy";
            this.olvColumnGoodProxy.Width = 117;
            // 
            // olvColumnProxyPort
            // 
            this.olvColumnProxyPort.AspectName = "Port";
            this.olvColumnProxyPort.CellPadding = null;
            this.olvColumnProxyPort.Text = "Port";
            this.olvColumnProxyPort.Width = 104;
            // 
            // olvColumnProxyAuth
            // 
            this.olvColumnProxyAuth.AspectName = "ToAuth";
            this.olvColumnProxyAuth.CellPadding = null;
            this.olvColumnProxyAuth.Text = "Authentication";
            this.olvColumnProxyAuth.Width = 135;
            // 
            // olvColumnTimeOut
            // 
            this.olvColumnTimeOut.AspectName = "ToStringCoolDownTimer";
            this.olvColumnTimeOut.AspectToStringFormat = "";
            this.olvColumnTimeOut.CellPadding = null;
            this.olvColumnTimeOut.Text = "Cool down";
            this.olvColumnTimeOut.Width = 97;
            // 
            // olvColumnUsageCount
            // 
            this.olvColumnUsageCount.AspectName = "ToStringUsedAccounts";
            this.olvColumnUsageCount.CellPadding = null;
            this.olvColumnUsageCount.Text = "Usage Count";
            this.olvColumnUsageCount.Width = 131;
            // 
            // olvColumnCurrentFails
            // 
            this.olvColumnCurrentFails.AspectName = "ToStringFailedAccounts";
            this.olvColumnCurrentFails.CellPadding = null;
            this.olvColumnCurrentFails.Text = "Failures";
            this.olvColumnCurrentFails.Width = 140;
            // 
            // contextMenuStripProxy
            // 
            this.contextMenuStripProxy.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.contextMenuStripProxy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.setToolStripMenuItem,
            this.clearUsageToolStripMenuItem,
            this.clearFailuresToolStripMenuItem,
            this.deleteToolStripMenuItem1});
            this.contextMenuStripProxy.Name = "contextMenuStripProxy";
            this.contextMenuStripProxy.Size = new System.Drawing.Size(145, 114);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleProxyToolStripMenuItem,
            this.fromFileToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // singleProxyToolStripMenuItem
            // 
            this.singleProxyToolStripMenuItem.Name = "singleProxyToolStripMenuItem";
            this.singleProxyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.singleProxyToolStripMenuItem.Text = "Single Proxy";
            this.singleProxyToolStripMenuItem.Click += new System.EventHandler(this.singleProxyToolStripMenuItem_Click);
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.fromFileToolStripMenuItem.Text = "From File...";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.fromFileToolStripMenuItem_Click);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxConcurrentFailsToolStripMenuItem,
            this.maxAccountsToolStripMenuItem,
            this.coolDownTimeToolStripMenuItem,
            this.resetCoolDownToolStripMenuItem});
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.setToolStripMenuItem.Text = "Set";
            // 
            // maxConcurrentFailsToolStripMenuItem
            // 
            this.maxConcurrentFailsToolStripMenuItem.Name = "maxConcurrentFailsToolStripMenuItem";
            this.maxConcurrentFailsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.maxConcurrentFailsToolStripMenuItem.Text = "Max Concurrent Fails";
            this.maxConcurrentFailsToolStripMenuItem.Click += new System.EventHandler(this.maxConcurrentFailsToolStripMenuItem_Click);
            // 
            // maxAccountsToolStripMenuItem
            // 
            this.maxAccountsToolStripMenuItem.Name = "maxAccountsToolStripMenuItem";
            this.maxAccountsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.maxAccountsToolStripMenuItem.Text = "Max Accounts";
            this.maxAccountsToolStripMenuItem.Click += new System.EventHandler(this.maxAccountsToolStripMenuItem_Click);
            // 
            // coolDownTimeToolStripMenuItem
            // 
            this.coolDownTimeToolStripMenuItem.Name = "coolDownTimeToolStripMenuItem";
            this.coolDownTimeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.coolDownTimeToolStripMenuItem.Text = "Cool Down Time";
            this.coolDownTimeToolStripMenuItem.Click += new System.EventHandler(this.coolDownTimeToolStripMenuItem_Click);
            // 
            // resetCoolDownToolStripMenuItem
            // 
            this.resetCoolDownToolStripMenuItem.Name = "resetCoolDownToolStripMenuItem";
            this.resetCoolDownToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.resetCoolDownToolStripMenuItem.Text = "Reset Cool Down";
            this.resetCoolDownToolStripMenuItem.Click += new System.EventHandler(this.resetBanStateToolStripMenuItem_Click);
            // 
            // clearUsageToolStripMenuItem
            // 
            this.clearUsageToolStripMenuItem.Name = "clearUsageToolStripMenuItem";
            this.clearUsageToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.clearUsageToolStripMenuItem.Text = "Clear Usage";
            this.clearUsageToolStripMenuItem.Click += new System.EventHandler(this.clearUsageToolStripMenuItem_Click);
            // 
            // clearFailuresToolStripMenuItem
            // 
            this.clearFailuresToolStripMenuItem.Name = "clearFailuresToolStripMenuItem";
            this.clearFailuresToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.clearFailuresToolStripMenuItem.Text = "Clear Failures";
            this.clearFailuresToolStripMenuItem.Click += new System.EventHandler(this.clearFailuresToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // panelListview
            // 
            this.panelListview.Controls.Add(this.tabControlMain);
            this.panelListview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListview.Location = new System.Drawing.Point(304, 3);
            this.panelListview.Name = "panelListview";
            this.panelListview.Size = new System.Drawing.Size(1006, 428);
            this.panelListview.TabIndex = 1;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageSelectedNodeUrls);
            this.tabControlMain.Controls.Add(this.tabPageProxy);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1006, 428);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageSelectedNodeUrls
            // 
            this.tabPageSelectedNodeUrls.Controls.Add(this.fastObjectListViewUrl);
            this.tabPageSelectedNodeUrls.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelectedNodeUrls.Name = "tabPageSelectedNodeUrls";
            this.tabPageSelectedNodeUrls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelectedNodeUrls.Size = new System.Drawing.Size(998, 402);
            this.tabPageSelectedNodeUrls.TabIndex = 0;
            this.tabPageSelectedNodeUrls.Text = "Selected Node Urls";
            this.tabPageSelectedNodeUrls.UseVisualStyleBackColor = true;
            // 
            // fastObjectListViewUrl
            // 
            this.fastObjectListViewUrl.AllColumns.Add(this.olvColumnStatus);
            this.fastObjectListViewUrl.AllColumns.Add(this.olvColumnUrl);
            this.fastObjectListViewUrl.AllColumns.Add(this.olvColumnProxyToString);
            this.fastObjectListViewUrl.AllColumns.Add(this.olvColumnLastLog);
            this.fastObjectListViewUrl.AllowColumnReorder = true;
            this.fastObjectListViewUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.fastObjectListViewUrl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnStatus,
            this.olvColumnUrl,
            this.olvColumnProxyToString,
            this.olvColumnLastLog});
            this.fastObjectListViewUrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListViewUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListViewUrl.ForeColor = System.Drawing.Color.LightGray;
            this.fastObjectListViewUrl.FullRowSelect = true;
            this.fastObjectListViewUrl.Location = new System.Drawing.Point(3, 3);
            this.fastObjectListViewUrl.Margin = new System.Windows.Forms.Padding(2);
            this.fastObjectListViewUrl.Name = "fastObjectListViewUrl";
            this.fastObjectListViewUrl.ShowGroups = false;
            this.fastObjectListViewUrl.Size = new System.Drawing.Size(992, 396);
            this.fastObjectListViewUrl.TabIndex = 3;
            this.fastObjectListViewUrl.UseCellFormatEvents = true;
            this.fastObjectListViewUrl.UseCompatibleStateImageBehavior = false;
            this.fastObjectListViewUrl.UseFiltering = true;
            this.fastObjectListViewUrl.View = System.Windows.Forms.View.Details;
            this.fastObjectListViewUrl.VirtualMode = true;
            this.fastObjectListViewUrl.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fastObjectListViewUrl_FormatCell);
            this.fastObjectListViewUrl.DoubleClick += new System.EventHandler(this.fastObjectListViewUrl_DoubleClick);
            // 
            // olvColumnStatus
            // 
            this.olvColumnStatus.AspectName = "Status";
            this.olvColumnStatus.CellPadding = null;
            this.olvColumnStatus.Text = "Status";
            // 
            // olvColumnUrl
            // 
            this.olvColumnUrl.AspectName = "Url";
            this.olvColumnUrl.CellPadding = null;
            this.olvColumnUrl.Text = "Url";
            this.olvColumnUrl.Width = 305;
            // 
            // olvColumnProxyToString
            // 
            this.olvColumnProxyToString.AspectName = "ProxyToString";
            this.olvColumnProxyToString.CellPadding = null;
            this.olvColumnProxyToString.Text = "Proxy";
            this.olvColumnProxyToString.Width = 179;
            // 
            // olvColumnLastLog
            // 
            this.olvColumnLastLog.AspectName = "LastLog";
            this.olvColumnLastLog.CellPadding = null;
            this.olvColumnLastLog.FillsFreeSpace = true;
            this.olvColumnLastLog.Text = "LastLog";
            this.olvColumnLastLog.Width = 332;
            // 
            // tabPageProxy
            // 
            this.tabPageProxy.Controls.Add(this.fastObjectListViewProxies);
            this.tabPageProxy.Location = new System.Drawing.Point(4, 22);
            this.tabPageProxy.Name = "tabPageProxy";
            this.tabPageProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProxy.Size = new System.Drawing.Size(998, 402);
            this.tabPageProxy.TabIndex = 1;
            this.tabPageProxy.Text = "Proxy";
            this.tabPageProxy.UseVisualStyleBackColor = true;
            // 
            // panelTreeview
            // 
            this.panelTreeview.Controls.Add(this.tableLayoutPanelTreeView);
            this.panelTreeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTreeview.Location = new System.Drawing.Point(3, 3);
            this.panelTreeview.Name = "panelTreeview";
            this.panelTreeview.Size = new System.Drawing.Size(295, 428);
            this.panelTreeview.TabIndex = 2;
            // 
            // tableLayoutPanelTreeView
            // 
            this.tableLayoutPanelTreeView.ColumnCount = 1;
            this.tableLayoutPanelTreeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTreeView.Controls.Add(this.treeViewEmails, 0, 1);
            this.tableLayoutPanelTreeView.Controls.Add(this.tableLayoutPanelTreeViewControls, 0, 0);
            this.tableLayoutPanelTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTreeView.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTreeView.Name = "tableLayoutPanelTreeView";
            this.tableLayoutPanelTreeView.RowCount = 2;
            this.tableLayoutPanelTreeView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.740586F));
            this.tableLayoutPanelTreeView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.25941F));
            this.tableLayoutPanelTreeView.Size = new System.Drawing.Size(295, 428);
            this.tableLayoutPanelTreeView.TabIndex = 1;
            // 
            // treeViewEmails
            // 
            this.treeViewEmails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewEmails.Indent = 15;
            this.treeViewEmails.Location = new System.Drawing.Point(3, 36);
            this.treeViewEmails.Name = "treeViewEmails";
            this.treeViewEmails.ShowLines = false;
            this.treeViewEmails.Size = new System.Drawing.Size(289, 389);
            this.treeViewEmails.TabIndex = 0;
            this.treeViewEmails.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewEmails_BeforeSelect);
            this.treeViewEmails.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewEmails_AfterSelect);
            // 
            // tableLayoutPanelTreeViewControls
            // 
            this.tableLayoutPanelTreeViewControls.AutoSize = true;
            this.tableLayoutPanelTreeViewControls.ColumnCount = 4;
            this.tableLayoutPanelTreeViewControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTreeViewControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTreeViewControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTreeViewControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelTreeViewControls.Controls.Add(this.buttonAdd, 0, 0);
            this.tableLayoutPanelTreeViewControls.Controls.Add(this.buttonEdit, 1, 0);
            this.tableLayoutPanelTreeViewControls.Controls.Add(this.buttonRemove, 2, 0);
            this.tableLayoutPanelTreeViewControls.Controls.Add(this.buttonStartSelected, 3, 0);
            this.tableLayoutPanelTreeViewControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTreeViewControls.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelTreeViewControls.Name = "tableLayoutPanelTreeViewControls";
            this.tableLayoutPanelTreeViewControls.RowCount = 1;
            this.tableLayoutPanelTreeViewControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTreeViewControls.Size = new System.Drawing.Size(289, 27);
            this.tableLayoutPanelTreeViewControls.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(62, 21);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add Email";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(71, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(62, 21);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit Email";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(139, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(84, 21);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove Email";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonStartSelected
            // 
            this.buttonStartSelected.Location = new System.Drawing.Point(229, 3);
            this.buttonStartSelected.Name = "buttonStartSelected";
            this.buttonStartSelected.Size = new System.Drawing.Size(60, 21);
            this.buttonStartSelected.TabIndex = 3;
            this.buttonStartSelected.Text = "Start";
            this.buttonStartSelected.UseVisualStyleBackColor = true;
            this.buttonStartSelected.Click += new System.EventHandler(this.buttonStartSelected_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.00076F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.99924F));
            this.tableLayoutPanelMain.Controls.Add(this.panelTreeview, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelListview, 1, 0);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1313, 434);
            this.tableLayoutPanelMain.TabIndex = 3;
            // 
            // timerUrlRefresher
            // 
            this.timerUrlRefresher.Enabled = true;
            this.timerUrlRefresher.Interval = 1000;
            this.timerUrlRefresher.Tick += new System.EventHandler(this.timerUrlRefresher_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activatingLabel,
            this.toolStripStatusLabel2,
            this.pendingLabel,
            this.toolStripStatusLabel1,
            this.activatedLabel,
            this.toolStripStatusLabel3,
            this.failedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 462);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1313, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // activatingLabel
            // 
            this.activatingLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.activatingLabel.ForeColor = System.Drawing.Color.Green;
            this.activatingLabel.Name = "activatingLabel";
            this.activatingLabel.Size = new System.Drawing.Size(73, 17);
            this.activatingLabel.Text = "Activating: 0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // pendingLabel
            // 
            this.pendingLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.pendingLabel.ForeColor = System.Drawing.Color.LightGreen;
            this.pendingLabel.Name = "pendingLabel";
            this.pendingLabel.Size = new System.Drawing.Size(63, 17);
            this.pendingLabel.Text = "Pending: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // activatedLabel
            // 
            this.activatedLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.activatedLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.activatedLabel.Name = "activatedLabel";
            this.activatedLabel.Size = new System.Drawing.Size(69, 17);
            this.activatedLabel.Text = "Activated: 0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // failedLabel
            // 
            this.failedLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.failedLabel.ForeColor = System.Drawing.Color.Yellow;
            this.failedLabel.Name = "failedLabel";
            this.failedLabel.Size = new System.Drawing.Size(50, 17);
            this.failedLabel.Text = "Failed: 0";
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDiscord,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabelDonate,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabelAccountCreator,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabelCheapProxy});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1313, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 11;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabelDiscord
            // 
            this.toolStripStatusLabelDiscord.IsLink = true;
            this.toolStripStatusLabelDiscord.LinkColor = System.Drawing.Color.Olive;
            this.toolStripStatusLabelDiscord.Name = "toolStripStatusLabelDiscord";
            this.toolStripStatusLabelDiscord.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabelDiscord.Tag = "";
            this.toolStripStatusLabelDiscord.Text = "Discord";
            this.toolStripStatusLabelDiscord.Click += new System.EventHandler(this.toolStripStatusLabelDiscord_Click);
            // 
            // toolStripStatusLabelDonate
            // 
            this.toolStripStatusLabelDonate.IsLink = true;
            this.toolStripStatusLabelDonate.LinkColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripStatusLabelDonate.Name = "toolStripStatusLabelDonate";
            this.toolStripStatusLabelDonate.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabelDonate.Tag = "";
            this.toolStripStatusLabelDonate.Text = "Donate";
            this.toolStripStatusLabelDonate.Click += new System.EventHandler(this.toolStripStatusLabelDonate_Click);
            // 
            // toolStripStatusLabelAccountCreator
            // 
            this.toolStripStatusLabelAccountCreator.IsLink = true;
            this.toolStripStatusLabelAccountCreator.LinkColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabelAccountCreator.Name = "toolStripStatusLabelAccountCreator";
            this.toolStripStatusLabelAccountCreator.Size = new System.Drawing.Size(94, 17);
            this.toolStripStatusLabelAccountCreator.Tag = "";
            this.toolStripStatusLabelAccountCreator.Text = "Account Creator";
            this.toolStripStatusLabelAccountCreator.Click += new System.EventHandler(this.toolStripStatusLabelAccountCreator_Click);
            // 
            // toolStripStatusLabelCheapProxy
            // 
            this.toolStripStatusLabelCheapProxy.IsLink = true;
            this.toolStripStatusLabelCheapProxy.LinkColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelCheapProxy.Name = "toolStripStatusLabelCheapProxy";
            this.toolStripStatusLabelCheapProxy.Size = new System.Drawing.Size(108, 17);
            this.toolStripStatusLabelCheapProxy.Tag = "";
            this.toolStripStatusLabelCheapProxy.Text = "Pokemon Go Proxy";
            this.toolStripStatusLabelCheapProxy.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel6.Text = "|";
            // 
            // MainUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1313, 484);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "MainUi";
            this.Text = "Pokemon Activation Link Clicker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUi_FormClosing);
            this.Load += new System.EventHandler(this.MainUi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewProxies)).EndInit();
            this.contextMenuStripProxy.ResumeLayout(false);
            this.panelListview.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSelectedNodeUrls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListViewUrl)).EndInit();
            this.tabPageProxy.ResumeLayout(false);
            this.panelTreeview.ResumeLayout(false);
            this.tableLayoutPanelTreeView.ResumeLayout(false);
            this.tableLayoutPanelTreeView.PerformLayout();
            this.tableLayoutPanelTreeViewControls.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ContextMenuStrip contextMenuStripProxy;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem singleProxyToolStripMenuItem;
        private ToolStripMenuItem fromFileToolStripMenuItem;
        private ToolStripMenuItem setToolStripMenuItem;
        private ToolStripMenuItem maxConcurrentFailsToolStripMenuItem;
        private ToolStripMenuItem maxAccountsToolStripMenuItem;
        private ToolStripMenuItem resetCoolDownToolStripMenuItem;
        private ToolStripMenuItem clearFailuresToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripMenuItem coolDownTimeToolStripMenuItem;
        private Panel panelListview;
        private TabControl tabControlMain;
        private TabPage tabPageSelectedNodeUrls;
        private TabPage tabPageProxy;
        private FastObjectListView fastObjectListViewProxies;
        private Panel panelTreeview;
        private TableLayoutPanel tableLayoutPanelTreeView;
        private TreeView treeViewEmails;
        private TableLayoutPanel tableLayoutPanelTreeViewControls;
        private Button buttonRemove;
        private Button buttonEdit;
        private Button buttonAdd;
        private TableLayoutPanel tableLayoutPanelMain;
        private FastObjectListView fastObjectListViewUrl;
        private OLVColumn olvColumnUrl;
        private OLVColumn olvColumnLastLog;
        private OLVColumn olvColumnProxyToString;
        private OLVColumn olvColumnProxyIP;
        private OLVColumn olvColumnProxyPort;
        private OLVColumn olvColumnProxyAuth;
        private OLVColumn olvColumnUsageCount;
        private OLVColumn olvColumnCurrentFails;
        private OLVColumn olvColumnTimeOut;
        private OLVColumn olvColumnGoodProxy;
        private Button buttonStartSelected;
        private Timer timerUrlRefresher;
        private OLVColumn olvColumnStatus;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel activatingLabel;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel pendingLabel;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel activatedLabel;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel failedLabel;
        private ToolStripMenuItem clearUsageToolStripMenuItem;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel toolStripStatusLabelDiscord;
        private ToolStripStatusLabel toolStripStatusLabelDonate;
        private ToolStripStatusLabel toolStripStatusLabelAccountCreator;
        private ToolStripStatusLabel toolStripStatusLabelCheapProxy;
        private ToolStripStatusLabel toolStripStatusLabel6;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel toolStripStatusLabel4;
    }
}