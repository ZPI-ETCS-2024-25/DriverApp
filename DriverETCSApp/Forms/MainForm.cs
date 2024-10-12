using DriverETCSApp.Forms.DForms;
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

        //Block keyboards
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }

        private void DrawDefaulFormsInPanels()
        {
            DrawDFormIDDriver(false);
            DrawYZFormDefault();
        }

        private void HideGFPanels()
        {
            gPanel.Visible = false;
            fPanel.Visible = false;
            dPanel.Width = 612;
            dPanel.Height = 900;
        }

        public void SetFullScreen()
        {
            aPanel.Visible = false;
            bPanel.Visible = false;
            cPanel.Visible = false;
            ePanel.Visible = false;
            dPanel.Width = 1280;
            dPanel.Height = 900;
            dPanel.Location = new Point(0, 30);
        }

        public void HideFullScreen()
        {
            aPanel.Visible = true;
            bPanel.Visible = true;
            cPanel.Visible = true;
            ePanel.Visible = true;
            dPanel.Width = 612;
            dPanel.Height = 900;
            dPanel.Location = new Point(668, 30);
        }

        public void DrawYZFormDefault()
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

        public void DrawDFormIDDriver(bool isActive = true)
        {
            HideGFPanels();
            dForm = new IDDriverForm(this, isActive);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawDFormETCSLevel(bool isActive = true)
        {
            HideGFPanels();
            dForm = new ETCSLevelForm(this, isActive);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawDFromTrainNumer()
        {
            HideGFPanels();
            dForm = new TrainNumberForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawDFormMenu()
        {
            HideGFPanels();
            dForm = new MenuForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawTrainDataCategoryForm()
        {
            dForm = new TrainDataTypeForm(this);
            dForm.TopLevel = false;
            SetFullScreen();
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawTrainDataInput()
        {
            dForm = new TrainDataForm(this);
            dForm.TopLevel = false;
            SetFullScreen();
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }
    }
}
