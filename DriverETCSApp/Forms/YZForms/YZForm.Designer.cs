using DriverETCSApp.Design;

namespace DriverETCSApp.Forms
{
    partial class YZForm
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
            this.SuspendLayout();
            // 
            // YZForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = DMIColors.DarkBlue;
            this.ClientSize = new System.Drawing.Size(1280, 30);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YZForm";
            this.Text = "";
            this.ResumeLayout(false);

        }

        #endregion
    }
}