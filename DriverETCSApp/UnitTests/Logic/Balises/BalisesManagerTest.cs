using DriverETCSApp.Data;
using DriverETCSApp.Logic.Balises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Balises
{
    public class BalisesManagerTest
    {
        private BalisesManager BalisesManager;

        public BalisesManagerTest()
        {
            BalisesManager = new BalisesManager();
        }

        [Fact]
        public void KilometerTest()
        {
            var messageFromBalise = new MessageFromBalise()
            {
                kilometer = 0,
                number = 1,
                numberOfBalises = 2,
                trackNumber = "1",
                lineNumber = 1,
                messageType = "CFB"
            };
            TrainData.BalisePosition = 0;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal(0, TrainData.BalisePosition);
        }

        [Fact]
        public void CFBTest()
        {

        }
    }
}
