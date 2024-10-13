using DriverETCSApp.Design;
using DriverETCSApp.Data;

namespace DriverETCSApp.Forms.DForms
{
    partial class TrainDataTypeForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.buttonTrainCategory1 = new System.Windows.Forms.Button();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.labelData1 = new System.Windows.Forms.Label();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.labelConfirmation = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.infoLabelData1 = new System.Windows.Forms.Label();
            this.buttonChangeDisplay = new System.Windows.Forms.Button();
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
            this.label1.Text = "Dane pociągu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.closeButton.Location = new System.Drawing.Point(668, 800);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(164, 100);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // buttonTrainCategory1
            // 
            this.buttonTrainCategory1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonTrainCategory1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonTrainCategory1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonTrainCategory1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTrainCategory1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTrainCategory1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.buttonTrainCategory1.Location = new System.Drawing.Point(668, 400);
            this.buttonTrainCategory1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTrainCategory1.Name = "buttonTrainCategory1";
            this.buttonTrainCategory1.Size = new System.Drawing.Size(204, 100);
            this.buttonTrainCategory1.TabIndex = 12;
            this.buttonTrainCategory1.UseVisualStyleBackColor = true;
            this.buttonTrainCategory1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelInfo1
            // 
            this.labelInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.labelInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelInfo1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.labelInfo1.Location = new System.Drawing.Point(668, 0);
            this.labelInfo1.Name = "labelInfo1";
            this.labelInfo1.Size = new System.Drawing.Size(408, 100);
            this.labelInfo1.TabIndex = 13;
            this.labelInfo1.Text = "Rodzaj pociągu";
            this.labelInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelData1
            // 
            this.labelData1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.labelData1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelData1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.labelData1.Location = new System.Drawing.Point(1076, 0);
            this.labelData1.Name = "labelData1";
            this.labelData1.Size = new System.Drawing.Size(204, 100);
            this.labelData1.TabIndex = 14;
            this.labelData1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelData1.Click += new System.EventHandler(this.labelData1_Click);
            // 
            // labelConfirm
            // 
            this.labelConfirm.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.labelConfirm.Location = new System.Drawing.Point(0, 700);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(668, 100);
            this.labelConfirm.TabIndex = 15;
            this.labelConfirm.Text = "Dane pociągu - wprowadzone poprawnie?";
            this.labelConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelConfirmation
            // 
            this.labelConfirmation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.labelConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelConfirmation.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConfirmation.ForeColor = System.Drawing.Color.Black;
            this.labelConfirmation.Location = new System.Drawing.Point(0, 800);
            this.labelConfirmation.Name = "labelConfirmation";
            this.labelConfirmation.Size = new System.Drawing.Size(668, 100);
            this.labelConfirmation.TabIndex = 16;
            this.labelConfirmation.Text = "Tak";
            this.labelConfirmation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelConfirmation.Click += new System.EventHandler(this.labelConfirmation_Click);
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.infoLabel1.Location = new System.Drawing.Point(140, 190);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(195, 29);
            this.infoLabel1.TabIndex = 17;
            this.infoLabel1.Text = "Rodzaj pociągu";
            this.infoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoLabelData1
            // 
            this.infoLabelData1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabelData1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.infoLabelData1.Location = new System.Drawing.Point(341, 190);
            this.infoLabelData1.Name = "infoLabelData1";
            this.infoLabelData1.Size = new System.Drawing.Size(327, 29);
            this.infoLabelData1.TabIndex = 18;
            this.infoLabelData1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonChangeDisplay
            // 
            this.buttonChangeDisplay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonChangeDisplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonChangeDisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonChangeDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeDisplay.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonChangeDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.buttonChangeDisplay.Location = new System.Drawing.Point(1160, 800);
            this.buttonChangeDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.buttonChangeDisplay.Name = "buttonChangeDisplay";
            this.buttonChangeDisplay.Size = new System.Drawing.Size(120, 100);
            this.buttonChangeDisplay.TabIndex = 19;
            this.buttonChangeDisplay.Text = "Wpisz dane";
            this.buttonChangeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChangeDisplay.Click += new System.EventHandler(this.buttonChangeDisplay_Click);
            // 
            // TrainDataTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1280, 900);
            this.Controls.Add(this.buttonChangeDisplay);
            this.Controls.Add(this.infoLabelData1);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.labelConfirmation);
            this.Controls.Add(this.labelConfirm);
            this.Controls.Add(this.labelData1);
            this.Controls.Add(this.labelInfo1);
            this.Controls.Add(this.buttonTrainCategory1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Name = "TrainDataTypeForm";
            this.Text = "BigDFormMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button buttonTrainCategory1;
        private System.Windows.Forms.Label labelInfo1;
        private System.Windows.Forms.Label labelData1;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.Label labelConfirmation;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Label infoLabelData1;
        private System.Windows.Forms.Button buttonChangeDisplay;
    }
}