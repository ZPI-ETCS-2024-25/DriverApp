﻿using DriverETCSApp.Data;
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
    public class BalisesManagerTestCLT : IDisposable
    {
        private BalisesManager BalisesManager;
        public BalisesManagerTestCLT() 
        {
            TrainData.Reset();
        }

        [Fact]
        public void CLTTestOFF()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
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
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CLT");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = false;
            TrainData.ActiveMode = "";

            BalisesManager.Manage(messageFromBalise);
            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("Ignore_OFF", BalisesManager.GetLastBaliseType());
        }

        [Fact]
        public void CLTTestConnectedAndActive()
        {
            BalisesManager = new BalisesManager();
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CLT");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = true;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = true;
            TrainData.ActiveMode = "";
            bool wasEventRaised = false;

            EventHandler<LevelInfo> levelChangedHandler = (sender, args) =>
            {
                wasEventRaised = true;
            };
            ETCSEvents.LevelChanged += levelChangedHandler;
            BalisesManager.Manage(messageFromBalise);
            ETCSEvents.LevelChanged -= levelChangedHandler;
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
            TrainData.Reset();
            var messageFromBalise = new MessageFromBalise(0.1, 1, 2, "1", 1, "CLT");
            TrainData.BalisePosition = 0;
            TrainData.CalculatedDrivingDirection = "";
            TrainData.IsConnectionWorking = false;
            TrainData.IsTrainRegisterOnServer = true;
            TrainData.IsETCSActive = true;
            TrainData.ActiveMode = "";
            bool wasEventRaised = false;

            EventHandler<LevelInfo> levelChangedHandler = (sender, args) =>
            {
                wasEventRaised = true;
            };

            ETCSEvents.LevelChanged += levelChangedHandler;

            BalisesManager.Manage(messageFromBalise);
            ETCSEvents.LevelChanged -= levelChangedHandler;
            Assert.False(wasEventRaised);
            Assert.Equal("N", TrainData.CalculatedDrivingDirection);
            Assert.Equal(0.1, TrainData.BalisePosition);
            Assert.Equal("", BalisesManager.GetLastBaliseType());
            Assert.Equal("", TrainData.ActiveMode);
        }

        public void Dispose()
        {
            BalisesManager = null;
        }
    }
}
