﻿using System;
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
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Events;
using DriverETCSApp.Logic.Calculations;

namespace DriverETCSApp.Forms.DForms
{
    public partial class CheckTrainTypeDataForm : BorderLessForm
    {
        private MainForm MainForm;
        private PredefinedTrain TrainData;
        private ServerSender ServerSender;

        public CheckTrainTypeDataForm(MainForm mainForm, PredefinedTrain trainData, ServerSender serverSender)
        {
            InitializeComponent();
            MainForm = mainForm;
            TrainData = trainData;
            infoLabelData1.Text = trainData.TrainName;
            ServerSender = serverSender;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.HideFullScreen();
            MainForm.DrawDFormMenu();
            MainForm.DrawAFormPIM();
            MainForm.DrawBFormSpeed();
            MainForm.DrawCForm();
            MainForm.DrawEFormMessages();
        }

        private async void labelData1_Click(object sender, EventArgs e)
        {
            if (labelData1.Text.Equals("TAK"))
            {
                await Data.TrainData.TrainDataSemaphofe.WaitAsync();
                try
                {
                    Data.TrainData.TrainType = TrainData.TrainName;
                    Data.TrainData.TrainCat = TrainData.TrainCat;
                    Data.TrainData.Length = TrainData.Length;
                    Data.TrainData.VMax = TrainData.VMax;
                    Data.TrainData.BrakingMass = TrainData.BrakingMass;
                    MaxSpeedsCalculation.SetBrakingAcceleration(Double.Parse(TrainData.BrakingMass));

                    if (Data.TrainData.IsTrainRegisterOnServer && Data.TrainData.IsConnectionWorking)
                    {
                        await ServerSender.UpdateTrainData(Data.TrainData.TrainNumber);
                    }
                    ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "Wprowadzono dane pociągu"));
                }
                finally
                {
                    Data.TrainData.TrainDataSemaphofe.Release();
                }

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
                MainForm.DrawAFormPIM();
                MainForm.DrawBFormSpeed();
                MainForm.DrawCForm();
                MainForm.DrawEFormMessages();
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
