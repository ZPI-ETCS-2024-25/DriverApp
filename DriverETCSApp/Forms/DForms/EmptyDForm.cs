using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp.Forms.DForms
{

    public partial class EmptyDForm : BorderLessForm
    {
        private MainForm MainForm;

        public EmptyDForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
    }
}
