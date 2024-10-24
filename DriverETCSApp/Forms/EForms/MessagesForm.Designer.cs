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
            this.messagebox = new System.Windows.Forms.RichTextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonTest2 = new System.Windows.Forms.Button();
            this.RBCConnectionPicture = new System.Windows.Forms.PictureBox();
            this.buttonUP = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RBCConnectionPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // messagebox
            // 
            this.messagebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.messagebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messagebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.messagebox.ForeColor = System.Drawing.Color.White;
            this.messagebox.Location = new System.Drawing.Point(105, 3);
            this.messagebox.Name = "messagebox";
            this.messagebox.Size = new System.Drawing.Size(468, 200);
            this.messagebox.TabIndex = 3;
            this.messagebox.Text = "";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(12, 85);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(59, 44);
            this.buttonTest.TabIndex = 5;
            this.buttonTest.Text = "add message";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonTest2
            // 
            this.buttonTest2.Location = new System.Drawing.Point(12, 135);
            this.buttonTest2.Name = "buttonTest2";
            this.buttonTest2.Size = new System.Drawing.Size(59, 44);
            this.buttonTest2.TabIndex = 6;
            this.buttonTest2.Text = "delete message";
            this.buttonTest2.UseVisualStyleBackColor = true;
            this.buttonTest2.Click += new System.EventHandler(this.buttonTest2_Click);
            // 
            // RBCConnectionPicture
            // 
            this.RBCConnectionPicture.Image = global::DriverETCSApp.Properties.Resources.ConnectionSet;
            this.RBCConnectionPicture.Location = new System.Drawing.Point(1, 3);
            this.RBCConnectionPicture.Name = "RBCConnectionPicture";
            this.RBCConnectionPicture.Size = new System.Drawing.Size(104, 42);
            this.RBCConnectionPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.RBCConnectionPicture.TabIndex = 12;
            this.RBCConnectionPicture.TabStop = false;
            // 
            // buttonUP
            // 
            this.buttonUP.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonUP.Image = global::DriverETCSApp.Properties.Resources.UPGray;
            this.buttonUP.Location = new System.Drawing.Point(573, 3);
            this.buttonUP.Name = "buttonUP";
            this.buttonUP.Size = new System.Drawing.Size(92, 100);
            this.buttonUP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonUP.TabIndex = 13;
            this.buttonUP.TabStop = false;
            this.buttonUP.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::DriverETCSApp.Properties.Resources.DOWNGray;
            this.pictureBox1.Location = new System.Drawing.Point(573, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // MessagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(668, 200);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonUP);
            this.Controls.Add(this.RBCConnectionPicture);
            this.Controls.Add(this.buttonTest2);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.messagebox);
            this.Name = "MessagesForm";
            this.Text = "MessagesForm";
            ((System.ComponentModel.ISupportInitialize)(this.RBCConnectionPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox messagebox;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonTest2;
        private System.Windows.Forms.PictureBox RBCConnectionPicture;
        private System.Windows.Forms.PictureBox buttonUP;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}