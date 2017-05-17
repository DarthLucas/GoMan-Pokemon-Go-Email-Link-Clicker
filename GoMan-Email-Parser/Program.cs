using System;
using System.Net;
using System.Windows.Forms;
using Email_Url_Parser.UI;

namespace Email_Url_Parser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainUi());
        }
    }
}
