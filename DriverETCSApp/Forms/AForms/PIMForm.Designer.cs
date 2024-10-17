namespace DriverETCSApp.Forms.AForms {
    partial class PIMForm {
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
            this.btnTest1 = new System.Windows.Forms.Button();
            this.panelPIM = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(57, 703);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(75, 23);
            this.btnTest1.TabIndex = 0;
            this.btnTest1.Text = "test";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // panelPIM
            // 
            this.panelPIM.BackColor = System.Drawing.Color.Transparent;
            this.panelPIM.Location = new System.Drawing.Point(0, 0);
            this.panelPIM.Margin = new System.Windows.Forms.Padding(4);
            this.panelPIM.Name = "panelPIM";
            this.panelPIM.Size = new System.Drawing.Size(144, 638);
            this.panelPIM.TabIndex = 3;
            this.panelPIM.Paint += new System.Windows.Forms.PaintEventHandler(this.clockPanel_Paint);
            // 
            // PIMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(144, 738);
            this.Controls.Add(this.panelPIM);
            this.Controls.Add(this.btnTest1);
            this.Name = "PIMForm";
            this.Text = "PIMForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Panel panelPIM;
    }
}