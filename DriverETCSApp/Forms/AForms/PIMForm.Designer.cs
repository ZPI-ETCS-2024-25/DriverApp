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
            this.panelPIM = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelPIM
            // 
            this.panelPIM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.panelPIM.BackgroundImage = global::DriverETCSApp.Properties.Resources.column;
            this.panelPIM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panelPIM.Location = new System.Drawing.Point(0, 0);
            this.panelPIM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelPIM.Name = "panelPIM";
            this.panelPIM.Size = new System.Drawing.Size(126, 477);
            this.panelPIM.TabIndex = 3;
            this.panelPIM.Visible = false;
            this.panelPIM.Paint += new System.Windows.Forms.PaintEventHandler(this.clockPanel_Paint);
            // 
            // PIMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(126, 600);
            this.Controls.Add(this.panelPIM);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PIMForm";
            this.Text = "PIMForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PIMForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelPIM;
    }
}