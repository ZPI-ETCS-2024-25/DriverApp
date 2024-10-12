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
    public partial class TrainNumberForm : BorderLessForm
    {
        private MainForm MainForm;

        public TrainNumberForm(MainForm mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
            label2.Text = TrainData.TrainNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label2.Text += "9";
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
            label2.Text += "0";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(label2.Text))
            {
                TrainData.TrainNumber = label2.Text;
                Close();
                MainForm.DrawDFormMenu();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawDFormMenu();
        }
    }
}
