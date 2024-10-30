using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Logic.Balises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Balises.BalisesManagerTest
{
    public class BalisesManagerTestCLT
    {
        private BalisesManager BalisesManager;
        public BalisesManagerTestCLT() { }

        [Fact]
        public void CLTTestOFF()
        {
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CLT");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.ActiveMode = "";

            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("OFF"));
            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal(100, TrainData.CalculatedPosition);
            Assert.Equal("OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void CLTTestConnectedNotActive()
        {
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CLT");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = false;
            TrainData.ActiveMode = "";

            var y = Assert.Raises<LevelInfo>(
                x => ETCSEvents.LevelChanged += x,
                x => ETCSEvents.LevelChanged -= x,
                () => BalisesManager.Manage(messageFromBalise));
            Assert.NotNull(y);

            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("Ignore_OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void CLTTestConnectedAndActive()
        {
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CLT");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = true;
            TrainData.ActiveMode = "";
            bool wasEventRaised = false;

            ETCSEvents.LevelChanged += (sender, args) =>
            {
                wasEventRaised = true;
            };

            BalisesManager.Manage(messageFromBalise);

            Assert.False(wasEventRaised);
            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("Ignore_OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void CLTTestNotConnected()
        {
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CLT");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = false;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = true;
            TrainData.ActiveMode = "";
            bool wasEventRaised = false;

            ETCSEvents.LevelChanged += (sender, args) =>
            {
                wasEventRaised = true;
            };

            BalisesManager.Manage(messageFromBalise);

            Assert.False(wasEventRaised);
            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }
    }
}
