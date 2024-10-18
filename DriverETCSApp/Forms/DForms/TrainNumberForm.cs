using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;

namespace DriverETCSApp.Forms.DForms
{
    public partial class TrainNumberForm : BorderLessForm
    {
        private MainForm MainForm;
        private ServerSender ServerSender;

        public TrainNumberForm(MainForm mainForm, ServerSender serverSender)
        {
            InitializeComponent();
            MainForm = mainForm;
            ServerSender = serverSender;
            label2.Text = TrainData.TrainNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppendText("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppendText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppendText("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppendText("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AppendText("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AppendText("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AppendText("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AppendText("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AppendText("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(label2.Text))
            {
                label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AppendText("0");
        }

        private async void label2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(label2.Text))
            {
                await Data.TrainData.TrainDataSemaphofe.WaitAsync();
                try
                {
                    var oldNumber = TrainData.TrainNumber;
                    TrainData.TrainNumber = label2.Text;
                    if (Data.TrainData.IsETCSActive)
                    {
                        await ServerSender.UpdateTrainData(oldNumber);
                    }
                }
                finally
                {
                    Data.TrainData.TrainDataSemaphofe.Release();
                }
                Close();
                MainForm.DrawDFormMenu();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawDFormMenu();
        }

        private void AppendText(string s)
        {
            if(label2.Text.Length < 6)
            {
                label2.Text += s;
            }
        }
    }
}
