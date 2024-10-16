using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp.Forms.FForms
{
    public partial class ToolbarForm : BorderLessForm
    {
        private MainForm MainForm;

        public ToolbarForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            MainForm.HideGFPanels();
            MainForm.DrawDFormMenu();
        }

        private void buttonDataView_Click(object sender, EventArgs e)
        {
            MainForm.DrawTrainDataInfoForm();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            MainForm.HideGFPanels();
            MainForm.DrawSettings(false);
        }

        //protected override void PaintForm(object sender, PaintEventArgs e) { }
    }
}
