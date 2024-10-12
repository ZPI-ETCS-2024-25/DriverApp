using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriverETCSApp.Data;

namespace DriverETCSApp.Forms.DForms
{
    public partial class SettingsForm : BorderLessForm
    {
        private MainForm MainForm;

        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.ShowGFPanels();
            MainForm.DrawGForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawDFormIDDriver();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawDFormETCSLevel();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawDFromTrainNumer();
        }
    }
}
