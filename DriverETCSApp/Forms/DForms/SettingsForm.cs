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
        private bool IsFromDriverID;
        private bool DriverIDActiveFlag;

        public SettingsForm(MainForm mainForm, bool isFromDriverID, bool driverIDActiveFlag = true)
        {
            InitializeComponent();
            MainForm = mainForm;
            IsFromDriverID = isFromDriverID;
            DriverIDActiveFlag = driverIDActiveFlag;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            switch (IsFromDriverID)
            {
                case true:
                    MainForm.DrawDFormIDDriver(DriverIDActiveFlag);
                    break;

                case false:
                    MainForm.ShowGFPanels();
                    MainForm.DrawGForm();
                    MainForm.DrawFForm();
                    MainForm.DrawMainDForm();
                    break;
            }
        }
    }
}
