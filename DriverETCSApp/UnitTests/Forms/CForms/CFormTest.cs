using DriverETCSApp.Forms.BForms;
using DriverETCSApp.Forms.CForms;
using DriverETCSApp.Forms.DForms;
using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.CForms
{
    public class CFormTest
    {
        private EmptyCForm cForm;

        public CFormTest() 
        {
            cForm = new EmptyCForm(new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
        }

        private void Stop()
        {
            var stopMethod = typeof(EmptyCForm).GetMethod("EmptyCForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(cForm, parameters);
        }

        [Fact]
        public void BrakingImageTest()
        {
            EmptyCForm.BrakingImage(true);
            var formField = (PictureBox)typeof(EmptyCForm).GetField("brakePicture", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(cForm);
            Assert.Equal(Resources.Brakes.Flags, formField.Image.Flags);

            EmptyCForm.BrakingImage(false);
            formField = (PictureBox)typeof(EmptyCForm).GetField("brakePicture", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(cForm);
            Assert.Null(formField.Image);

            Stop();
        }
    }
}
