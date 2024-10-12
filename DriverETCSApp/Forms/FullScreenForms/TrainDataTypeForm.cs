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
using DriverETCSApp.Design;

namespace DriverETCSApp.Forms.DForms
{
    public partial class TrainDataTypeForm : BorderLessForm
    {
        private MainForm MainForm;
        private bool IsConfirmationActive;
        PredefinedTrain trainData;

        public TrainDataTypeForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            infoLabelData1.Text = TrainData.TrainType;
            buttonTrainCategory1.Text = PredefinedTrainData.DefaultTrain.TrainName;
            IsConfirmationActive = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsConfirmationActive = false;
            trainData = PredefinedTrainData.DefaultTrain;
            labelConfirmation.BackColor = DMIColors.DarkGrey;
            infoLabelData1.ForeColor = DMIColors.DarkGrey;
            labelData1.Text = buttonTrainCategory1.Text;
            infoLabelData1.Text = buttonTrainCategory1.Text;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.HideFullScreen();
            MainForm.DrawDFormMenu();
        }

        private void labelData1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(labelData1.Text))
            {
                labelConfirmation.BackColor = DMIColors.White;
                infoLabelData1.ForeColor = DMIColors.Grey;
                IsConfirmationActive = true;
            }
        }

        private void labelConfirmation_Click(object sender, EventArgs e)
        {
            if (IsConfirmationActive)
            {
                TrainData.TrainType = infoLabelData1.Text;
                TrainData.TrainCat = trainData.TrainCat;
                TrainData.Length = trainData.Length;
                TrainData.Weight = trainData.Weight;
                TrainData.BrakingMass = trainData.BrakingMass;

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
            }
        }

        private void buttonChangeDisplay_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawTrainDataInput();
        }
    }
}
