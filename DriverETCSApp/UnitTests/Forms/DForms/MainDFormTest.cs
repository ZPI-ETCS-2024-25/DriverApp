using DriverETCSApp.Forms.DForms;
using DriverETCSApp.Forms;
using System.Reflection;
using DriverETCSApp.Logic.Position;
using Xunit;
using DriverETCSApp.Data;
using DriverETCSApp.Events;

namespace DriverETCSApp.UnitTests.Forms.DForms
{
    public class MainDFormTest
    {
        private MainForm MainForm;
        private MainDForm MainDForm;

        public MainDFormTest() { }

        private void Create()
        {
            MainForm = new MainForm(false);
            MainDForm = new MainDForm(MainForm, new DistancesCalculator());
            MainDForm.ShowInTaskbar = false;
            MainDForm.Visible = false;
            MainDForm.CreateControl();

            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, MainDForm);
        }

        private void Stop()
        {
            var stopMethod = typeof(MainForm).GetMethod("MainForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(MainForm, parameters);
        }

        [Fact]
        public void GetChartTest()
        {
            Create();

            var x = MainDForm.GetChart();
            Stop();

            Assert.NotNull(x);
        }

        [Fact]
        public void CheckChartVisible()
        {
            TrainData.ActiveMode = "";
            Create();
            var x = MainDForm.GetChart();
            Stop();
            Assert.False(x.Visible);

            TrainData.ActiveMode = ETCSModes.FS;
            Create();
            x = MainDForm.GetChart();
            Stop();
            Assert.True(x.Visible);
        }

        [Fact]
        public void CheckChartVisibleByEvent()
        {
            Create();
            ETCSEvents.OnModeChanged(new Events.ETCSEventArgs.ModeInfo(null, ETCSModes.OS));
            var x = MainDForm.GetChart();
            Stop();
            Assert.False(x.Visible);
        }
    }
}
