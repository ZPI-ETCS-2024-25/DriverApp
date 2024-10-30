using DriverETCSApp.Events.ETCSEventArgs;
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

        public ClockForm()
        {
            InitializeComponent();
            ClockTimer = new System.Threading.Timer(PrintClock, null, 0, 500);
            Load += ClockFormLoad;
            FormClosing += ClockFormClosing;
        }

        private void PrintClock(object sender)
        {
            if (IsHandleCreated && !IsDisposed && !Disposing)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        if (!IsDisposed && !Disposing && Created)
                        {
                            clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
                        }
                    }));
                }
                catch { Console.WriteLine("PrintClock(object sender)"); }
            }
        }

        private void ClockFormLoad(object sender, EventArgs e)
        {
            PrintClock(null);
        }

        private void ClockFormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("DELETING CLOCK TIMER");
            ClockTimer.Change(Timeout.Infinite, Timeout.Infinite);
            ClockTimer?.Dispose();
        }

        public string GetPrintedTime()
        {
            return clockLabel.Text;
        }
    }
}
