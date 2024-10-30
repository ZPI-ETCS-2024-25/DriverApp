using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DriverETCSApp.Forms.GForms;
using System.Threading;

namespace DriverETCSApp.UnitTests.Forms.GForms
{
    public class ClockFormTest
    {
        private ClockForm ClockForm;

        public ClockFormTest()
        {

        }

        [Fact]
        public void TestTime()
        {
            ClockForm = new ClockForm();
            ClockForm.Show();
            var s = ClockForm.GetPrintedTime();
            Assert.Equal(DateTime.Now.ToString("HH:mm:ss"), s);

            ClockForm.Close();
            Assert.Empty(ClockForm.GetPrintedTime());
        }
    }
}
