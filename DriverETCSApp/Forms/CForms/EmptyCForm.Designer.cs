﻿namespace DriverETCSApp.Forms.CForms {
    partial class EmptyCForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.levelPicture = new System.Windows.Forms.PictureBox();
            this.levelAnnouncementPicture = new System.Windows.Forms.PictureBox();
            this.brakePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.levelPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelAnnouncementPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brakePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // levelPicture
            // 
            this.levelPicture.Location = new System.Drawing.Point(0, 0);
            this.levelPicture.Name = "levelPicture";
            this.levelPicture.Size = new System.Drawing.Size(108, 50);
            this.levelPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.levelPicture.TabIndex = 10;
            this.levelPicture.TabStop = false;
            // 
            // levelAnnouncementPicture
            // 
            this.levelAnnouncementPicture.Location = new System.Drawing.Point(276, 0);
            this.levelAnnouncementPicture.Name = "levelAnnouncementPicture";
            this.levelAnnouncementPicture.Size = new System.Drawing.Size(116, 100);
            this.levelAnnouncementPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.levelAnnouncementPicture.TabIndex = 9;
            this.levelAnnouncementPicture.TabStop = false;
            this.levelAnnouncementPicture.Click += new System.EventHandler(this.levelAnnouncementPicture_Click);
            this.levelAnnouncementPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.levelAnnouncementPicture_Paint);
            // 
            // brakePicture
            // 
            this.brakePicture.Location = new System.Drawing.Point(0, 50);
            this.brakePicture.Name = "brakePicture";
            this.brakePicture.Size = new System.Drawing.Size(108, 50);
            this.brakePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.brakePicture.TabIndex = 11;
            this.brakePicture.TabStop = false;
            // 
            // EmptyCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(668, 100);
            this.Controls.Add(this.brakePicture);
            this.Controls.Add(this.levelPicture);
            this.Controls.Add(this.levelAnnouncementPicture);
            this.Name = "EmptyCForm";
            this.Text = "EmptyCForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmptyCForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.levelPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelAnnouncementPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brakePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox levelAnnouncementPicture;
        private System.Windows.Forms.PictureBox levelPicture;
        private System.Windows.Forms.PictureBox brakePicture;
    }
}