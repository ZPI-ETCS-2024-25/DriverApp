using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp
{
    public class BorderLessForm : Form
    {
        public BorderLessForm() : base()
        {
            FormBorderStyle = FormBorderStyle.None;
            //DoubleBuffered = true;
        }
    }
}
