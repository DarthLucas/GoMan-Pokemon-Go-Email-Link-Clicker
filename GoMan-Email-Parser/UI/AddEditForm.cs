using System;
using System.Drawing;
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
            if (IsValidEmail(textBoxUsername.Text) && Int32.TryParse(textBoxPort.Text, out port))
            {

                Settings = new EmailUrlParserConfiguration()
                {
                    Username = textBoxUsername.Text,
                    Password = textBoxPassword.Text,
                    ServerHostName = textBoxImapHostName.Text,
                    Port = port,
                    IsSsl = checkBoxSsl.Checked,
                    DeleteSuccessful = checkBoxDeleteSuccessful.Checked
                };

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid email address or port.");
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
    }
}
