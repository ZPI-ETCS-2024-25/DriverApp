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
    public partial class CheckTrainTypeDataForm : BorderLessForm
    {
        private MainForm MainForm;
        PredefinedTrain TrainData;

        public CheckTrainTypeDataForm(MainForm mainForm, PredefinedTrain trainData)
        {
            InitializeComponent();
            MainForm = mainForm;
            TrainData = trainData;
            infoLabelData1.Text = trainData.TrainName;
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
                Data.TrainData.TrainType = TrainData.TrainName;
                Data.TrainData.TrainCat = TrainData.TrainCat;
                Data.TrainData.Length = TrainData.Length;
                Data.TrainData.VMax = TrainData.VMax;
                Data.TrainData.BrakingMass = TrainData.BrakingMass;

                Close();
                MainForm.HideFullScreen();

                if (!string.IsNullOrEmpty(Data.TrainData.TrainNumber))
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
                MainForm.DrawTrainDataCategoryForm();
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
