using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Forms;
using DriverETCSApp.Forms.DForms;
using DriverETCSApp.Properties;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.DForms
{
    public class IDDriverFormTest
    {
        private IDDriverForm IDDriverForm;
        private MainForm MainForm;

        public IDDriverFormTest() 
        {

        }
        private void Create()
        {
            MainForm = new MainForm(false);
            IDDriverForm = new IDDriverForm(MainForm, true);
            IDDriverForm.ShowInTaskbar = false;
            IDDriverForm.Visible = false;
            IDDriverForm.CreateControl();

            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, IDDriverForm);
        }

        private void Stop()
        {
            var stopMethod = typeof(MainForm).GetMethod("MainForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(MainForm, parameters);
        }

        [Fact]
        public void checkInitTest()
        {
            MainForm = new MainForm(false);
            IDDriverForm = new IDDriverForm(MainForm, false);
            IDDriverForm.ShowInTaskbar = false;
            IDDriverForm.Visible = false;
            IDDriverForm.CreateControl();

            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, IDDriverForm);

            var formField1 = (Button)typeof(IDDriverForm).GetField("closeButton", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(IDDriverForm);

            var stopMethod = typeof(IDDriverForm).GetMethod("closeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(IDDriverForm, parameters);

            Assert.Equal(Design.DMIColors.DarkGrey, formField1.ForeColor);
            Assert.False(IDDriverForm.IsDisposed);

            Stop();
        }

        [Fact]
        public void ButtonCloseTest()
        {
            Create();

            var stopMethod = typeof(IDDriverForm).GetMethod("closeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(IDDriverForm, parameters);

            Stop();
            Assert.True(IDDriverForm.IsDisposed);
        }

        [Fact]
        public void Button1Test()
        {
            Create();

            var stopMethod = typeof(IDDriverForm).GetMethod("button1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };

            for (int i = 0; i < 25; i++)
            {
                var result = stopMethod.Invoke(IDDriverForm, parameters);
            }
            var formField1 = (Label)typeof(IDDriverForm).GetField("label2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(IDDriverForm);

            Stop();
            Assert.Equal(20, formField1.Text.Length);
        }

        [Fact]
        public async void Button2Test()
        {
            TrainData.IDDriver = "";
            Create();

            var stopMethod = typeof(IDDriverForm).GetMethod("button2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };

            for (int i = 0; i < 2; i++)
            {
                var result1 = stopMethod.Invoke(IDDriverForm, parameters);
            }

            await Task.Delay(1000);

            var result = stopMethod.Invoke(IDDriverForm, parameters);
            stopMethod = typeof(IDDriverForm).GetMethod("button3_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            stopMethod.Invoke(IDDriverForm, parameters);

            var formField1 = (Label)typeof(IDDriverForm).GetField("label2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(IDDriverForm);

            Stop();
            Assert.Equal("a23", formField1.Text);
        }

        [Fact]
        public void ButtonDeleteNoActionTest()
        {
            Create();

            var stopMethod = typeof(IDDriverForm).GetMethod("button10_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result1 = stopMethod.Invoke(IDDriverForm, parameters);

            var formField1 = (Label)typeof(IDDriverForm).GetField("label2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(IDDriverForm);

            Stop();
            Assert.Equal("", formField1.Text);
        }

        [Fact]
        public void ButtonTest()
        {
            Create();

            for (int i = 1; i < 12; i++)
            {
                var stopMethod = typeof(IDDriverForm).GetMethod("button" + i.ToString() + "_Click", BindingFlags.NonPublic | BindingFlags.Instance);
                object[] parameters = { null, null };
                var result1 = stopMethod.Invoke(IDDriverForm, parameters);
            }

            var formField1 = (Label)typeof(IDDriverForm).GetField("label2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(IDDriverForm);

            Stop();
            Assert.Equal("123456780", formField1.Text);
        }

        [Fact]
        public void PictureBoxClickTest()
        {
            Create();

            var stopMethod = typeof(IDDriverForm).GetMethod("pictureBoxSettings_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(IDDriverForm, parameters);

            Stop();
            Assert.True(IDDriverForm.IsDisposed);
        }

        [Fact]
        public void TrainButtonClickTest()
        {
            Create();

            var stopMethod = typeof(IDDriverForm).GetMethod("trainButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(IDDriverForm, parameters);

            Stop();
            Assert.True(IDDriverForm.IsDisposed);
        }

        [Fact]
        public void LabelClick()
        {
            TrainData.IDDriver = "";
            MainForm = new MainForm(false);
            IDDriverForm = new IDDriverForm(MainForm, false);
            IDDriverForm.ShowInTaskbar = false;
            IDDriverForm.Visible = false;
            IDDriverForm.CreateControl();

            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, IDDriverForm);

            var stopMethod = typeof(IDDriverForm).GetMethod("label2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(IDDriverForm, parameters);

            Stop();
            Assert.Empty(TrainData.IDDriver);
        }

        [Fact]
        public void LabelClick1()
        {
            TrainData.IDDriver = "";
            Create();

            var stopMethod = typeof(IDDriverForm).GetMethod("button1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(IDDriverForm, parameters);

            var stopMethod1 = typeof(IDDriverForm).GetMethod("label2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            var result1 = stopMethod1.Invoke(IDDriverForm, parameters);

            Stop();
            Assert.Equal("1", TrainData.IDDriver);
        }
    }
}
