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
            this.SuspendLayout();
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(597, 111);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(48, 44);
            this.buttonDown.TabIndex = 0;
            this.buttonDown.Text = "\\/";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // messagebox
            // 
            this.messagebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messagebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.messagebox.Location = new System.Drawing.Point(77, 3);
            this.messagebox.Name = "messagebox";
            this.messagebox.Size = new System.Drawing.Size(514, 185);
            this.messagebox.TabIndex = 3;
            this.messagebox.Text = "";
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(597, 44);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(48, 44);
            this.buttonUp.TabIndex = 4;
            this.buttonUp.Text = "/\\";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(12, 76);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(59, 44);
            this.buttonTest.TabIndex = 5;
            this.buttonTest.Text = "add message";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // MessagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(668, 200);
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
    }
}