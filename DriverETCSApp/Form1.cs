using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnSendUnity_Click(object sender, EventArgs e) {
            Console.WriteLine("start sending to Unity");
            SenderHTTP senderHttp = new SenderHTTP("127.0.0.1");
            senderHttp.SendMessage("Hello From Driver", Port.Unity);
            lblDebug.Text += "\nMessage sent to Unity (see more info in console)";
        }

        private void btnSendServer_Click(object sender, EventArgs e) {
            Console.WriteLine("start sending to Server");
            SenderHTTP senderHttp = new SenderHTTP("127.0.0.1");
            senderHttp.SendMessage("Hello From Driver", Port.Server);
            lblDebug.Text += "\nMessage sent to Server (see more info in console)";
        }
    }
}
