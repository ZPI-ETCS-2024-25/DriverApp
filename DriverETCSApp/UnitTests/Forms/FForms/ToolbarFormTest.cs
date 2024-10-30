using DriverETCSApp.Forms;
using DriverETCSApp.Forms.FForms;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.FForms
{
    public class ToolbarFormTest
    {
        private ToolbarForm ToolbarForm;
        private MainForm MainForm;

        public ToolbarFormTest() 
        {
            
        }

        private void Create()
        {
            MainForm = new MainForm();
            ToolbarForm = new ToolbarForm(MainForm);
            ToolbarForm.ShowInTaskbar = false;
            ToolbarForm.Visible = false;
            ToolbarForm.CreateControl();
        }

        private void Stop()
        {
            var stopMethod = typeof(MainForm).GetMethod("MainForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, FormClosingEventArgs.Empty };
            var result = stopMethod.Invoke(MainForm, parameters);
        }

        [Fact]
        public void GoToMenuTest()
        {
            Create();
            var button = (Button)(typeof(ToolbarForm).GetField("buttonMainMenu", BindingFlags.NonPublic | BindingFlags.Instance)).GetValue(ToolbarForm);
            button.PerformClick();
            Assert.True(ToolbarForm.IsDisposed);
            MainForm.Dispose();
            ToolbarForm.Dispose();
            //Stop();
        }

        [Fact]
        public void GoToDataViewTest()
        {
            Create();
            var button = (Button)(typeof(ToolbarForm).GetField("buttonDataView", BindingFlags.NonPublic | BindingFlags.Instance)).GetValue(ToolbarForm);
            button.PerformClick();
            Assert.False(ToolbarForm.IsDisposed);
            //Stop();
        }

        [Fact]
        public void GoToSettingsTest()
        {
            Create();
            var button = (Button)(typeof(ToolbarForm).GetField("buttonSettings", BindingFlags.NonPublic | BindingFlags.Instance)).GetValue(ToolbarForm);
            button.PerformClick();
            Assert.True(ToolbarForm.IsDisposed);
            //Stop();
        }
    }
}
