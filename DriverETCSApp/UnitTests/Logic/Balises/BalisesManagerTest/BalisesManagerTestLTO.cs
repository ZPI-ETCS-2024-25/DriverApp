using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Forms.CForms;
using DriverETCSApp.Logic.Balises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Balises.BalisesManagerTest
{
    public class BalisesManagerTestLTO
    {
        private BalisesManager BalisesManager;

        [Fact]
        public void LTOTestIgnore()
        {
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTO");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.ActiveMode = "";

            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("Ignore_OFF"));
            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("Ignore_OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void LTOTestConnectionAndActive()
        {
            BalisesManager = new BalisesManager();
            EmptyCForm form = new EmptyCForm(new DriverETCSApp.Communication.Server.ServerSender("127.0.0.1", Port.Server));
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTO");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = true;
            TrainData.ActiveMode = "";

            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("GO_OFF"));
            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal(ETCSModes.STM, TrainData.ActiveMode);
        }

        [Fact]
        public void LTOTestConnectionAndNotActive()
        {
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTO");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = false;
            TrainData.ActiveMode = "";

            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("GO_OFF"));
            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        [Fact]
        public void LTOTestNotConnectionAndNotActive()
        {
            BalisesManager = new BalisesManager();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "LTO");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = false;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = false;
            TrainData.ActiveMode = "";

            ETCSEvents.OnForceToChangeBaliseType(new Events.ETCSEventArgs.BaliseInfo("GO_OFF"));
            BalisesManager.Manage(messageFromBalise);

            Assert.Equal("", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("GO_OFF", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }
    }
}
