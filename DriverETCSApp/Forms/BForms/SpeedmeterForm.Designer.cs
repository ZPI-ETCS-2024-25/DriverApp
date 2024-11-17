namespace DriverETCSApp.Forms.BForms {
    partial class SpeedmeterForm {
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
            this.clockPanel = new System.Windows.Forms.PictureBox();
            this.modePicture = new System.Windows.Forms.PictureBox();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.btnTest3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clockPanel)).BeginInit();
            this.clockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // clockPanel
            // 
            this.clockPanel.BackColor = System.Drawing.Color.White;
            this.clockPanel.BackgroundImage = global::DriverETCSApp.Properties.Resources.ClockImage;
            this.clockPanel.Controls.Add(this.modePicture);
            this.clockPanel.Location = new System.Drawing.Point(22, 20);
            this.clockPanel.Name = "clockPanel";
            this.clockPanel.Size = new System.Drawing.Size(500, 500);
            this.clockPanel.TabIndex = 2;
            this.clockPanel.TabStop = false;
            this.clockPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.clockPanel_Paint);
            // 
            // modePicture
            // 
            this.modePicture.Image = global::DriverETCSApp.Properties.Resources.SB;
            this.modePicture.Location = new System.Drawing.Point(432, 432);
            this.modePicture.Name = "modePicture";
            this.modePicture.Size = new System.Drawing.Size(64, 64);
            this.modePicture.TabIndex = 7;
            this.modePicture.TabStop = false;
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(455, 526);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(75, 23);
            this.btnTest1.TabIndex = 3;
            this.btnTest1.Text = "speed up";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(455, 555);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(75, 23);
            this.btnTest2.TabIndex = 4;
            this.btnTest2.Text = "speed down";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // btnTest3
            // 
            this.btnTest3.Location = new System.Drawing.Point(22, 526);
            this.btnTest3.Name = "btnTest3";
            this.btnTest3.Size = new System.Drawing.Size(75, 23);
            this.btnTest3.TabIndex = 5;
            this.btnTest3.Text = "TEST";
            this.btnTest3.UseVisualStyleBackColor = true;
            this.btnTest3.Visible = false;
            this.btnTest3.Click += new System.EventHandler(this.btnTest3_Click);
            // 
            // SpeedmeterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(560, 600);
            this.Controls.Add(this.btnTest3);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.clockPanel);
            this.Name = "SpeedmeterForm";
            this.Text = "SpeedmeterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpeedmeterForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.clockPanel)).EndInit();
            this.clockPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox clockPanel;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Button btnTest2;
        private System.Windows.Forms.Button btnTest3;
        private System.Windows.Forms.PictureBox modePicture;
    }
}