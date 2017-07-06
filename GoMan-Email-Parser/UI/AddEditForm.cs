using System;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using GoMan.Imap;

namespace Email_Url_Parser.UI
{
    public partial class AddEditForm : Form
    {
        public EmailUrlParserConfiguration Settings;
        public AddEditForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
        public AddEditForm(EmailUrlParserConfiguration settings)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.Text = "Edit";

            textBoxUsername.Text = settings.Username;
            textBoxPassword.Text = settings.Password;
            textBoxImapHostName.Text = settings.ServerHostName;
            textBoxPort.Text = settings.Port.ToString();
            checkBoxSsl.Checked = settings.IsSsl;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int port;
            if (checkBoxPath.Checked && File.Exists(textBoxPath.Text))
            {
                Settings = new EmailUrlParserConfiguration()
                {
                    Username = textBoxPath.Text,
                    IsPath = true,
                    Path = textBoxPath.Text
                };

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (IsValidEmail(textBoxUsername.Text) && Int32.TryParse(textBoxPort.Text, out port))
                {

                    Settings = new EmailUrlParserConfiguration()
                    {
                        Username = textBoxUsername.Text,
                        Password = textBoxPassword.Text,
                        ServerHostName = textBoxImapHostName.Text,
                        Port = port,
                        IsSsl = checkBoxSsl.Checked,
                    };

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Invalid email address or port.");
                }
            }

            
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPath.Enabled = checkBoxPath.Checked;
            buttonBrowse.Enabled = checkBoxPath.Checked;

            textBoxImapHostName.Enabled = !checkBoxPath.Checked;
            textBoxPassword.Enabled = !checkBoxPath.Checked;
            textBoxPort.Enabled = !checkBoxPath.Checked;
            textBoxUsername.Enabled = !checkBoxPath.Checked;
            checkBoxSsl.Enabled = !checkBoxPath.Checked;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = openfiledialog.FileName;
            }
            openfiledialog.Dispose();
        }
    }
}
