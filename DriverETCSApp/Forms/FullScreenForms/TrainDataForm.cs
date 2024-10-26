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
    public partial class TrainDataForm : BorderLessForm
    {
        private MainForm MainForm;
        private bool IsConfirmationActive;
        private System.Windows.Forms.Label activeLabel;
        private System.Windows.Forms.Label activeInfoLabel;

        private List<System.Windows.Forms.Label> labelsList;
        private List<System.Windows.Forms.Label> infoLabelsList;
        private List<bool> confirmationChecks;
        private int ID;

        public TrainDataForm(MainForm mainForm)
        {
            InitializeComponent();
            SetCategoryKeys();
            MainForm = mainForm;
            Data.TrainData.TrainDataSemaphofe.WaitAsync();
            infoLabelData1.Text = TrainData.TrainCat;
            infoLabelData2.Text = TrainData.Length;
            infoLabelData3.Text = TrainData.BrakingMass;
            infoLabelData4.Text = TrainData.VMax;
            Data.TrainData.TrainDataSemaphofe.Release();
            IsConfirmationActive = false;

            labelsList = new List<System.Windows.Forms.Label> { labelData1, labelData2, labelData3, labelData4 };
            infoLabelsList = new List<System.Windows.Forms.Label> { infoLabelData1, infoLabelData2, infoLabelData3, infoLabelData4 };
            confirmationChecks = new List<bool> { false, false, false, false };
            ActivateLabel(0);
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

        private void ActivateLabel(int index)
        {
            labelsList[index].ForeColor = DMIColors.DarkGrey;
            labelsList[index].BackColor = DMIColors.Grey;
            activeLabel = labelsList[index];
            activeInfoLabel = infoLabelsList[index];

            activeLabel.Text = activeInfoLabel.Text;
            ID = index;
        }

        private void DeactivateLabel(int index)
        {
            labelsList[index].ForeColor = DMIColors.Grey;
            labelsList[index].BackColor = DMIColors.DarkGrey;
        }

        private void labelConfirmation_Click(object sender, EventArgs e)
        {
            if (IsConfirmationActive)
            {
                var tmp = (infoLabelData1.Text, infoLabelData2.Text, infoLabelData4.Text, infoLabelData3.Text);
                Close();
                MainForm.DrawTrainDataConfirm(tmp.Item1, tmp.Item2, tmp.Item3, tmp.Item4);
            }
        }

        private void SetKeyboard()
        {
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;

            button1.Text = "1";
            button2.Text = "2";
            button3.Text = "3";
            button2.ForeColor = DMIColors.Grey;
            button3.ForeColor = DMIColors.Grey;
        }

        private void SetCategoryKeys()
        {
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;

            button1.Text = "PASS 3";
            button2.Text = "FP 4";
            button3.Text = "FG 4";
            button2.ForeColor = DMIColors.DarkGrey;
            button3.ForeColor = DMIColors.DarkGrey;
        }

        private void buttonChangeDisplay_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawTrainDataCategoryForm();
        }

        #region buttons
        private void button1_Click(object sender, EventArgs e)
        {
            if(activeLabel == labelData1)
            {
                activeLabel.Text = "PASS 3";
                DataChanged();
            }
            else
            {
                AppendText("1");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (activeLabel == labelData1)
            {
                activeLabel.Text = "FP 4";
                DataChanged();
            }
            else
            {
                AppendText("2");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (activeLabel == labelData1)
            {
                activeLabel.Text = "FG 4";
                DataChanged();
            }
            else
            {
                AppendText("3");
            }
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
            if (activeLabel != labelData1)
            {
                activeLabel.Text = activeLabel.Text.Substring(0, activeLabel .Text.Length - 1);
                DataChanged();
            }
        }

        private void DataChanged()
        {
            activeInfoLabel.Text = activeLabel.Text;
            activeInfoLabel.ForeColor = DMIColors.DarkGrey;
            confirmationChecks[ID] = false;
            CheckConfirmation();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AppendText("0");
        }
        #endregion

        private void AppendText(string s)
        {
            if (activeLabel.Text.Length < 3)
            {
                activeLabel.Text += s;
                activeInfoLabel.Text = activeLabel.Text;
                activeInfoLabel.ForeColor = DMIColors.DarkGrey;
                confirmationChecks[ID] = false;
                CheckConfirmation();
            }
        }

        private void labelData1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelData1.Text))
            {
                activeInfoLabel.ForeColor = DMIColors.Grey;
                ActivateLabel(1);
                DeactivateLabel(0);
                SetKeyboard();
                confirmationChecks[0] = true;
                CheckConfirmation();
            }
        }

        private void labelData2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelData2.Text))
            {
                activeInfoLabel.ForeColor = DMIColors.Grey;
                ActivateLabel(2);
                DeactivateLabel(1);
                confirmationChecks[1] = true;
                CheckConfirmation();
            }
        }

        private void labelData3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelData3.Text))
            {
                activeInfoLabel.ForeColor = DMIColors.Grey;
                ActivateLabel(3);
                DeactivateLabel(2);
                confirmationChecks[2] = true;
                CheckConfirmation();
            }
        }

        private void labelData4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelData4.Text))
            {
                activeInfoLabel.ForeColor = DMIColors.Grey;
                ActivateLabel(0);
                DeactivateLabel(3);
                SetCategoryKeys();
                confirmationChecks[3] = true;
                CheckConfirmation();
            }
        }

        private void CheckConfirmation()
        {
            for(int i = 0; i < confirmationChecks.Count; i++)
            {
                if (!confirmationChecks[i])
                {
                    IsConfirmationActive = false;
                    labelConfirmation.BackColor = DMIColors.DarkGrey;
                    return;
                }
                IsConfirmationActive = true;
                labelConfirmation.BackColor = DMIColors.White;
            }
        }
    }
}
