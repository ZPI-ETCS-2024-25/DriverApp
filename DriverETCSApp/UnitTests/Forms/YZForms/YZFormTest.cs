using DriverETCSApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.YZForms
{
    public class YZFormTest
    {
        private YZForm YZForm;
        public YZFormTest()
        {
            YZForm = new YZForm();
        }

        [Fact]
        public void YAndZFormTest()
        {
            Assert.NotNull(YZForm);
        }
    }
}
