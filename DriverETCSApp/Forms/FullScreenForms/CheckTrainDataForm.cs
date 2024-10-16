using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriverETCSApp.Data;
using DriverETCSApp.Design;

namespace DriverETCSApp.Forms.DForms
{
    public partial class CheckTrainDataForm : BorderLessForm
    {
        private MainForm MainForm;
        public string TrainCat;
        public string Length;
        public string VMax;
        public string BrakingMass;

        public CheckTrainDataForm(MainForm mainForm, string trainCat, string length, string vmax, string brakingMass)
        {
            InitializeComponent();
            MainForm = mainForm;
            TrainCat = trainCat;
            Length = length;
            VMax = vmax;
            BrakingMass = brakingMass;

            infoLabelData1.Text = trainCat;
            infoLabelData2.Text = length;
            infoLabelData3.Text = brakingMass;
            infoLabelData4.Text = vmax;
        }

        //protected override void PaintForm(object sender, PaintEventArgs e) { }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.HideFullScreen();
            MainForm.DrawDFormMenu();
            MainForm.DrawBFormSpeed();
        }

        private void labelData1_Click(object sender, EventArgs e)
        {
            if (labelData1.Text.Equals("TAK"))
            {
                TrainData.TrainCat = TrainCat;
                TrainData.Length = Length;
                TrainData.BrakingMass = BrakingMass;
                TrainData.VMax = VMax;

                Close();
                MainForm.HideFullScreen();

                if (!string.IsNullOrEmpty(TrainData.TrainNumber))
                {
                    MainForm.DrawDFormMenu();
                }
                else
                {
                    MainForm.DrawDFromTrainNumer();
                }
                MainForm.DrawBFormSpeed();
            }
            else
            {
                Close();
                MainForm.DrawTrainDataInput();
            }
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            labelData1.Text = "TAK";
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            labelData1.Text = "NIE";
        }
    }
}
