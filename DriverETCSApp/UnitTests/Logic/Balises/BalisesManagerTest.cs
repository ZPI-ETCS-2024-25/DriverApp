using DriverETCSApp.Data;
using DriverETCSApp.Events;
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
                messageType = "CBF"
            };
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal(0, TrainData.BalisePosition);
        }

        [Fact]
        public void CBFTest()
        {
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CBF");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
        }

        [Fact]
        public void CBFTestNotConnected()
        {
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CBF");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = false;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0, TrainData.BalisePosition);
        }

        [Fact]
        public void CBFTestPDirection()
        {
            var messageFromBalise = new MessageFromBalise(0.1, 2, 2, "1", 1, "CBF");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("P", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
        }

        [Fact]
        public void CBFTestOff()
        {
            var messageFromBalise = new MessageFromBalise(0.1, 2, 2, "1", 1, "CBF");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;

            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("OFF"));
            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
        }
    }
}
