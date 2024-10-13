using DriverETCSApp.Design;

namespace DriverETCSApp.Forms.DForms
{
    partial class MainDForm
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
            this.chartSpeed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBackLines = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBackLines)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSpeed
            // 
            this.chartSpeed.BackColor = System.Drawing.Color.Transparent;
            this.chartSpeed.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartSpeed.Location = new System.Drawing.Point(294, 30);
            this.chartSpeed.Name = "chartSpeed";
            this.chartSpeed.Size = new System.Drawing.Size(186, 540);
            this.chartSpeed.TabIndex = 1;
            // 
            // chartBackLines
            // 
            this.chartBackLines.BackColor = System.Drawing.Color.Transparent;
            this.chartBackLines.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartBackLines.Location = new System.Drawing.Point(0, 30);
            this.chartBackLines.Name = "chartBackLines";
            this.chartBackLines.Size = new System.Drawing.Size(480, 540);
            this.chartBackLines.TabIndex = 0;
            // 
            // MainDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(492, 600);
            this.Controls.Add(this.chartSpeed);
            this.Controls.Add(this.chartBackLines);
            this.chartBackLines.BringToFront();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainDForm";
            this.Text = "EmptyDForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBackLines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartBackLines;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpeed;
    }
}