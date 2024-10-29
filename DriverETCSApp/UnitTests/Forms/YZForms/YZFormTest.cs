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
            
        }

        [Fact]
        public void YAndZFormTest()
        {
            YZForm = new YZForm();
            Assert.NotNull(YZForm);
        }
    }
}
