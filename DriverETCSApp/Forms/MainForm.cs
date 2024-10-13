using DriverETCSApp.Data;
using DriverETCSApp.Forms;
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
            DrawBFormSpeed();
            DrawYZFormDefault();
        }

        public void HideGFPanels()
        {
            MainPanel.SuspendLayout();
            gPanel.Visible = false;
            fPanel.Visible = false;
            gForm?.Close();
            fForm?.Close();
            dPanel.Width = 612;
            dPanel.Height = 900;
            MainPanel.ResumeLayout(true);
        }

        public void ShowGFPanels()
        {
            MainPanel.SuspendLayout();
            gPanel.Visible = true;
            fPanel.Visible = true;
            dPanel.Width = 492;
            dPanel.Height = 600;
            MainPanel.ResumeLayout(true);
        }

        public void SetFullScreen()
        {
            MainPanel.SuspendLayout();
            aPanel.Visible = false;
            bPanel.Visible = false;
            cPanel.Visible = false;
            ePanel.Visible = false;
            aForm?.Close();
            bForm?.Close();
            cForm?.Close();
            eForm?.Close();
            dPanel.Width = 1280;
            dPanel.Height = 900;
            dPanel.Location = new Point(0, 30);
            MainPanel.ResumeLayout(true);
        }

        public void HideFullScreen()
        {
            MainPanel.SuspendLayout();
            aPanel.Visible = true;
            bPanel.Visible = true;
            cPanel.Visible = true;
            ePanel.Visible = true;
            dPanel.Width = 612;
            dPanel.Height = 900;
            dPanel.Location = new Point(668, 30);
            MainPanel.ResumeLayout(true);
        }

        public void DrawYZFormDefault()
        {
            MainPanel.SuspendLayout();
            yForm = new YZForm();
            yForm.TopLevel = false;
            yPanel.Controls.Add(yForm);
            yForm.Show();

            zForm = new YZForm();
            zForm.TopLevel = false;
            zPanel.Controls.Add(zForm);
            zForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawBFormSpeed() {
            bForm = new BForms.SpeedmeterForm();
            bForm.TopLevel = false;
            bPanel.Controls.Add(bForm);
            bForm.Show();
        }

        public void DrawDFormIDDriver(bool isActive = true)
        {
            MainPanel.SuspendLayout();
            HideGFPanels();
            dForm = new DForms.IDDriverForm(this, isActive);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawDFormETCSLevel(bool isActive = true)
        {
            MainPanel.SuspendLayout();
            HideGFPanels();
            dForm = new DForms.ETCSLevelForm(this, isActive);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawDFromTrainNumer()
        {
            MainPanel.SuspendLayout();
            HideGFPanels();
            dForm = new DForms.TrainNumberForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawDFormMenu()
        {
            MainPanel.SuspendLayout();
            HideGFPanels();
            dForm?.Close();
            dForm = new DForms.MenuForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawTrainDataCategoryForm()
        {
            MainPanel.SuspendLayout();
            dForm = new DForms.TrainDataTypeForm(this);
            dForm.TopLevel = false;
            SetFullScreen();
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawTrainDataInput()
        {
            MainPanel.SuspendLayout();
            dForm = new DForms.TrainDataForm(this);
            dForm.TopLevel = false;
            SetFullScreen();
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawTrainDataTypeConfirm(PredefinedTrain trainData)
        {
            MainPanel.SuspendLayout();
            dForm = new DForms.CheckTrainTypeDataForm(this, trainData);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawTrainDataConfirm(string trainCat, string length, string vmax, string brakingMass)
        {
            MainPanel.SuspendLayout();
            dForm = new DForms.CheckTrainDataForm(this, trainCat, length, vmax, brakingMass);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawSettings(bool isFromDriverID, bool driverIDActiveFlag = true)
        {
            MainPanel.SuspendLayout();
            dForm?.Close();
            dForm = new DForms.SettingsForm(this, isFromDriverID, driverIDActiveFlag);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawMainDForm()
        {
            MainPanel.SuspendLayout();
            dForm = new DForms.MainDForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawTrainDataInfoForm()
        {
            MainPanel.SuspendLayout();
            dForm?.Close();
            dForm = new DForms.InfoTrainDataForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawGForm()
        {
            MainPanel.SuspendLayout();
            gForm = new GForms.ClockForm();
            gForm.TopLevel = false;
            gPanel.Controls.Add(gForm);
            gForm.Show();
            MainPanel.ResumeLayout(true);
        }

        public void DrawFForm()
        {
            MainPanel.SuspendLayout();
            fForm = new FForms.ToolbarForm(this);
            fForm.TopLevel = false;
            fPanel.Controls.Add(fForm);
            fForm.Show();
            MainPanel.ResumeLayout(true);
        }
    }
}
