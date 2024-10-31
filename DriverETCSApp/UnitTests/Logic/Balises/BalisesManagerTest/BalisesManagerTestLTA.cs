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
    public class BalisesManagerTestLTA
    {
        private BalisesManager BalisesManager;

        public BalisesManagerTestLTA() {
            TrainData.Reset();
        }

        [Fact]
        public void LTATestIgnore()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTA");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = false;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.ActiveMode = "";

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void LTATest()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTA");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.ActiveMode = "";

            var y = Assert.Raises<AckInfo>(
                x => ETCSEvents.AckChanged += x,
                x => ETCSEvents.AckChanged -= x,
                () => BalisesManager.Manage(messageFromBalise));
            Assert.NotNull(y);
            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void LTATypeONTest()
        {
            TrainData.Reset();
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTA");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.ActiveMode = "";
            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("ON"));

            var y = Assert.Raises<AckInfo>(
                x => ETCSEvents.AckChanged += x,
                x => ETCSEvents.AckChanged -= x,
                () => BalisesManager.Manage(messageFromBalise));
            Assert.NotNull(y);
            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("GO_OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void LTATypeIGNOREOFFTest()
        {
            TrainData.Reset();
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTA");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.ActiveMode = "";
            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("Ignore_OFF"));

            BalisesManager.Manage(messageFromBalise);
            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("ON", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void LTATypeOFFTest()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTA");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.ActiveMode = "";
            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("OFF"));

            BalisesManager.Manage(messageFromBalise);
            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0, TrainData.BalisePosition);
            Assert.Equal("OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }
    }
}
