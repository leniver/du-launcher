using System;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DU_Launcher
{
    public partial class Launcher : Form
    {

        protected string settingsFile;
        protected string duFolder;
        protected string duLauncherName = "dual-launcher.exe";
        protected string[] accounts;
        protected bool settingsLoaded = false;

        public Launcher()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            Settings settingsForm = new Settings(this);
            this.settingsFile = ConfigurationManager.AppSettings.Get("settingsFile");
            if (settingsFile == null || settingsFile.Length == 0 || !File.Exists(settingsFile))
            {
                start_btn.Enabled = false;
                return;
            }
            this.duFolder = ConfigurationManager.AppSettings.Get("duFolder");
            if (duFolder == null || duFolder.Length == 0 || !Directory.Exists(duFolder) || !File.Exists(duFolder + duLauncherName))
            {
                start_btn.Enabled = false;
                return;
            }
            this.accounts = ConfigurationManager.AppSettings.Get("accounts").Split(',');
            if (accounts == null || accounts.Length == 0)
            {
                start_btn.Enabled = false;
                return;
            }
            start_btn.Enabled = true;

            try
            {
                this.username_cb.Items.Clear();
                this.username_cb.Items.AddRange(this.accounts);
                string content = File.ReadAllText(settingsFile);
                Match match = Regex.Match(content, "userName: (.*)");
                if (match.Success)
                {
                    username_cb.SelectedItem = match.Groups[1].ToString().Trim();
                }
                else
                {
                    ExceptionHandling("Not able to get the username from the settings file");
                }
            }
            catch (Exception exception)
            {
                ExceptionHandling(exception.Message);
            }

        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string content = File.ReadAllText(settingsFile);
                File.WriteAllText(settingsFile, Regex.Replace(content, "userName: .*", "userName: " + username_cb.Text));
                ProcessStartInfo processStartInfo = new ProcessStartInfo(duFolder + duLauncherName);
                processStartInfo.WorkingDirectory = duFolder;
                Process.Start(processStartInfo);
                this.Close();
            }
            catch (Exception exception)
            {
                ExceptionHandling(exception.Message);
            }
        }

        private void ExceptionHandling(string message)
        {
            string caption = "An error occure";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(this);
            settingsForm.Show();
        }
    }
}
