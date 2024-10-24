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
            ((System.ComponentModel.ISupportInitialize)(this.levelPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelAnnouncementPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // levelPicture
            // 
            this.levelPicture.Image = global::DriverETCSApp.Properties.Resources.L2;
            this.levelPicture.Location = new System.Drawing.Point(0, 1);
            this.levelPicture.Name = "levelPicture";
            this.levelPicture.Size = new System.Drawing.Size(108, 52);
            this.levelPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.levelPicture.TabIndex = 10;
            this.levelPicture.TabStop = false;
            // 
            // levelAnnouncementPicture
            // 
            this.levelAnnouncementPicture.Image = global::DriverETCSApp.Properties.Resources.L0A;
            this.levelAnnouncementPicture.Location = new System.Drawing.Point(296, 1);
            this.levelAnnouncementPicture.Name = "levelAnnouncementPicture";
            this.levelAnnouncementPicture.Size = new System.Drawing.Size(129, 98);
            this.levelAnnouncementPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.levelAnnouncementPicture.TabIndex = 9;
            this.levelAnnouncementPicture.TabStop = false;
            // 
            // EmptyCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(668, 100);
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
    }
}