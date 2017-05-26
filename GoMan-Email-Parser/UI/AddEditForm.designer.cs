using System.Windows.Forms;

namespace Email_Url_Parser.UI
{
    partial class AddEditForm
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxSsl = new System.Windows.Forms.CheckBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxImapHostName = new System.Windows.Forms.TextBox();
            this.labelImapHostName = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxDeleteSuccessful = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(6, 22);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 48);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password:";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxDeleteSuccessful);
            this.groupBoxSettings.Controls.Add(this.checkBoxSsl);
            this.groupBoxSettings.Controls.Add(this.textBoxPort);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.textBoxImapHostName);
            this.groupBoxSettings.Controls.Add(this.labelImapHostName);
            this.groupBoxSettings.Controls.Add(this.textBoxPassword);
            this.groupBoxSettings.Controls.Add(this.textBoxUsername);
            this.groupBoxSettings.Controls.Add(this.labelUsername);
            this.groupBoxSettings.Controls.Add(this.labelPassword);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 9);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(402, 177);
            this.groupBoxSettings.TabIndex = 4;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // checkBoxSsl
            // 
            this.checkBoxSsl.AutoSize = true;
            this.checkBoxSsl.Checked = true;
            this.checkBoxSsl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSsl.Location = new System.Drawing.Point(9, 131);
            this.checkBoxSsl.Name = "checkBoxSsl";
            this.checkBoxSsl.Size = new System.Drawing.Size(46, 17);
            this.checkBoxSsl.TabIndex = 21;
            this.checkBoxSsl.Text = "Ssl?";
            this.checkBoxSsl.UseVisualStyleBackColor = true;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(109, 97);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(287, 20);
            this.textBoxPort.TabIndex = 19;
            this.textBoxPort.Text = "993";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Port:";
            // 
            // textBoxImapHostName
            // 
            this.textBoxImapHostName.Location = new System.Drawing.Point(109, 71);
            this.textBoxImapHostName.Name = "textBoxImapHostName";
            this.textBoxImapHostName.Size = new System.Drawing.Size(287, 20);
            this.textBoxImapHostName.TabIndex = 17;
            this.textBoxImapHostName.Text = "imap.zoho.com";
            // 
            // labelImapHostName
            // 
            this.labelImapHostName.AutoSize = true;
            this.labelImapHostName.Location = new System.Drawing.Point(6, 74);
            this.labelImapHostName.Name = "labelImapHostName";
            this.labelImapHostName.Size = new System.Drawing.Size(89, 13);
            this.labelImapHostName.TabIndex = 18;
            this.labelImapHostName.Text = "Imap Host Name:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(109, 45);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(287, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(109, 19);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(287, 20);
            this.textBoxUsername.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(333, 192);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(252, 192);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxDeleteSuccessful
            // 
            this.checkBoxDeleteSuccessful.AutoSize = true;
            this.checkBoxDeleteSuccessful.Checked = true;
            this.checkBoxDeleteSuccessful.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteSuccessful.Location = new System.Drawing.Point(61, 131);
            this.checkBoxDeleteSuccessful.Name = "checkBoxDeleteSuccessful";
            this.checkBoxDeleteSuccessful.Size = new System.Drawing.Size(166, 17);
            this.checkBoxDeleteSuccessful.TabIndex = 22;
            this.checkBoxDeleteSuccessful.Text = "Delete Successful Activated?";
            this.checkBoxDeleteSuccessful.UseVisualStyleBackColor = true;
            // 
            // AddEditForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(426, 221);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add";
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private CheckBox checkBoxSsl;
        private TextBox textBoxPort;
        private Label label1;
        private TextBox textBoxImapHostName;
        private Label labelImapHostName;
        private CheckBox checkBoxDeleteSuccessful;
    }
}