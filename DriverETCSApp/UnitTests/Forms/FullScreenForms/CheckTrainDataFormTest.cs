using DriverETCSApp.Data;
using DriverETCSApp.Forms;
using DriverETCSApp.Forms.DForms;
using DriverETCSApp.Forms.FForms;
using DriverETCSApp.Logic.Position;
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
    public class CheckTrainDataFormTest : IDisposable
    {
        private CheckTrainDataForm CheckTrainDataForm;
        private MainForm MainForm;

        public CheckTrainDataFormTest()
        {

        }

        private void Create()
        {
            MainForm = new MainForm(false);
            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, CheckTrainDataForm);
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
            CheckTrainDataForm = new CheckTrainDataForm(MainForm, "PASS3", "100", "101", "102", new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));

            var label1 = (Label)typeof(CheckTrainDataForm).GetField("infoLabelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainDataForm);
            var label2 = (Label)typeof(CheckTrainDataForm).GetField("infoLabelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainDataForm);
            var label3 = (Label)typeof(CheckTrainDataForm).GetField("infoLabelData3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainDataForm);
            var label4 = (Label)typeof(CheckTrainDataForm).GetField("infoLabelData4", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainDataForm);

            Stop();
            Assert.Equal("PASS3", label1.Text);
            Assert.Equal("100", label2.Text);
            Assert.Equal("102", label3.Text);
            Assert.Equal("101", label4.Text);
        }

        [Fact]
        [STAThread]
        public void TestClose()
        {
            Create();
            CheckTrainDataForm = new CheckTrainDataForm(MainForm, "PASS3", "100", "101", "102", new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            var method = typeof(CheckTrainDataForm).GetMethod("closeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainDataForm, parameters);
            Stop();
            Assert.True(CheckTrainDataForm.IsDisposed);
        }

        [Fact]
        [STAThread]
        public void LabelDataTest()
        {
            Create();
            CheckTrainDataForm = new CheckTrainDataForm(MainForm, "PASS3", "100", "101", "102", new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            Stop();

            var label = (Label)typeof(CheckTrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainDataForm);
            Assert.Equal("TAK", label.Text);

            var method = typeof(CheckTrainDataForm).GetMethod("buttonNo_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainDataForm, parameters);
            label = (Label)typeof(CheckTrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainDataForm);
            Assert.Equal("NIE", label.Text);

            method = typeof(CheckTrainDataForm).GetMethod("buttonYes_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(CheckTrainDataForm, parameters);
            label = (Label)typeof(CheckTrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(CheckTrainDataForm);
            Assert.Equal("TAK", label.Text);
        }

        [Fact]
        [STAThread]
        public void Label1ClickTest()
        {
            Create();
            CheckTrainDataForm = new CheckTrainDataForm(MainForm, "PASS3", "100", "101", "102", new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            TrainData.TrainNumber = "";
            TrainData.IsTrainRegisterOnServer = false;

            var method = typeof(CheckTrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainDataForm, parameters);
            Stop();

            Assert.Equal("PASS3", TrainData.TrainCat);
            Assert.Equal("100", TrainData.Length);
            Assert.Equal("102", TrainData.BrakingMass);
            Assert.Equal("101", TrainData.VMax);
        }

        [Fact]
        [STAThread]
        public void Label1ClickTestWithTrainNumber()
        {
            Create();
            CheckTrainDataForm = new CheckTrainDataForm(MainForm, "PASS3", "100", "101", "102", new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            TrainData.TrainNumber = "654";
            TrainData.IsTrainRegisterOnServer = false;

            var method = typeof(CheckTrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainDataForm, parameters);
            Stop();

            Assert.Equal("PASS3", TrainData.TrainCat);
            Assert.Equal("100", TrainData.Length);
            Assert.Equal("102", TrainData.BrakingMass);
            Assert.Equal("101", TrainData.VMax);
        }

        [Fact]
        [STAThread]
        public void Label1ClickTestNo()
        {
            Create();
            CheckTrainDataForm = new CheckTrainDataForm(MainForm, "PASS3", "100", "101", "102", new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            TrainData.TrainNumber = "";
            TrainData.TrainCat = "";
            TrainData.BrakingMass = "";
            TrainData.Length = "";
            TrainData.VMax = "";

            var method = typeof(CheckTrainDataForm).GetMethod("buttonNo_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(CheckTrainDataForm, parameters);

            method = typeof(CheckTrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(CheckTrainDataForm, parameters);
            Stop();

            Assert.Equal("", TrainData.TrainCat);
            Assert.Equal("", TrainData.BrakingMass);
            Assert.Equal("", TrainData.Length);
            Assert.Equal("", TrainData.VMax);
            Assert.True(CheckTrainDataForm.IsDisposed);
        }

        public void Dispose()
        {
            CheckTrainDataForm.Dispose();
            MainForm.Dispose();
        }
    }
}
