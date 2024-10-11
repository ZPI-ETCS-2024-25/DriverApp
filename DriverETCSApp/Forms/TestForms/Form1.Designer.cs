namespace DriverETCSApp {
    partial class Form1 {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent() {
            this.lblDebug = new System.Windows.Forms.Label();
            this.btnSendUnity = new System.Windows.Forms.Button();
            this.btnSendServer = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(63, 89);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(68, 13);
            this.lblDebug.TabIndex = 0;
            this.lblDebug.Text = "Debug Label";
            // 
            // btnSendUnity
            // 
            this.btnSendUnity.Location = new System.Drawing.Point(12, 12);
            this.btnSendUnity.Name = "btnSendUnity";
            this.btnSendUnity.Size = new System.Drawing.Size(172, 24);
            this.btnSendUnity.TabIndex = 1;
            this.btnSendUnity.Text = "send message to Unity";
            this.btnSendUnity.UseVisualStyleBackColor = true;
            this.btnSendUnity.Click += new System.EventHandler(this.btnSendUnity_Click);
            // 
            // btnSendServer
            // 
            this.btnSendServer.Location = new System.Drawing.Point(12, 42);
            this.btnSendServer.Name = "btnSendServer";
            this.btnSendServer.Size = new System.Drawing.Size(172, 24);
            this.btnSendServer.TabIndex = 2;
            this.btnSendServer.Text = "send message to Server";
            this.btnSendServer.UseVisualStyleBackColor = true;
            this.btnSendServer.Click += new System.EventHandler(this.btnSendServer_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(213, 12);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(172, 24);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "start listening for messages";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 562);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.btnSendServer);
            this.Controls.Add(this.btnSendUnity);
            this.Controls.Add(this.lblDebug);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Button btnSendUnity;
        private System.Windows.Forms.Button btnSendServer;
        private System.Windows.Forms.Button btnListen;
    }
}

