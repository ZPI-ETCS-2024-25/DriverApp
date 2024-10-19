using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DriverETCSApp.Forms.GForms
{
    public partial class ClockForm : BorderLessForm
    {
        private System.Threading.Timer clockTimer;
        public ClockForm()
        {
            InitializeComponent();
            clockTimer = new System.Threading.Timer(PrintClock, null, 0, 1000);
        }

        private void PrintClock(object sender)
        {
            Invoke(new Action(() =>
            {
                clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            }));
        }
    }
}
