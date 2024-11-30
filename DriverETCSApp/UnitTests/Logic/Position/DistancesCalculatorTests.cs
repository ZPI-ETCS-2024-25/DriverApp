using DriverETCSApp.Data;
using DriverETCSApp.Logic.Position;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Position
{
    public class DistancesCalculatorTests : IDisposable
    {
        private DistancesCalculator Calculator;

        public DistancesCalculatorTests()
        {
            Calculator = new DistancesCalculator();
            Calculator.TurnOffClock();

            if (AuthorityData.AuthoritiyDataSemaphore.CurrentCount == 0)
            {
                AuthorityData.AuthoritiyDataSemaphore.Release();
            }
        }

        private void SetData()
        {
            AuthorityData.SpeedDistances = new List<double> { 0, 150, 500, 800, 1000, 1550, 2000, 2540, 3500, 5810, 7000 };
            AuthorityData.Speeds = new List<double> { 100, 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 };
            AuthorityData.Gradients = new List<int> { 10, 0, -2, 1, 5, -3 };
            AuthorityData.GradientsDistances = new List<double> { 0, 500, 1050, 2500, 3500, 4000, 7000 };
            AuthorityData.Messages = new List<string> { "Test 1", "Test 2" };
            AuthorityData.MessagesDistances = new List<double> { 300, 1000 };
        }


        [Fact]
        public void TestCalculatorWithoutRemoveElementsInNDirection()
        {
            Calculator.TurnOffClock();

            TrainData.CalculatedPosition = 100;
            TrainData.LastCalculated = 0;
            TrainData.CalculatedDrivingDirection = "N";
            SetData();
            Calculator.Calculate(this);
            Assert.Equal(AuthorityData.SpeedDistances, new List<double> { 0, 50, 400, 700, 900, 1450, 1900, 2440, 3400, 5710, 6900 });
            Assert.Equal(AuthorityData.Speeds, new List<double> { 100, 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 });
            Assert.Equal(AuthorityData.Gradients, new List<int> { 10, 0, -2, 1, 5, -3 });
            Assert.Equal(AuthorityData.GradientsDistances, new List<double> { 0, 400, 950, 2400, 3400, 3900, 6900 });
            Assert.Equal(AuthorityData.Messages, new List<string> { "Test 1", "Test 2" });
            Assert.Equal(AuthorityData.MessagesDistances, new List<double> { 200, 900});
        }

        [Fact]
        public void TestCalculatorWithoutRemoveElementsInNDirection1()
        {
            Calculator.TurnOffClock();

            TrainData.CalculatedPosition = 100;
            TrainData.LastCalculated = 200;
            TrainData.CalculatedDrivingDirection = "N";
            SetData();
            Calculator.Calculate(this);
            Assert.Equal(AuthorityData.SpeedDistances, new List<double> { 0, 250, 600, 900, 1100, 1650, 2100, 2640, 3600, 5910, 7100 });
            Assert.Equal(AuthorityData.Speeds, new List<double> { 100, 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 });
            Assert.Equal(AuthorityData.Gradients, new List<int> { 10, 0, -2, 1, 5, -3 });
            Assert.Equal(AuthorityData.GradientsDistances, new List<double> { 0, 600, 1150, 2600, 3600, 4100, 7100 });
            Assert.Equal(AuthorityData.Messages, new List<string> { "Test 1", "Test 2" });
            Assert.Equal(AuthorityData.MessagesDistances, new List<double> { 400, 1100 });
        }

        [Fact]
        public void TestCalculatorWithoutRemoveElementsInPDirection()
        {
            TrainData.CalculatedPosition = 0;
            TrainData.LastCalculated = 100;
            TrainData.CalculatedDrivingDirection = "P";
            SetData();
            Calculator.Calculate(this);
            Assert.Equal(AuthorityData.SpeedDistances, new List<double> { 0, 50, 400, 700, 900, 1450, 1900, 2440, 3400, 5710, 6900 });
            Assert.Equal(AuthorityData.Speeds, new List<double> { 100, 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 });
            Assert.Equal(AuthorityData.Gradients, new List<int> { 10, 0, -2, 1, 5, -3 });
            Assert.Equal(AuthorityData.GradientsDistances, new List<double> { 0, 400, 950, 2400, 3400, 3900, 6900 });
            Assert.Equal(AuthorityData.Messages, new List<string> { "Test 1", "Test 2" });
            Assert.Equal(AuthorityData.MessagesDistances, new List<double> { 200, 900 });
        }

        [Fact]
        public void TestCalculatorWithRemoveElementsInNDirection()
        {
            TrainData.CalculatedPosition = 500;
            TrainData.LastCalculated = 0;
            TrainData.CalculatedDrivingDirection = "N";
            SetData();
            Calculator.Calculate(this);
            Assert.Equal(AuthorityData.SpeedDistances, new List<double> { 0, 0, 300, 500, 1050, 1500, 2040, 3000, 5310, 6500 });
            Assert.Equal(AuthorityData.Speeds, new List<double> { 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 });
            Assert.Equal(AuthorityData.Gradients, new List<int> { 10, 0, -2, 1, 5, -3 });
            Assert.Equal(AuthorityData.GradientsDistances, new List<double> { 0, 0, 550, 2000, 3000, 3500, 6500 });
            Assert.Equal(AuthorityData.Messages, new List<string> { "Test 2" });
            Assert.Equal(AuthorityData.MessagesDistances, new List<double> { 500 });
        }

        [Fact]
        public void TestCalculatorWithRemoveElementsInPDirection()
        {
            TrainData.CalculatedPosition = 0;
            TrainData.LastCalculated = 500;
            TrainData.CalculatedDrivingDirection = "P";
            SetData();
            Calculator.Calculate(this);
            Assert.Equal(AuthorityData.SpeedDistances, new List<double> { 0, 0, 300, 500, 1050, 1500, 2040, 3000, 5310, 6500 });
            Assert.Equal(AuthorityData.Speeds, new List<double> { 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 });
            Assert.Equal(AuthorityData.Gradients, new List<int> { 10, 0, -2, 1, 5, -3 });
            Assert.Equal(AuthorityData.GradientsDistances, new List<double> { 0, 0, 550, 2000, 3000, 3500, 6500 });
            Assert.Equal(AuthorityData.Messages, new List<string> { "Test 2" });
            Assert.Equal(AuthorityData.MessagesDistances, new List<double> { 500 });
        }

        public void Dispose()
        {
            Calculator = null;
        }
    }
}
