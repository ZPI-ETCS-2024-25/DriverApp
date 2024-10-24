namespace DriverETCSApp.Forms.EForms {
    partial class MessagesForm {
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
            this.buttonDown = new System.Windows.Forms.Button();
            this.messagebox = new System.Windows.Forms.RichTextBox();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonTest2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.Color.Transparent;
            this.buttonDown.Image = global::DriverETCSApp.Properties.Resources.DOWNGray;
            this.buttonDown.Location = new System.Drawing.Point(592, 101);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(64, 64);
            this.buttonDown.TabIndex = 0;
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // messagebox
            // 
            this.messagebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.messagebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messagebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.messagebox.ForeColor = System.Drawing.Color.White;
            this.messagebox.Location = new System.Drawing.Point(77, 3);
            this.messagebox.Name = "messagebox";
            this.messagebox.Size = new System.Drawing.Size(514, 185);
            this.messagebox.TabIndex = 3;
            this.messagebox.Text = "";
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.Color.Transparent;
            this.buttonUp.FlatAppearance.BorderSize = 0;
            this.buttonUp.Image = global::DriverETCSApp.Properties.Resources.UPGray;
            this.buttonUp.Location = new System.Drawing.Point(592, 23);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(64, 64);
            this.buttonUp.TabIndex = 4;
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(12, 33);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(59, 44);
            this.buttonTest.TabIndex = 5;
            this.buttonTest.Text = "add message";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonTest2
            // 
            this.buttonTest2.Location = new System.Drawing.Point(12, 111);
            this.buttonTest2.Name = "buttonTest2";
            this.buttonTest2.Size = new System.Drawing.Size(59, 44);
            this.buttonTest2.TabIndex = 6;
            this.buttonTest2.Text = "delete message";
            this.buttonTest2.UseVisualStyleBackColor = true;
            this.buttonTest2.Click += new System.EventHandler(this.buttonTest2_Click);
            // 
            // MessagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(668, 200);
            this.Controls.Add(this.buttonTest2);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.messagebox);
            this.Controls.Add(this.buttonDown);
            this.Name = "MessagesForm";
            this.Text = "MessagesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.RichTextBox messagebox;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonTest2;
    }
}