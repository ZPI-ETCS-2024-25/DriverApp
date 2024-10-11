using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp.Forms
{
    public partial class MainForm : Form
    {
        private BorderLessForm aForm;
        private BorderLessForm bForm;
        private BorderLessForm cForm;
        private BorderLessForm dForm;
        private BorderLessForm eForm;
        private BorderLessForm fForm;
        private BorderLessForm gForm;
        private BorderLessForm yForm;
        private BorderLessForm zForm;

        public MainForm()
        {
            InitializeComponent();
            DrawDefaulFormsInPanels();
        }

        private void DrawDefaulFormsInPanels()
        {
            gPanel.Visible = false;
            fPanel.Visible = false;
            dPanel.Width = 612;
            dPanel.Height = 900;

            DrawYZFormDefault();
        }

        private void DrawYZFormDefault()
        {
            yForm = new YZForm();
            yForm.TopLevel = false;
            yPanel.Controls.Add(yForm);
            yForm.Show();

            zForm = new YZForm();
            zForm.TopLevel = false;
            zPanel.Controls.Add(zForm);
            zForm.Show();
        }
    }
}
