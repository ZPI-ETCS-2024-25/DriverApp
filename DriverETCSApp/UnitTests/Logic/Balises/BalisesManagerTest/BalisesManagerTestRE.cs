using DriverETCSApp.Logic.Balises;
using DriverETCSApp.Data;
using DriverETCSApp.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Balises.BalisesManagerTest
{
    public class BalisesManagerTestRE : IDisposable
    {
        private BalisesManager BalisesManager;

        public BalisesManagerTestRE()
        {
            TrainData.Reset();
        }

        [Fact]
        public void RETestOff()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 2, 2, "1", 1, "RE");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;

            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("OFF"));
            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("", BalisesManager.GetLastBaliseType());
        }

        [Fact]
        public void RETest()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.2, 2, 2, "1", 1, "RE");
            TrainData.BalisePosition = 0.1;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("P", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.2, TrainData.BalisePosition);
            Assert.Equal("", BalisesManager.GetLastBaliseType());
        }

        [Fact]
        public void RETestNoConnectionAndRegister()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 2, 2, "1", 1, "RE");
            TrainData.BalisePosition = 0.0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = false;
            TrainData.IsTrainRegisterOnServer = false;
            TrainData.TrainNumber = "1";
            TrainData.Length = "123";
            TrainData.VMax = "123";
            TrainData.BrakingMass = "123";

            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", BalisesManager.GetLastBaliseType());
        }

        public void Dispose()
        {
            BalisesManager = null;
        }
    }
}
