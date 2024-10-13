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
    public partial class InfoTrainDataForm : BorderLessForm
    {
        private MainForm MainForm;

        public InfoTrainDataForm(MainForm mainForm)
        {
            InitializeComponent();
            LoadData();
            MainForm = mainForm;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.DrawMainDForm();
        }

        private void LoadData()
        {
            infoLabelData0.Text = TrainData.TrainType;
            infoLabelData1.Text = TrainData.TrainCat;
            infoLabelData2.Text = TrainData.Length;
            infoLabelData3.Text = TrainData.BrakingMass;
            infoLabelData4.Text = TrainData.VMax;
        }
    }
}
