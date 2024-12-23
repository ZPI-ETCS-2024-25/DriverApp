﻿using System.Security.Cryptography;
using System.Windows.Forms;

namespace DriverETCSApp.Forms
{
    partial class MainForm
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
            this.yPanel = new System.Windows.Forms.PictureBox();
            this.zPanel = new System.Windows.Forms.PictureBox();
            this.fPanel = new System.Windows.Forms.PictureBox();
            this.dPanel = new System.Windows.Forms.PictureBox();
            this.gPanel = new System.Windows.Forms.PictureBox();
            this.bPanel = new System.Windows.Forms.PictureBox();
            this.cPanel = new System.Windows.Forms.PictureBox();
            this.ePanel = new System.Windows.Forms.PictureBox();
            this.aPanel = new System.Windows.Forms.PictureBox();
            this.MainPanel = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // yPanel
            // 
            this.yPanel.Location = new System.Drawing.Point(0, 930);
            this.yPanel.Name = "yPanel";
            this.yPanel.Size = new System.Drawing.Size(1280, 30);
            this.yPanel.TabIndex = 0;
            // 
            // zPanel
            // 
            this.zPanel.Location = new System.Drawing.Point(0, 0);
            this.zPanel.Name = "zPanel";
            this.zPanel.Size = new System.Drawing.Size(1280, 30);
            this.zPanel.TabIndex = 1;
            // 
            // fPanel
            // 
            this.fPanel.Location = new System.Drawing.Point(1160, 30);
            this.fPanel.Name = "fPanel";
            this.fPanel.Size = new System.Drawing.Size(120, 900);
            this.fPanel.TabIndex = 1;
            // 
            // dPanel
            // 
            this.dPanel.BackColor = System.Drawing.Color.Transparent;
            this.dPanel.Location = new System.Drawing.Point(668, 30);
            this.dPanel.Name = "dPanel";
            this.dPanel.Size = new System.Drawing.Size(492, 600);
            this.dPanel.TabIndex = 2;
            // 
            // gPanel
            // 
            this.gPanel.Location = new System.Drawing.Point(668, 630);
            this.gPanel.Name = "gPanel";
            this.gPanel.Size = new System.Drawing.Size(492, 300);
            this.gPanel.TabIndex = 3;
            // 
            // bPanel
            // 
            this.bPanel.Location = new System.Drawing.Point(108, 30);
            this.bPanel.Name = "bPanel";
            this.bPanel.Size = new System.Drawing.Size(560, 600);
            this.bPanel.TabIndex = 3;
            // 
            // cPanel
            // 
            this.cPanel.Location = new System.Drawing.Point(0, 630);
            this.cPanel.Name = "cPanel";
            this.cPanel.Size = new System.Drawing.Size(668, 100);
            this.cPanel.TabIndex = 4;
            // 
            // ePanel
            // 
            this.ePanel.Location = new System.Drawing.Point(0, 730);
            this.ePanel.Name = "ePanel";
            this.ePanel.Size = new System.Drawing.Size(668, 200);
            this.ePanel.TabIndex = 5;
            // 
            // aPanel
            // 
            this.aPanel.Location = new System.Drawing.Point(0, 30);
            this.aPanel.Name = "aPanel";
            this.aPanel.Size = new System.Drawing.Size(108, 600);
            this.aPanel.TabIndex = 4;
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1280, 960);
            this.MainPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1280, 960);
            this.Controls.Add(this.aPanel);
            this.Controls.Add(this.ePanel);
            this.Controls.Add(this.cPanel);
            this.Controls.Add(this.bPanel);
            this.Controls.Add(this.gPanel);
            this.Controls.Add(this.dPanel);
            this.Controls.Add(this.fPanel);
            this.Controls.Add(this.zPanel);
            this.Controls.Add(this.yPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ETCS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox yPanel;
        private PictureBox zPanel;
        private PictureBox fPanel;
        private PictureBox dPanel;
        private PictureBox gPanel;
        private PictureBox bPanel;
        private PictureBox cPanel;
        private PictureBox ePanel;
        private PictureBox aPanel;
        private PictureBox MainPanel;
    }
}