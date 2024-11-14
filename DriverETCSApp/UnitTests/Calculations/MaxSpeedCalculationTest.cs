﻿using DriverETCSApp.Data;
using DriverETCSApp.Logic.Calculations;
using DriverETCSApp.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Calculations {
    public class MaxSpeedCalculationTest : IDisposable {

        private SpeedSegragation SpeedSegragation;

        public MaxSpeedCalculationTest() {
            SpeedSegragation = new SpeedSegragation();
        }

        [Fact]
        public void CheckMaxSpeed() {
            AuthorityData.SpeedDistances = new List<double> { 150, 500, 800, 1000 };
            AuthorityData.Speeds = new List<double> { 120, 90, 80, 50 };
            MaxSpeedsCalculation.SetBrakingAccelerationByValue(-3);
            //TrainData.Reset();
            //SpeedSegragation.CalculateSpeeds();
            MaxSpeedsCalculation.Calculate(AuthorityData.Speeds, AuthorityData.SpeedDistances);
            Assert.Equal(AuthorityData.MaxSpeedsDistances, new List<double> { 208.33333333333331, 721.2962962962963, 819.44444444444446 });
        }

        [Fact]
        public void CheckAdjacentSpeedDistances() {
            AuthorityData.SpeedDistances = new List<double> { 0, 440, 450 };
            AuthorityData.Speeds = new List<double> { 100, 150, 80 };
            MaxSpeedsCalculation.SetBrakingAccelerationByValue(-3);

            MaxSpeedsCalculation.Calculate(AuthorityData.Speeds, AuthorityData.SpeedDistances);
            Assert.Equal(AuthorityData.MaxSpeedsDistances, new List<double> { 283.33333333333331 });
        }

        public void Dispose() {
            SpeedSegragation = null;
        }
    }
}
