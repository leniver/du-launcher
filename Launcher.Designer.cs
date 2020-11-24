
using System;
using System.Windows.Forms;

namespace DU_Launcher
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.username_cb = new System.Windows.Forms.ComboBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.btn_settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username_cb
            // 
            this.username_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.username_cb.FormattingEnabled = true;
            this.username_cb.Location = new System.Drawing.Point(12, 12);
            this.username_cb.Name = "username_cb";
            this.username_cb.Size = new System.Drawing.Size(254, 21);
            this.username_cb.TabIndex = 0;
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(191, 41);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 1;
            this.start_btn.Text = "Launch";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.Location = new System.Drawing.Point(12, 41);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(75, 23);
            this.btn_settings.TabIndex = 2;
            this.btn_settings.Text = "Settings";
            this.btn_settings.UseVisualStyleBackColor = true;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(279, 76);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.username_cb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(295, 115);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(295, 115);
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DU Launcher";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox username_cb;
        private System.Windows.Forms.Button start_btn;
        private Button btn_settings;
    }
}