using DriverETCSApp.Design;
using DriverETCSApp.Data;

namespace DriverETCSApp.Forms.DForms
{
    partial class SettingsForm
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
            this.buttonDeleteVBC = new System.Windows.Forms.Button();
            this.buttonAddVBC = new System.Windows.Forms.Button();
            this.buttonBrightness = new System.Windows.Forms.Button();
            this.buttonVersion = new System.Windows.Forms.Button();
            this.buttonSound = new System.Windows.Forms.Button();
            this.buttonLanguage = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureLanguage = new System.Windows.Forms.PictureBox();
            this.pictureBoxSound = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLanguage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSound)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ustawienia";
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.closeButton.Location = new System.Drawing.Point(0, 800);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(164, 100);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // buttonDeleteVBC
            // 
            this.buttonDeleteVBC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonDeleteVBC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonDeleteVBC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonDeleteVBC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteVBC.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteVBC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.buttonDeleteVBC.Location = new System.Drawing.Point(306, 340);
            this.buttonDeleteVBC.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDeleteVBC.Name = "buttonDeleteVBC";
            this.buttonDeleteVBC.Size = new System.Drawing.Size(306, 100);
            this.buttonDeleteVBC.TabIndex = 7;
            this.buttonDeleteVBC.Text = "Usuń VBC";
            this.buttonDeleteVBC.UseVisualStyleBackColor = true;
            // 
            // buttonAddVBC
            // 
            this.buttonAddVBC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonAddVBC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonAddVBC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonAddVBC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddVBC.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddVBC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.buttonAddVBC.Location = new System.Drawing.Point(0, 340);
            this.buttonAddVBC.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddVBC.Name = "buttonAddVBC";
            this.buttonAddVBC.Size = new System.Drawing.Size(306, 100);
            this.buttonAddVBC.TabIndex = 5;
            this.buttonAddVBC.Text = "Dodaj VBC";
            this.buttonAddVBC.UseVisualStyleBackColor = true;
            // 
            // buttonBrightness
            // 
            this.buttonBrightness.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonBrightness.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonBrightness.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonBrightness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrightness.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBrightness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.buttonBrightness.Location = new System.Drawing.Point(0, 240);
            this.buttonBrightness.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBrightness.Name = "buttonBrightness";
            this.buttonBrightness.Size = new System.Drawing.Size(306, 100);
            this.buttonBrightness.TabIndex = 10;
            this.buttonBrightness.UseVisualStyleBackColor = true;
            // 
            // buttonVersion
            // 
            this.buttonVersion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonVersion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonVersion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVersion.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.buttonVersion.Location = new System.Drawing.Point(306, 240);
            this.buttonVersion.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVersion.Name = "buttonVersion";
            this.buttonVersion.Size = new System.Drawing.Size(306, 100);
            this.buttonVersion.TabIndex = 9;
            this.buttonVersion.Text = "Wersja systemu";
            this.buttonVersion.UseVisualStyleBackColor = true;
            // 
            // buttonSound
            // 
            this.buttonSound.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSound.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.buttonSound.Location = new System.Drawing.Point(306, 140);
            this.buttonSound.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSound.Name = "buttonSound";
            this.buttonSound.Size = new System.Drawing.Size(306, 100);
            this.buttonSound.TabIndex = 13;
            this.buttonSound.UseVisualStyleBackColor = true;
            // 
            // buttonLanguage
            // 
            this.buttonLanguage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(57)))));
            this.buttonLanguage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonLanguage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.buttonLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLanguage.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.buttonLanguage.Location = new System.Drawing.Point(0, 140);
            this.buttonLanguage.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLanguage.Name = "buttonLanguage";
            this.buttonLanguage.Size = new System.Drawing.Size(306, 100);
            this.buttonLanguage.TabIndex = 11;
            this.buttonLanguage.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DriverETCSApp.Properties.Resources.Brightness;
            this.pictureBox3.Location = new System.Drawing.Point(121, 258);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureLanguage
            // 
            this.pictureLanguage.Image = global::DriverETCSApp.Properties.Resources.Language;
            this.pictureLanguage.Location = new System.Drawing.Point(121, 158);
            this.pictureLanguage.Name = "pictureLanguage";
            this.pictureLanguage.Size = new System.Drawing.Size(64, 64);
            this.pictureLanguage.TabIndex = 15;
            this.pictureLanguage.TabStop = false;
            // 
            // pictureBoxSound
            // 
            this.pictureBoxSound.Image = global::DriverETCSApp.Properties.Resources.Sound;
            this.pictureBoxSound.Location = new System.Drawing.Point(427, 158);
            this.pictureBoxSound.Name = "pictureBoxSound";
            this.pictureBoxSound.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxSound.TabIndex = 14;
            this.pictureBoxSound.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(612, 900);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureLanguage);
            this.Controls.Add(this.pictureBoxSound);
            this.Controls.Add(this.buttonSound);
            this.Controls.Add(this.buttonLanguage);
            this.Controls.Add(this.buttonBrightness);
            this.Controls.Add(this.buttonVersion);
            this.Controls.Add(this.buttonDeleteVBC);
            this.Controls.Add(this.buttonAddVBC);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "BigDFormMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLanguage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button buttonDeleteVBC;
        private System.Windows.Forms.Button buttonAddVBC;
        private System.Windows.Forms.Button buttonBrightness;
        private System.Windows.Forms.Button buttonVersion;
        private System.Windows.Forms.Button buttonSound;
        private System.Windows.Forms.Button buttonLanguage;
        private System.Windows.Forms.PictureBox pictureBoxSound;
        private System.Windows.Forms.PictureBox pictureLanguage;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}