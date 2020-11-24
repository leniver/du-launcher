
using System;
using System.Windows.Forms;

namespace DU_Launcher
{
    partial class Settings
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
        private TextBox txt_settingsFile;
        private Label label1;
        private Button btn_settingsFile;
        private Button btn_duFolder;
        private Label label2;
        private TextBox txt_duFolder;
        private Label label3;
        private TextBox txt_accounts;
        private Button btn_save;
    }
}