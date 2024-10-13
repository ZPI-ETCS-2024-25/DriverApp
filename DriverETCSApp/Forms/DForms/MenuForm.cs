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
    public partial class MenuForm : BorderLessForm
    {
        private MainForm MainForm;
        private bool IsStartActive;

        public MenuForm(MainForm mainForm)
        {
            InitializeComponent();
            SetStartButtonColor();
            MainForm = mainForm;
        }

        public void SetStartButtonColor()
        {
            if(!string.IsNullOrEmpty(TrainData.TrainNumber) && !string.IsNullOrEmpty(TrainData.IDDriver) && !string.IsNullOrEmpty(TrainData.ETCSLevel))
            {
                if(!string.IsNullOrEmpty(TrainData.TrainCat) && !string.IsNullOrEmpty(TrainData.BrakingMass) 
                    && !string.IsNullOrEmpty(TrainData.Length) && !string.IsNullOrEmpty(TrainData.VMax))
                {
                    IsStartActive = true;
                    buttonStart.ForeColor = Design.DMIColors.Grey;
                }
                else
                {
                    IsStartActive = false;
                    buttonStart.ForeColor = Design.DMIColors.DarkGrey;
                }
            }
            else
            {
                IsStartActive = false;
                buttonStart.ForeColor = Design.DMIColors.DarkGrey;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsStartActive)
            {
                Close();
                MainForm.ShowGFPanels();
                MainForm.DrawGForm();
                MainForm.DrawFForm();
                MainForm.DrawMainDForm();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawDFormIDDriver();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawTrainDataCategoryForm();
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
