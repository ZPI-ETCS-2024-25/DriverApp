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
using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;
using DriverETCSApp.Design;

namespace DriverETCSApp.Forms.DForms
{
    public partial class CheckTrainDataForm : BorderLessForm
    {
        private MainForm MainForm;
        private string TrainCat;
        private string Length;
        private string VMax;
        private string BrakingMass;
        private ServerSender ServerSender;

        public CheckTrainDataForm(MainForm mainForm, string trainCat, string length, string vmax, string brakingMass, ServerSender serverSender)
        {
            InitializeComponent();
            MainForm = mainForm;
            TrainCat = trainCat;
            Length = length;
            VMax = vmax;
            BrakingMass = brakingMass;
            ServerSender = serverSender;

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

        private async void labelData1_Click(object sender, EventArgs e)
        {
            if (labelData1.Text.Equals("TAK"))
            {
                await Data.TrainData.TrainDataSemaphofe.WaitAsync();
                try
                {
                    TrainData.TrainCat = TrainCat;
                    TrainData.Length = Length;
                    TrainData.BrakingMass = BrakingMass;
                    TrainData.VMax = VMax;

                    if (Data.TrainData.IsTrainRegisterOnServer)
                    {
                        await ServerSender.UpdateTrainData(TrainData.TrainNumber);
                    }
                }
                finally
                {
                    Data.TrainData.TrainDataSemaphofe.Release();
                }

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
