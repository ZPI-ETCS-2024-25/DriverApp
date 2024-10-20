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
        private System.Threading.Timer ClockTimer;
        private bool IsFormClosing;

        public ClockForm()
        {
            InitializeComponent();
            IsFormClosing = false;
            ClockTimer = new System.Threading.Timer(PrintClock, null, 0, 500);
            FormClosing += ClockFormClosing;
        }

        private void PrintClock(object sender)
        {
            Invoke(new Action(() =>
            {
                if (!IsDisposed && !Disposing)
                {
                    clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
                }
            }));
        }

        private void ClockFormClosing(object sender, FormClosingEventArgs e)
        {
            IsFormClosing = true;
            ClockTimer?.Dispose();
        }
    }
}
