using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Forms.CForms;
using DriverETCSApp.Logic.Balises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Balises.BalisesManagerTest
{
    public class BalisesManagerTest : IDisposable
    {
        private BalisesManager BalisesManager;

        public BalisesManagerTest()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
        }

        [Fact]
        public void KilometerTest()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
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
            TrainData.BaliseTrackPosition = "1";
            TrainData.BaliseLinePosition = 1;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal(0, TrainData.BalisePosition);
            Assert.Equal("", BalisesManager.GetLastBaliseType());

            TrainData.BaliseTrackPosition = "";
            TrainData.BaliseLinePosition = 0;
        }

        [Fact]
        public void CBFTest()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
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
        public void CBFTestNotRegistered()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CBF");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = false;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
        }

        [Fact]
        public void CBFTestPDirection()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
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
            BalisesManager = new BalisesManager();
            TrainData.Reset();
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

        [Fact]
        public void CBFTestMiddleBalise()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 2, 3, "1", 1, "CBF");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
        }

        [Fact]
        public void CBFTestSingleBalise()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 1, "1", 1, "CBF");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
        }

        [Fact]
        public void CBFTestNoConnection()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 1, "1", 1, "CBF");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = false;
            TrainData.IsTrainRegisterOnServer = true;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
        }

        [Fact]
        public void CBFTestThesameBalise()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 1, "1", 1, "CBF");
            TrainData.BalisePosition = 0.1;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = false;
            TrainData.IsTrainRegisterOnServer = true;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
        }

        public void Dispose()
        {
            BalisesManager = null;
        }
    }
}
