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
            this.YPanel = new System.Windows.Forms.Panel();
            this.ZPanel = new System.Windows.Forms.Panel();
            this.FPanel = new System.Windows.Forms.Panel();
            this.DPanel = new System.Windows.Forms.Panel();
            this.GPanel = new System.Windows.Forms.Panel();
            this.BPanel = new System.Windows.Forms.Panel();
            this.CPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // YPanel
            // 
            this.YPanel.Location = new System.Drawing.Point(0, 930);
            this.YPanel.Name = "YPanel";
            this.YPanel.Size = new System.Drawing.Size(1280, 30);
            this.YPanel.TabIndex = 0;
            // 
            // ZPanel
            // 
            this.ZPanel.Location = new System.Drawing.Point(0, 0);
            this.ZPanel.Name = "ZPanel";
            this.ZPanel.Size = new System.Drawing.Size(1280, 30);
            this.ZPanel.TabIndex = 1;
            // 
            // FPanel
            // 
            this.FPanel.Location = new System.Drawing.Point(1160, 30);
            this.FPanel.Name = "FPanel";
            this.FPanel.Size = new System.Drawing.Size(120, 900);
            this.FPanel.TabIndex = 1;
            // 
            // DPanel
            // 
            this.DPanel.Location = new System.Drawing.Point(668, 30);
            this.DPanel.Name = "DPanel";
            this.DPanel.Size = new System.Drawing.Size(492, 600);
            this.DPanel.TabIndex = 2;
            // 
            // GPanel
            // 
            this.GPanel.Location = new System.Drawing.Point(668, 630);
            this.GPanel.Name = "GPanel";
            this.GPanel.Size = new System.Drawing.Size(492, 300);
            this.GPanel.TabIndex = 3;
            // 
            // BPanel
            // 
            this.BPanel.Location = new System.Drawing.Point(108, 30);
            this.BPanel.Name = "BPanel";
            this.BPanel.Size = new System.Drawing.Size(560, 600);
            this.BPanel.TabIndex = 3;
            // 
            // CPanel
            // 
            this.CPanel.Location = new System.Drawing.Point(0, 630);
            this.CPanel.Name = "CPanel";
            this.CPanel.Size = new System.Drawing.Size(668, 100);
            this.CPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 730);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 200);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(108, 600);
            this.panel2.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 960);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CPanel);
            this.Controls.Add(this.BPanel);
            this.Controls.Add(this.GPanel);
            this.Controls.Add(this.DPanel);
            this.Controls.Add(this.FPanel);
            this.Controls.Add(this.ZPanel);
            this.Controls.Add(this.YPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "ETCS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel YPanel;
        private System.Windows.Forms.Panel ZPanel;
        private System.Windows.Forms.Panel FPanel;
        private System.Windows.Forms.Panel DPanel;
        private System.Windows.Forms.Panel GPanel;
        private System.Windows.Forms.Panel BPanel;
        private System.Windows.Forms.Panel CPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}