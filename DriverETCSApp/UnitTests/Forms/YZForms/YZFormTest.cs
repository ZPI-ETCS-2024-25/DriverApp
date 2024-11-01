using DriverETCSApp.Forms;
using DriverETCSApp.Logic.Balises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.YZForms
{
    public class YZFormTest : IDisposable
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

        public void Dispose()
        {
            YZForm.Dispose();
        }
    }
}
