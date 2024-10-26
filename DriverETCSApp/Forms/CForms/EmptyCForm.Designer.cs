namespace DriverETCSApp.Forms.CForms {
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
            this.buttonLevel2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.levelPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelAnnouncementPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // levelPicture
            // 
            this.levelPicture.Location = new System.Drawing.Point(0, 1);
            this.levelPicture.Name = "levelPicture";
            this.levelPicture.Size = new System.Drawing.Size(104, 42);
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
            // 
            // buttonLevel2
            // 
            this.buttonLevel2.Location = new System.Drawing.Point(581, 30);
            this.buttonLevel2.Name = "buttonLevel2";
            this.buttonLevel2.Size = new System.Drawing.Size(75, 23);
            this.buttonLevel2.TabIndex = 11;
            this.buttonLevel2.Text = "Go to level 2";
            this.buttonLevel2.UseVisualStyleBackColor = true;
            this.buttonLevel2.Click += new System.EventHandler(this.buttonLevel2_Click);
            // 
            // EmptyCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(668, 100);
            this.Controls.Add(this.buttonLevel2);
            this.Controls.Add(this.levelPicture);
            this.Controls.Add(this.levelAnnouncementPicture);
            this.Name = "EmptyCForm";
            this.Text = "EmptyCForm";
            ((System.ComponentModel.ISupportInitialize)(this.levelPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelAnnouncementPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox levelAnnouncementPicture;
        private System.Windows.Forms.PictureBox levelPicture;
        private System.Windows.Forms.Button buttonLevel2;
    }
}