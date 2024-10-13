using DriverETCSApp.Design;
using DriverETCSApp.Data;

namespace DriverETCSApp.Forms.DForms
{
    partial class InfoTrainDataForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.infoLabelData4 = new System.Windows.Forms.Label();
            this.infoLabelData3 = new System.Windows.Forms.Label();
            this.infoLabelData2 = new System.Windows.Forms.Label();
            this.infoLabel4 = new System.Windows.Forms.Label();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.infoLabelData1 = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.infoLabelData0 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dane pociągu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabelData4
            // 
            this.infoLabelData4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData4.Location = new System.Drawing.Point(324, 337);
            this.infoLabelData4.Name = "infoLabelData4";
            this.infoLabelData4.Size = new System.Drawing.Size(156, 29);
            this.infoLabelData4.TabIndex = 51;
            this.infoLabelData4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabelData3
            // 
            this.infoLabelData3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData3.Location = new System.Drawing.Point(324, 297);
            this.infoLabelData3.Name = "infoLabelData3";
            this.infoLabelData3.Size = new System.Drawing.Size(156, 29);
            this.infoLabelData3.TabIndex = 50;
            this.infoLabelData3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabelData2
            // 
            this.infoLabelData2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData2.Location = new System.Drawing.Point(324, 257);
            this.infoLabelData2.Name = "infoLabelData2";
            this.infoLabelData2.Size = new System.Drawing.Size(156, 29);
            this.infoLabelData2.TabIndex = 49;
            this.infoLabelData2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabel4
            // 
            this.infoLabel4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel4.Location = new System.Drawing.Point(17, 337);
            this.infoLabel4.Name = "infoLabel4";
            this.infoLabel4.Size = new System.Drawing.Size(282, 29);
            this.infoLabel4.TabIndex = 48;
            this.infoLabel4.Text = "Prędkość max. (km/h)";
            this.infoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabel3
            // 
            this.infoLabel3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel3.Location = new System.Drawing.Point(49, 297);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(250, 29);
            this.infoLabel3.TabIndex = 47;
            this.infoLabel3.Text = "Rz. % masy hamuj.";
            this.infoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabel2
            // 
            this.infoLabel2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel2.Location = new System.Drawing.Point(137, 257);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(162, 29);
            this.infoLabel2.TabIndex = 46;
            this.infoLabel2.Text = "Długość (m)";
            this.infoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabelData1
            // 
            this.infoLabelData1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData1.Location = new System.Drawing.Point(324, 217);
            this.infoLabelData1.Name = "infoLabelData1";
            this.infoLabelData1.Size = new System.Drawing.Size(156, 29);
            this.infoLabelData1.TabIndex = 45;
            this.infoLabelData1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabel1
            // 
            this.infoLabel1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel1.Location = new System.Drawing.Point(173, 217);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(126, 29);
            this.infoLabel1.TabIndex = 44;
            this.infoLabel1.Text = "Kategoria";
            this.infoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabelData0
            // 
            this.infoLabelData0.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData0.Location = new System.Drawing.Point(324, 177);
            this.infoLabelData0.Name = "infoLabelData0";
            this.infoLabelData0.Size = new System.Drawing.Size(156, 29);
            this.infoLabelData0.TabIndex = 53;
            this.infoLabelData0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.label3.Location = new System.Drawing.Point(99, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 29);
            this.label3.TabIndex = 52;
            this.label3.Text = "Rodzaj pociągu";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.closeButton.Location = new System.Drawing.Point(0, 500);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(164, 100);
            this.closeButton.TabIndex = 54;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // InfoTrainDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(492, 600);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.infoLabelData0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infoLabelData4);
            this.Controls.Add(this.infoLabelData3);
            this.Controls.Add(this.infoLabelData2);
            this.Controls.Add(this.infoLabel4);
            this.Controls.Add(this.infoLabel3);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.infoLabelData1);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.label1);
            this.Name = "InfoTrainDataForm";
            this.Text = "BigDFormMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label infoLabelData4;
        private System.Windows.Forms.Label infoLabelData3;
        private System.Windows.Forms.Label infoLabelData2;
        private System.Windows.Forms.Label infoLabel4;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.Label infoLabelData1;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Label infoLabelData0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button closeButton;
    }
}