using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp.Forms.GForms
{
    public partial class ClockForm : BorderLessForm
    {
        private Timer clockTimer;
        public ClockForm()
        {
            InitializeComponent();
            CreateClock();
        }

        private void CreateClock()
        {
            clockTimer = new Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += new EventHandler(PrintClock);
            clockTimer.Start();
            PrintClock(this, EventArgs.Empty);
        }

        private void PrintClock(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
