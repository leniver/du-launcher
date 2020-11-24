using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DU_Launcher
{
    public partial class Settings : Form
    {
        protected string settingsFile;
        protected string duFolder;
        protected string duLauncherName = "dual-launcher.exe";
        protected string[] accounts;
        protected Launcher parent;

        public Settings(Launcher parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.txt_settingsFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_settingsFile = new System.Windows.Forms.Button();
            this.btn_duFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_duFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_accounts = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_settingsFile
            // 
            this.txt_settingsFile.Location = new System.Drawing.Point(15, 25);
            this.txt_settingsFile.Name = "txt_settingsFile";
            this.txt_settingsFile.ReadOnly = true;
            this.txt_settingsFile.Size = new System.Drawing.Size(319, 20);
            this.txt_settingsFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Settings file (AppData/Local/NQ/DualUniverse/Settings.yaml)";
            // 
            // btn_settingsFile
            // 
            this.btn_settingsFile.Location = new System.Drawing.Point(352, 25);
            this.btn_settingsFile.Name = "btn_settingsFile";
            this.btn_settingsFile.Size = new System.Drawing.Size(75, 20);
            this.btn_settingsFile.TabIndex = 2;
            this.btn_settingsFile.Text = "Select";
            this.btn_settingsFile.UseVisualStyleBackColor = true;
            this.btn_settingsFile.Click += new System.EventHandler(this.btn_settingsFile_Click);
            // 
            // btn_duFolder
            // 
            this.btn_duFolder.Location = new System.Drawing.Point(354, 86);
            this.btn_duFolder.Name = "btn_duFolder";
            this.btn_duFolder.Size = new System.Drawing.Size(75, 20);
            this.btn_duFolder.TabIndex = 5;
            this.btn_duFolder.Text = "Select";
            this.btn_duFolder.UseVisualStyleBackColor = true;
            this.btn_duFolder.Click += new System.EventHandler(this.btn_duFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Installation directory (ProgramData/Dual Universe/)";
            // 
            // txt_duFolder
            // 
            this.txt_duFolder.Location = new System.Drawing.Point(17, 86);
            this.txt_duFolder.Name = "txt_duFolder";
            this.txt_duFolder.ReadOnly = true;
            this.txt_duFolder.Size = new System.Drawing.Size(319, 20);
            this.txt_duFolder.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Accounts (emails on by line)";
            // 
            // txt_accounts
            // 
            this.txt_accounts.Location = new System.Drawing.Point(17, 151);
            this.txt_accounts.Multiline = true;
            this.txt_accounts.Name = "txt_accounts";
            this.txt_accounts.Size = new System.Drawing.Size(319, 121);
            this.txt_accounts.TabIndex = 6;
            this.txt_accounts.Enter += new System.EventHandler(this.txt_accounts_Enter);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(352, 300);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 20);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Settings
            // 
            this.ClientSize = new System.Drawing.Size(439, 335);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_accounts);
            this.Controls.Add(this.btn_duFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_duFolder);
            this.Controls.Add(this.btn_settingsFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_settingsFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(455, 374);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(455, 374);
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application settings";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btn_settingsFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                settingsFile = file.FileName;
                txt_settingsFile.BackColor = Color.White;
                txt_settingsFile.Text = settingsFile;
                txt_settingsFile.Enabled = false;
            }
        }

        private void btn_duFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog file = new FolderBrowserDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                duFolder = file.SelectedPath + "\\";
                txt_duFolder.BackColor = Color.White;
                txt_duFolder.Text = duFolder;
                txt_duFolder.Enabled = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            if (settingsFile == null || settingsFile.Length == 0 || !File.Exists(settingsFile))
            {
                txt_settingsFile.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txt_settingsFile.BackColor = Color.White;
            }
            if (duFolder == null || duFolder.Length == 0 || !Directory.Exists(duFolder) || !File.Exists(duFolder + duLauncherName))
            {
                txt_duFolder.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txt_duFolder.BackColor = Color.White;
            }
            accounts = txt_accounts.Text.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.RemoveEmptyEntries
            );
            if (accounts == null || accounts.Length == 0)
            {
                txt_accounts.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txt_accounts.BackColor = Color.White;
            }
            if (!hasError)
            {
                this.SaveSettings();
                this.Close();
            }
        }

        public void SaveSettings()
        {
            SetSetting("settingsFile", settingsFile);
            SetSetting("duFolder", duFolder);
            SetSetting("accounts", String.Join(",", this.accounts));
        }

        private void SetSetting(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
            }
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            this.parent.Opacity = 0.0;
            this.settingsFile = ConfigurationManager.AppSettings.Get("settingsFile");
            if (!(this.settingsFile == null || this.settingsFile.Length == 0 || !File.Exists(this.settingsFile)))
            {
                txt_settingsFile.Text = this.settingsFile;
            }
            this.duFolder = ConfigurationManager.AppSettings.Get("duFolder");
            if (!(duFolder == null || duFolder.Length == 0 || !Directory.Exists(duFolder) || !File.Exists(duFolder + duLauncherName)))
            {
                txt_duFolder.Text = this.duFolder;
            }
            this.accounts = ConfigurationManager.AppSettings.Get("accounts").Split(',');
            if (!(accounts == null || accounts.Length == 0))
            {
                txt_accounts.Text = String.Join("\r\n", this.accounts);
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parent.Opacity = 1.0;
            this.parent.LoadSettings();
        }

        private void txt_accounts_Enter(object sender, EventArgs e)
        {
            txt_accounts.BackColor = Color.White;
        }
    }
}
