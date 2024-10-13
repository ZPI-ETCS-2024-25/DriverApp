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
            this.clockPanel = new System.Windows.Forms.Panel();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clockPanel
            // 
            this.clockPanel.BackColor = System.Drawing.Color.Transparent;
            this.clockPanel.Location = new System.Drawing.Point(22, 12);
            this.clockPanel.Name = "clockPanel";
            this.clockPanel.Size = new System.Drawing.Size(500, 500);
            this.clockPanel.TabIndex = 2;
            this.clockPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.clockPanel_Paint);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(429, 526);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(75, 23);
            this.btnTest1.TabIndex = 3;
            this.btnTest1.Text = "speed up";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // SpeedmeterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 561);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.clockPanel);
            this.Name = "SpeedmeterForm";
            this.Text = "SpeedmeterForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel clockPanel;
        private System.Windows.Forms.Button btnTest1;
    }
}