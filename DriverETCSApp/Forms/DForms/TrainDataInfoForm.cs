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
    public partial class TrainDataInfoForm : BorderLessForm
    {
        private MainForm MainForm;
        public TrainDataInfoForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
    }
}
