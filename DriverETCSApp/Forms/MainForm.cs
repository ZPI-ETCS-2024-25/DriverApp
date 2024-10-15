using DriverETCSApp.Data;
using DriverETCSApp.Design;
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
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            CreateBuffer();
            DrawDefaulFormsInPanels();
        }

        private void CreateBuffer()
        {
            ETCSBuffer.BufferedGraphicsContext = BufferedGraphicsManager.Current;
            ETCSBuffer.BufferedGraphicsContext.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            ETCSBuffer.BufferedGraphics = ETCSBuffer.BufferedGraphicsContext.Allocate(this.CreateGraphics(),
                 new Rectangle(0, 0, this.Width, this.Height));
            ETCSBuffer.Graphics = ETCSBuffer.BufferedGraphics.Graphics;
            ETCSBuffer.MainForm = this;
        }

        //Block keyboards
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ETCSBuffer.BufferedGraphics.Render(e.Graphics);
        }

        private void DrawDefaulFormsInPanels()
        {
            DrawDFormIDDriver(false);
            DrawBFormSpeed();
            DrawYZFormDefault();
        }

        public void HideGFPanels()
        {
            gPanel.Visible = false;
            fPanel.Visible = false;
            gForm?.Close();
            fForm?.Close();
            dPanel.Width = 612;
            dPanel.Height = 900;
        }

        public void ShowGFPanels()
        {
            gPanel.Visible = true;
            fPanel.Visible = true;
            dPanel.Width = 492;
            dPanel.Height = 600;
        }

        public void SetFullScreen()
        {
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

        public void DrawBFormSpeed() {
            bForm = new BForms.SpeedmeterForm();
            bForm.TopLevel = false;
            bPanel.Controls.Add(bForm);
            bForm.Show();
        }

        public void DrawDFormIDDriver(bool isActive = true)
        {
            HideGFPanels();
            dForm = new DForms.IDDriverForm(this, isActive);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawDFormETCSLevel(bool isActive = true)
        {
            HideGFPanels();
            dForm = new DForms.ETCSLevelForm(this, isActive);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawDFromTrainNumer()
        {
            HideGFPanels();
            dForm = new DForms.TrainNumberForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawDFormMenu()
        {
            HideGFPanels();
            dForm?.Close();
            dForm = new DForms.MenuForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawTrainDataCategoryForm()
        {
            dForm = new DForms.TrainDataTypeForm(this);
            dForm.TopLevel = false;
            SetFullScreen();
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawTrainDataInput()
        {
            dForm = new DForms.TrainDataForm(this);
            dForm.TopLevel = false;
            SetFullScreen();
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawTrainDataTypeConfirm(PredefinedTrain trainData)
        {
            dForm = new DForms.CheckTrainTypeDataForm(this, trainData);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawTrainDataConfirm(string trainCat, string length, string vmax, string brakingMass)
        {
            dForm = new DForms.CheckTrainDataForm(this, trainCat, length, vmax, brakingMass);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawSettings(bool isFromDriverID, bool driverIDActiveFlag = true)
        {
            dForm?.Close();
            dForm = new DForms.SettingsForm(this, isFromDriverID, driverIDActiveFlag);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawMainDForm()
        {
            dForm = new DForms.MainDForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawTrainDataInfoForm()
        {
            dForm?.Close();
            dForm = new DForms.InfoTrainDataForm(this);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawGForm()
        {
            gForm = new GForms.ClockForm();
            gForm.TopLevel = false;
            gPanel.Controls.Add(gForm);
            gForm.Show();
        }

        public void DrawFForm()
        {
            fForm = new FForms.ToolbarForm(this);
            fForm.TopLevel = false;
            fPanel.Controls.Add(fForm);
            fForm.Show();
        }
    }
}
