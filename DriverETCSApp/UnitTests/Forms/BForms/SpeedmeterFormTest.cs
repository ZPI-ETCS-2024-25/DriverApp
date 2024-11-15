using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Forms;
using DriverETCSApp.Forms.BForms;
using DriverETCSApp.Forms.DForms;
using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.BForms
{

    public class SpeedmeterFormTest
    {
        private SpeedmeterForm SpeedmeterForm;

        public SpeedmeterFormTest()
        {
            SpeedmeterForm = new SpeedmeterForm();
        }

        private void Stop()
        {
            var stopMethod = typeof(SpeedmeterForm).GetMethod("SpeedmeterForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(SpeedmeterForm, parameters);
        }

        [Fact]
        public void CheckModeChange()
        {
            ETCSEvents.OnModeChanged(new Events.ETCSEventArgs.ModeInfo(Resources.FS, ETCSModes.FS));
            var formField = (PictureBox)typeof(SpeedmeterForm).GetField("modePicture", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(SpeedmeterForm);
            Assert.True(TrainData.IsETCSActive);
            Assert.Equal(TrainData.ActiveMode, ETCSModes.FS);
            Assert.Equal(Resources.FS.Flags, formField.Image.Flags);

            ETCSEvents.OnModeChanged(new Events.ETCSEventArgs.ModeInfo(null, ETCSModes.SB));
            formField = (PictureBox)typeof(SpeedmeterForm).GetField("modePicture", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(SpeedmeterForm);
            Assert.False(TrainData.IsETCSActive);
            Assert.Equal(TrainData.ActiveMode, ETCSModes.SB);
            Assert.Equal(Resources.FS.Flags, formField.Image.Flags);

            Stop();
        }
    }
}
