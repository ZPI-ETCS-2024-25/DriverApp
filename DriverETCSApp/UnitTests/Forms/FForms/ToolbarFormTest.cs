using DriverETCSApp.Forms;
using DriverETCSApp.Forms.FForms;
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
            MainForm = new MainForm(false);
            ToolbarForm = new ToolbarForm(MainForm);
            ToolbarForm.ShowInTaskbar = false;
            ToolbarForm.Visible = false;
            ToolbarForm.CreateControl();

            var formField = typeof(MainForm).GetField("fForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, ToolbarForm);
        }

        private void Stop()
        {
            var stopMethod = typeof(MainForm).GetMethod("MainForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(MainForm, parameters);
            MainForm = null;
        }

        [Fact]
        public void GoToMenuTest()
        {
            Create();
            var method = typeof(ToolbarForm).GetMethod("buttonMainMenu_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(ToolbarForm, parameters);
            Stop();
            Assert.True(ToolbarForm.IsDisposed);
        }

        [Fact]
        public void GoToDataViewTest()
        {
            Create();
            var method = typeof(ToolbarForm).GetMethod("buttonDataView_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(ToolbarForm, parameters);
            Stop();
            Assert.False(ToolbarForm.IsDisposed);
        }

        [Fact]
        public void GoToSettingsTest()
        {
            Create();
            var method = typeof(ToolbarForm).GetMethod("buttonSettings_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(ToolbarForm, parameters);
            Stop();
            Assert.True(ToolbarForm.IsDisposed);
        }
    }
}
