using DriverETCSApp.Data;
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

            SpeedSegragation.CalculateSpeeds();
            MaxSpeedsCalculation.Calculate(AuthorityData.Speeds, AuthorityData.SpeedDistances);
            Assert.Equal(AuthorityData.MaxSpeedsDistances, new List<double> { 140, 490, 790, 990 });
        }

        public void Dispose() {
            SpeedSegragation = null;
        }
    }
}
