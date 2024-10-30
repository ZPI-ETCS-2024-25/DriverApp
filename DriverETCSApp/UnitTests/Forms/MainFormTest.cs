using DriverETCSApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms
{
    public class MainFormTest
    {
        private MainForm MainForm;

        public MainFormTest()
        {

        }

        private void Create()
        {
            MainForm = new MainForm();
            MainForm.Show();
        }
    }
}
