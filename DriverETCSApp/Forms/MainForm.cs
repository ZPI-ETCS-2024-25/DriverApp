using DriverETCSApp.Communication;
using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Forms;
using DriverETCSApp.Logic.Position;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp.Forms
{
    public partial class MainForm : Form, IDisposable
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

        private ServerSender ServerSender;
        private ReceiverHTTP ReceiverHTTP;

        private DistancesCalculator DystancesCalculator;

        public MainForm(bool b)
        {
            InitializeComponent();
            DoubleBuffered = true;

            if (b)
            {
                DystancesCalculator = new DistancesCalculator();
                ServerSender = new ServerSender("127.0.0.1", Port.Server);
                ReceiverHTTP = new ReceiverHTTP("127.0.0.1");
                ReceiverHTTP.StartListening();
                DrawDefaulFormsInPanels();
            }
        }

        public new void Dispose()
        {
            base.Dispose();
            aForm?.Dispose();
            bForm?.Dispose();
            cForm?.Dispose();
            dForm?.Dispose();
            eForm?.Dispose();
            fForm?.Dispose();
            gForm?.Dispose();
            yForm?.Dispose();
            zForm?.Dispose();
        }

        //Block keyboards
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }

        private void DrawDefaulFormsInPanels()
        {
            DrawDFormIDDriver(false);
            DrawAFormPIM();
            DrawBFormSpeed();
            DrawCForm();
            DrawEFormMessages();
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
            aForm?.Hide();
            bForm?.Hide();
            cForm?.Hide();
            eForm?.Hide();
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

        public void DrawAFormPIM()
        {
            if (aForm == null)
            {
                aForm = new AForms.PIMForm();
                aForm.TopLevel = false;
                aPanel.Controls.Add(aForm);
            }
            aForm.Show();
        }
        public void DrawCForm()
        {
            if (cForm == null)
            {
                cForm = new CForms.EmptyCForm(ServerSender);
                cForm.TopLevel = false;
                cPanel.Controls.Add(cForm);
            }
            cForm.Show();
        }

        public void DrawEFormMessages()
        {
            if (eForm == null)
            {
                eForm = new EForms.MessagesForm();
                eForm.TopLevel = false;
                ePanel.Controls.Add(eForm);
            }
            eForm.Show();
        }

        public void DrawBFormSpeed()
        {
            if (bForm == null)
            {
                bForm = new BForms.SpeedmeterForm();
                bForm.TopLevel = false;
                bPanel.Controls.Add(bForm);
            }
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
            dForm = new DForms.TrainNumberForm(this, ServerSender);
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
            dForm = new DForms.CheckTrainTypeDataForm(this, trainData, ServerSender);
            dForm.TopLevel = false;
            dPanel.Controls.Add(dForm);
            dForm.Show();
        }

        public void DrawTrainDataConfirm(string trainCat, string length, string vmax, string brakingMass)
        {
            dForm = new DForms.CheckTrainDataForm(this, trainCat, length, vmax, brakingMass, ServerSender);
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
            dForm = new DForms.MainDForm(this, DystancesCalculator);
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
            fForm.Refresh();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((TrainData.IsTrainRegisterOnServer || TrainData.IsConnectionWorking) && ServerSender != null)
            {
                _ = ServerSender?.UnregisterTrainData();
            }
            Console.WriteLine("Wyłączanie HTTP listenera");
            ReceiverHTTP?.StopListening();
            Dispose();
        }
    }
}
