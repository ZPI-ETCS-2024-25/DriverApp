using DriverETCSApp.Data;
using DriverETCSApp.Forms;
using DriverETCSApp.Forms.DForms;
using DriverETCSApp.Forms.FForms;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.FullScreenForms
{
    public class CheckTrainTypeDataFormTest : IDisposable
    {
        private CheckTrainTypeDataForm CheckTrainTypeDataForm;
        private MainForm MainForm;

        public CheckTrainTypeDataFormTest()
        {

        }

        private void Create()
        {
            MainForm = new MainForm(false);
            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, CheckTrainTypeDataForm);
        }

        private void Stop()
        {
            var stopMethod = typeof(MainForm).GetMethod("MainForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(MainForm, parameters);
        }

        [Fact]
        [STAThread]
        public void TestLabels()
        {
            Create();
            CheckTrainTypeDataForm = new CheckTrainTypeDataForm(MainForm, PredefinedTrainData.DefaultTrain, new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));

            var label1 = (Label)typeof(CheckTrainTypeDataForm).GetField("infoLabelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainTypeDataForm);

            Stop();
            Assert.Equal("Default", label1.Text);
        }

        [Fact]
        [STAThread]
        public void TestClose()
        {
            Create();
            CheckTrainTypeDataForm = new CheckTrainTypeDataForm(MainForm, PredefinedTrainData.DefaultTrain, new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            var method = typeof(CheckTrainTypeDataForm).GetMethod("closeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainTypeDataForm, parameters);
            Stop();
            Assert.True(CheckTrainTypeDataForm.IsDisposed);
        }

        [Fact]
        [STAThread]
        public void LabelDataTest()
        {
            Create();
            CheckTrainTypeDataForm = new CheckTrainTypeDataForm(MainForm, PredefinedTrainData.DefaultTrain, new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            Stop();

            var label = (Label)typeof(CheckTrainTypeDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainTypeDataForm);
            Assert.Equal("TAK", label.Text);

            var method = typeof(CheckTrainTypeDataForm).GetMethod("buttonNo_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainTypeDataForm, parameters);
            label = (Label)typeof(CheckTrainTypeDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainTypeDataForm);
            Assert.Equal("NIE", label.Text);

            method = typeof(CheckTrainTypeDataForm).GetMethod("buttonYes_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(CheckTrainTypeDataForm, parameters);
            label = (Label)typeof(CheckTrainTypeDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainTypeDataForm);
            Assert.Equal("TAK", label.Text);
        }

        [Fact]
        [STAThread]
        public void Label1ClickTest()
        {
            Create();
            CheckTrainTypeDataForm = new CheckTrainTypeDataForm(MainForm, PredefinedTrainData.DefaultTrain, new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            TrainData.TrainNumber = "";
            TrainData.TrainType = "";
            TrainData.IsTrainRegisterOnServer = false;

            var method = typeof(CheckTrainTypeDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainTypeDataForm, parameters);
            Stop();

            Assert.Equal(PredefinedTrainData.DefaultTrain.TrainName, TrainData.TrainType);
            Assert.Equal(PredefinedTrainData.DefaultTrain.TrainCat, TrainData.TrainCat);
            Assert.Equal(PredefinedTrainData.DefaultTrain.Length, TrainData.Length);
            Assert.Equal(PredefinedTrainData.DefaultTrain.BrakingMass, TrainData.BrakingMass);
            Assert.Equal(PredefinedTrainData.DefaultTrain.VMax, TrainData.VMax);
        }

        [Fact]
        [STAThread]
        public void Label1ClickTestWithTrainNumber()
        {
            Create();
            CheckTrainTypeDataForm = new CheckTrainTypeDataForm(MainForm, PredefinedTrainData.DefaultTrain, new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            TrainData.TrainNumber = "654";
            TrainData.TrainType = "";
            TrainData.IsTrainRegisterOnServer = false;

            var method = typeof(CheckTrainTypeDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainTypeDataForm, parameters);
            Stop();

            Assert.Equal(PredefinedTrainData.DefaultTrain.TrainName, TrainData.TrainType);
            Assert.Equal(PredefinedTrainData.DefaultTrain.TrainCat, TrainData.TrainCat);
            Assert.Equal(PredefinedTrainData.DefaultTrain.Length, TrainData.Length);
            Assert.Equal(PredefinedTrainData.DefaultTrain.BrakingMass, TrainData.BrakingMass);
            Assert.Equal(PredefinedTrainData.DefaultTrain.VMax, TrainData.VMax);
        }

        [Fact]
        [STAThread]
        public void Label1ClickTestNo()
        {
            Create();
            CheckTrainTypeDataForm = new CheckTrainTypeDataForm(MainForm, PredefinedTrainData.DefaultTrain, new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            TrainData.TrainType = "";
            TrainData.TrainNumber = "";
            TrainData.TrainCat = "";
            TrainData.BrakingMass = "";
            TrainData.Length = "";
            TrainData.VMax = "";

            var method = typeof(CheckTrainTypeDataForm).GetMethod("buttonNo_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainTypeDataForm, parameters);

            method = typeof(CheckTrainTypeDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(CheckTrainTypeDataForm, parameters);
            Stop();

            Assert.Equal("", TrainData.TrainType);
            Assert.Equal("", TrainData.TrainCat);
            Assert.Equal("", TrainData.BrakingMass);
            Assert.Equal("", TrainData.Length);
            Assert.Equal("", TrainData.VMax);
            Assert.True(CheckTrainTypeDataForm.IsDisposed);
        }

        public void Dispose()
        {
            CheckTrainTypeDataForm?.Dispose();
            MainForm?.Dispose();
        }
    }
}
