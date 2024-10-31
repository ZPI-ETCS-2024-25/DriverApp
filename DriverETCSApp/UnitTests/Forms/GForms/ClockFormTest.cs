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
            var printedTime = DateTime.ParseExact(ClockForm.GetPrintedTime(), "HH:mm:ss", null);
            var difference = Math.Abs((DateTime.Now - printedTime).TotalSeconds);
            Assert.True(difference <= 5);

            ClockForm.Close();
            Assert.Empty(ClockForm.GetPrintedTime());
        }
    }
}
