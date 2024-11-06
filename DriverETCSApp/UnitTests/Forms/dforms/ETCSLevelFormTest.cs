using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Forms;
using DriverETCSApp.Forms.DForms;
using DriverETCSApp.Forms.FForms;
using DriverETCSApp.Logic.Balises;
using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.DForms
{
    public class ETCSLevelFormTest
    {
        private ETCSLevelForm ETCSLevelForm;
        private MainForm MainForm;

        public ETCSLevelFormTest() { }

        private void Create()
        {
            MainForm = new MainForm(false);
            ETCSLevelForm = new ETCSLevelForm(MainForm, true);
            ETCSLevelForm.ShowInTaskbar = false;
            ETCSLevelForm.Visible = false;
            ETCSLevelForm.CreateControl();

            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, ETCSLevelForm);
        }

        private void Stop()
        {
            var stopMethod = typeof(MainForm).GetMethod("MainForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(MainForm, parameters);
        }

        [Fact]
        public void TestBackButtonActive()
        {
            Create();
            var formField = (Button)typeof(ETCSLevelForm).GetField("closeButton", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(ETCSLevelForm);
            Stop();
            Assert.Equal(Design.DMIColors.Grey, formField.ForeColor);
        }

        [Fact]
        public void TestBackButtonActive1()
        {
            Create();
            ETCSLevelForm = new ETCSLevelForm(MainForm, false);
            var formField1 = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField1.SetValue(MainForm, ETCSLevelForm);

            var formField = (Button)typeof(ETCSLevelForm).GetField("closeButton", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(ETCSLevelForm);
            Stop();
            Assert.Equal(Design.DMIColors.DarkGrey, formField.ForeColor);
        }

        [Fact]
        public void TestButtons()
        {
            Create();

            var stopMethod = typeof(ETCSLevelForm).GetMethod("button2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(ETCSLevelForm, parameters);

            var formField = (Label)typeof(ETCSLevelForm).GetField("label2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(ETCSLevelForm);
            var text = formField.Text;

            stopMethod = typeof(ETCSLevelForm).GetMethod("button5_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = stopMethod.Invoke(ETCSLevelForm, parameters);

            formField = (Label)typeof(ETCSLevelForm).GetField("label2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(ETCSLevelForm);
            var text1 = formField.Text;
            Stop();

            Assert.Equal(ETCSLevel.Poziom2, text);
            Assert.Equal(ETCSLevel.SHP, text1);
        }

        [Fact]
        public void TestBackButton()
        {
            Create();

            var stopMethod = typeof(ETCSLevelForm).GetMethod("closeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(ETCSLevelForm, parameters);

            Stop();
            Assert.True(ETCSLevelForm.IsDisposed);
        }

        [Fact]
        public void TestBackButton1()
        {
            Create();

            ETCSLevelForm = new ETCSLevelForm(MainForm, false);
            var formField1 = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField1.SetValue(MainForm, ETCSLevelForm);

            var stopMethod = typeof(ETCSLevelForm).GetMethod("closeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(ETCSLevelForm, parameters);

            Assert.False(ETCSLevelForm.IsDisposed);
            Stop();
        }

        [Fact]
        public void TestLabel2()
        {
            Create();

            var stopMethod = typeof(ETCSLevelForm).GetMethod("button2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(ETCSLevelForm, parameters);

            var method1 = typeof(ETCSLevelForm).GetMethod("label2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            var result1 = method1.Invoke(ETCSLevelForm, parameters);

            Assert.Equal(TrainData.ETCSLevel, ETCSLevel.Poziom2);
            Assert.True(ETCSLevelForm.IsDisposed);
            Stop();
        }

        [Fact]
        public void TestLabel2NotClose()
        {
            Create();

            var method = typeof(ETCSLevelForm).GetMethod("label2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(ETCSLevelForm, parameters);

            Assert.False(ETCSLevelForm.IsDisposed);
            Stop();
        }

        [Fact]
        public void TestSetUpMode()
        {
            Create();
            TrainData.IsMisionStarted = false;
            TrainData.ETCSLevel = ETCSLevel.Poziom2;

            var method = typeof(ETCSLevelForm).GetMethod("SetUpMode", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            bool wasEventRaised = false;

            EventHandler<ChangeLevelIcon> levelChangedHandler = (sender, args) =>
            {
                if(args.Icon.Width == Resources.L2.Width && args.Icon.Height == Resources.L2.Height)
                {
                    wasEventRaised = true;
                }
            };
            ETCSEvents.ChangeLevelIcon += levelChangedHandler;
            var result = method.Invoke(ETCSLevelForm, parameters);
            ETCSEvents.ChangeLevelIcon -= levelChangedHandler;
            Stop();
            Assert.True(wasEventRaised);
        }

        [Fact]
        public void TestSetUpMode1()
        {
            Create();
            TrainData.IsMisionStarted = false;
            TrainData.ETCSLevel = ETCSLevel.SHP;

            var method = typeof(ETCSLevelForm).GetMethod("SetUpMode", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            bool wasEventRaised = false;

            EventHandler<ChangeLevelIcon> levelChangedHandler = (sender, args) =>
            {
                if (args.Icon.Width == Resources.SHP.Width && args.Icon.Height == Resources.SHP.Height)
                {
                    wasEventRaised = true;
                }
            };
            ETCSEvents.ChangeLevelIcon += levelChangedHandler;
            var result = method.Invoke(ETCSLevelForm, parameters);
            ETCSEvents.ChangeLevelIcon -= levelChangedHandler;
            Stop();
            Assert.True(wasEventRaised);
        }
    }
}