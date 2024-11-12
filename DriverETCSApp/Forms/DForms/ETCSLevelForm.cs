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
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Events;
using DriverETCSApp.Properties;

namespace DriverETCSApp.Forms.DForms
{
    public partial class ETCSLevelForm : BorderLessForm
    {
        private MainForm MainForm;
        private bool IsBackActive;

        public ETCSLevelForm(MainForm mainForm, bool isBackActive)
        {
            InitializeComponent();
            IsBackActive = isBackActive;
            MainForm = mainForm;
            Data.TrainData.TrainDataSemaphofe.WaitAsync();
            label2.Text = TrainData.ETCSLevel;
            Data.TrainData.TrainDataSemaphofe.Release();
            SetCloseButtonColor();
        }

        private void SetCloseButtonColor()
        {
            if (IsBackActive)
            {
                closeButton.ForeColor = Design.DMIColors.Grey;
            }
            else
            {
                closeButton.ForeColor = Design.DMIColors.DarkGrey;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            label2.Text = ETCSLevel.Poziom2;
            TrainData.TrainDataSemaphofe.Release();
        }
        private async void button5_Click(object sender, EventArgs e)
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            label2.Text = ETCSLevel.SHP;
            TrainData.TrainDataSemaphofe.Release();
        }

        private async void label2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(label2.Text))
            {
                await Data.TrainData.TrainDataSemaphofe.WaitAsync();
                TrainData.ETCSLevel = label2.Text;
                ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "Wybrano poziom"));
                SetUpMode();
                Data.TrainData.TrainDataSemaphofe.Release();
                Close();
                MainForm.DrawDFormMenu();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (IsBackActive)
            {
                Close();
                MainForm.DrawDFormMenu();
            }
        }

        private async void SetUpMode()
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                if (!TrainData.IsMisionStarted)
                {
                    if (TrainData.ETCSLevel.Equals(ETCSLevel.Poziom2))
                    {
                        ETCSEvents.OnChangeLevelIcon(new ChangeLevelIcon(Resources.L2));
                    }
                    else
                    {
                        ETCSEvents.OnChangeLevelIcon(new ChangeLevelIcon(Resources.SHP));
                    }
                }
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }
        }
    }
}
