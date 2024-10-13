using DriverETCSApp.Design;
using DriverETCSApp.Data;

namespace DriverETCSApp.Forms.DForms
{
    partial class TrainDataInfoForm
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
            this.labelData1 = new System.Windows.Forms.Label();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.infoLabelData4 = new System.Windows.Forms.Label();
            this.infoLabelData3 = new System.Windows.Forms.Label();
            this.infoLabelData2 = new System.Windows.Forms.Label();
            this.infoLabel4 = new System.Windows.Forms.Label();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.infoLabelData1 = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sprawdź dane pociągu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelData1
            // 
            this.labelData1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.labelData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelData1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelData1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.labelData1.Location = new System.Drawing.Point(668, 0);
            this.labelData1.Name = "labelData1";
            this.labelData1.Size = new System.Drawing.Size(612, 100);
            this.labelData1.TabIndex = 14;
            this.labelData1.Text = "TAK";
            this.labelData1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonNo
            // 
            this.buttonNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNo.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.buttonNo.Location = new System.Drawing.Point(668, 600);
            this.buttonNo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(204, 100);
            this.buttonNo.TabIndex = 35;
            this.buttonNo.Text = "NIE";
            this.buttonNo.UseVisualStyleBackColor = true;
            // 
            // buttonYes
            // 
            this.buttonYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYes.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.buttonYes.Location = new System.Drawing.Point(872, 600);
            this.buttonYes.Margin = new System.Windows.Forms.Padding(0);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(204, 100);
            this.buttonYes.TabIndex = 36;
            this.buttonYes.Text = "TAK";
            this.buttonYes.UseVisualStyleBackColor = true;
            // 
            // infoLabelData4
            // 
            this.infoLabelData4.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData4.Location = new System.Drawing.Point(341, 310);
            this.infoLabelData4.Name = "infoLabelData4";
            this.infoLabelData4.Size = new System.Drawing.Size(327, 29);
            this.infoLabelData4.TabIndex = 51;
            this.infoLabelData4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabelData3
            // 
            this.infoLabelData3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData3.Location = new System.Drawing.Point(341, 270);
            this.infoLabelData3.Name = "infoLabelData3";
            this.infoLabelData3.Size = new System.Drawing.Size(327, 29);
            this.infoLabelData3.TabIndex = 50;
            this.infoLabelData3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabelData2
            // 
            this.infoLabelData2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData2.Location = new System.Drawing.Point(341, 230);
            this.infoLabelData2.Name = "infoLabelData2";
            this.infoLabelData2.Size = new System.Drawing.Size(327, 29);
            this.infoLabelData2.TabIndex = 49;
            this.infoLabelData2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabel4
            // 
            this.infoLabel4.AutoSize = true;
            this.infoLabel4.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel4.Location = new System.Drawing.Point(33, 310);
            this.infoLabel4.Name = "infoLabel4";
            this.infoLabel4.Size = new System.Drawing.Size(282, 29);
            this.infoLabel4.TabIndex = 48;
            this.infoLabel4.Text = "Prędkość max. (km/h)";
            this.infoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabel3
            // 
            this.infoLabel3.AutoSize = true;
            this.infoLabel3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel3.Location = new System.Drawing.Point(65, 270);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(250, 29);
            this.infoLabel3.TabIndex = 47;
            this.infoLabel3.Text = "Rz. % masy hamuj.";
            this.infoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel2.Location = new System.Drawing.Point(153, 230);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(162, 29);
            this.infoLabel2.TabIndex = 46;
            this.infoLabel2.Text = "Długość (m)";
            this.infoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabelData1
            // 
            this.infoLabelData1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabelData1.Location = new System.Drawing.Point(341, 190);
            this.infoLabelData1.Name = "infoLabelData1";
            this.infoLabelData1.Size = new System.Drawing.Size(327, 29);
            this.infoLabelData1.TabIndex = 45;
            this.infoLabelData1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel1.Location = new System.Drawing.Point(189, 190);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(126, 29);
            this.infoLabel1.TabIndex = 44;
            this.infoLabel1.Text = "Kategoria";
            this.infoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckTrainDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1280, 900);
            this.Controls.Add(this.infoLabelData4);
            this.Controls.Add(this.infoLabelData3);
            this.Controls.Add(this.infoLabelData2);
            this.Controls.Add(this.infoLabel4);
            this.Controls.Add(this.infoLabel3);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.infoLabelData1);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.labelData1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Name = "CheckTrainDataForm";
            this.Text = "BigDFormMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label labelData1;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Label infoLabelData4;
        private System.Windows.Forms.Label infoLabelData3;
        private System.Windows.Forms.Label infoLabelData2;
        private System.Windows.Forms.Label infoLabel4;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.Label infoLabelData1;
        private System.Windows.Forms.Label infoLabel1;
    }
}