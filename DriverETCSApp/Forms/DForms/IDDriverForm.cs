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

namespace DriverETCSApp.Forms.DForms
{
    public partial class IDDriverForm : BorderLessForm
    {
        private char LastClick;
        private int ClickCounter;
        private DateTime LastClickDate;
        private Dictionary<char, List<char>> AlphaNumerickKeys;
        private MainForm MainForm;
        private bool IsBackActive;

        public IDDriverForm(MainForm mainForm, bool isActive)
        {
            InitializeComponent();

            MainForm = mainForm;
            IsBackActive = isActive;
            label2.Text = TrainData.IDDriver;
            LastClick = ' ';
            ClickCounter = 0;
            LastClickDate = DateTime.Now;
            AlphaNumerickKeys = new Dictionary<char, List<char>> { };
            CreateDictionary();
            SetCloseButtonColor();
        }

        //protected override void PaintForm(object sender, PaintEventArgs e) { }

        private void CreateDictionary()
        {
            AlphaNumerickKeys.Add('2', new List<char> { '2', 'a', 'b', 'c' });
            AlphaNumerickKeys.Add('3', new List<char> { '3', 'd', 'e', 'f' });
            AlphaNumerickKeys.Add('4', new List<char> { '4', 'g', 'h', 'i' });
            AlphaNumerickKeys.Add('5', new List<char> { '5', 'j', 'k', 'l' });
            AlphaNumerickKeys.Add('6', new List<char> { '6', 'm', 'n', 'o' });
            AlphaNumerickKeys.Add('7', new List<char> { '7', 'p', 'q', 'r', 's' });
            AlphaNumerickKeys.Add('8', new List<char> { '8', 't', 'u', 'v' });
            AlphaNumerickKeys.Add('9', new List<char> { '9', 'w', 'x', 'y', 'z' });
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

        private void button1_Click(object sender, EventArgs e)
        {
            newAlphaNumericKeyClicked('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alphaNumericKeyLogic('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alphaNumericKeyLogic('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            alphaNumericKeyLogic('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            alphaNumericKeyLogic('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            alphaNumericKeyLogic('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            alphaNumericKeyLogic('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            alphaNumericKeyLogic('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            alphaNumericKeyLogic('9');
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
            newAlphaNumericKeyClicked('0');
        }

        private async void label2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(label2.Text))
            {
                await Data.TrainData.TrainDataSemaphofe.WaitAsync();
                TrainData.IDDriver = label2.Text;
                ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "Wprowadzono ID Maszynisty"));
                if (string.IsNullOrEmpty(TrainData.ETCSLevel))
                {
                    Close();
                    MainForm.DrawDFormETCSLevel(false);
                }
                else
                {
                    Close();
                    MainForm.DrawDFormMenu();
                }
                Data.TrainData.TrainDataSemaphofe.Release();
            }
        }

        private void alphaNumericKeyLogic(char value)
        {
            if(!LastClick.Equals(value))
            {
                newAlphaNumericKeyClicked(value);
                return;
            }
            
            if((DateTime.Now - LastClickDate).TotalMilliseconds >= 800)
            {
                newAlphaNumericKeyClicked(value);
                return;
            }

            if (!string.IsNullOrEmpty(label2.Text))
            {
                label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
            }
            ClickCounter++;
            LastClickDate = DateTime.Now;
            var a = AlphaNumerickKeys[value][ClickCounter % AlphaNumerickKeys[value].Count];
            label2.Text += AlphaNumerickKeys[value][ClickCounter % AlphaNumerickKeys[value].Count];
        }

        private void newAlphaNumericKeyClicked(char value)
        {
            if (label2.Text.Length < 20)
            {
                LastClick = value;
                LastClickDate = DateTime.Now;
                ClickCounter = 0;
                label2.Text += value;
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

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawSettings(true, IsBackActive);
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawTrainDataCategoryForm();
        }
    }
}
