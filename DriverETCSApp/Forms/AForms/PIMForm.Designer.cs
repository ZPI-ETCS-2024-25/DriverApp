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
            this.lbltest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(11, 520);
            this.btnTest1.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(97, 26);
            this.btnTest1.TabIndex = 0;
            this.btnTest1.Text = "decrese distance";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // panelPIM
            // 
            this.panelPIM.BackColor = System.Drawing.Color.Transparent;
            this.panelPIM.Location = new System.Drawing.Point(0, 0);
            this.panelPIM.Name = "panelPIM";
            this.panelPIM.Size = new System.Drawing.Size(108, 477);
            this.panelPIM.TabIndex = 3;
            this.panelPIM.Paint += new System.Windows.Forms.PaintEventHandler(this.clockPanel_Paint);
            // 
            // lbltest
            // 
            this.lbltest.AutoSize = true;
            this.lbltest.ForeColor = System.Drawing.SystemColors.Control;
            this.lbltest.Location = new System.Drawing.Point(44, 561);
            this.lbltest.Name = "lbltest";
            this.lbltest.Size = new System.Drawing.Size(35, 13);
            this.lbltest.TabIndex = 4;
            this.lbltest.Text = "label1";
            // 
            // PIMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(108, 600);
            this.Controls.Add(this.lbltest);
            this.Controls.Add(this.panelPIM);
            this.Controls.Add(this.btnTest1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PIMForm";
            this.Text = "PIMForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Panel panelPIM;
        private System.Windows.Forms.Label lbltest;
    }
}