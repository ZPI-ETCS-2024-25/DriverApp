using DriverETCSApp.Forms.DForms;
using DriverETCSApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DriverETCSApp.Data;
using Xunit;
using System.Windows.Forms;
using DriverETCSApp.Design;

namespace DriverETCSApp.UnitTests.Forms.FullScreenForms
{
    public class TrainDataTypeFormTest : IDisposable
    {
        private MainForm MainForm;
        private TrainDataTypeForm TrainDataTypeForm;

        public TrainDataTypeFormTest()
        {

        }

        public void Dispose()
        {
            TrainDataTypeForm?.Dispose();
            MainForm?.Dispose();
        }

        private void Create()
        {
            MainForm = new MainForm(false);
            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, TrainDataTypeForm);
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
            TrainData.TrainType = "Default";
            TrainData.TrainCat = "PASS 3";
            TrainData.Length = "100";
            TrainData.BrakingMass = "111";
            TrainData.VMax = "1";
            TrainDataTypeForm = new TrainDataTypeForm(MainForm);

            var label1 = (Label)typeof(TrainDataTypeForm).GetField("infoLabelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataTypeForm);

            Stop();
            Assert.Equal("Default", label1.Text);
        }

        [Fact]
        [STAThread]
        public void TestClose()
        {
            Create();
            TrainDataTypeForm = new TrainDataTypeForm(MainForm);
            var method = typeof(TrainDataTypeForm).GetMethod("closeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataTypeForm, parameters);
            Stop();
            Assert.True(TrainDataTypeForm.IsDisposed);
        }

        [Fact]
        [STAThread]
        public void TestChangeDisplay()
        {
            Create();
            TrainDataTypeForm = new TrainDataTypeForm(MainForm);
            var method = typeof(TrainDataTypeForm).GetMethod("buttonChangeDisplay_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataTypeForm, parameters);
            Stop();
            Assert.True(TrainDataTypeForm.IsDisposed);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel1Empty()
        {
            Create();
            TrainDataTypeForm = new TrainDataTypeForm(MainForm);
            var label1 = (Label)typeof(TrainDataTypeForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataTypeForm);
            label1.Text = "";

            var method = typeof(TrainDataTypeForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataTypeForm, parameters);

            var l1 = (Label)typeof(TrainDataTypeForm).GetField("labelConfirmation", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataTypeForm);
            Stop();
            Assert.Equal(DMIColors.DarkGrey, l1.BackColor);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel1()
        {
            Create();
            TrainDataTypeForm = new TrainDataTypeForm(MainForm);
            var label1 = (Label)typeof(TrainDataTypeForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataTypeForm);
            label1.Text = "123";

            var method = typeof(TrainDataTypeForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataTypeForm, parameters);

            var l1 = (Label)typeof(TrainDataTypeForm).GetField("labelConfirmation", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataTypeForm);
            Stop();
            Assert.Equal(DMIColors.White, l1.BackColor);
        }
    }
}
