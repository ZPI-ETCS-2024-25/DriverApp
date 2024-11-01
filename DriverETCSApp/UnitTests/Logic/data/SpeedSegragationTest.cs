using DriverETCSApp.Data;
using DriverETCSApp.Logic.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Data
{
    public class SpeedSegregationTest : IDisposable
    {
        private SpeedSegragation SpeedSegragation;
        public SpeedSegregationTest() 
        {
            SpeedSegragation = new SpeedSegragation();
        }

        [Fact]
        public void CheckSegregation()
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.SpeedDistances = new List<double> { 0, 150, 500, 800, 1000, 1550, 2000, 2540, 3500, 5810, 7000 };
            AuthorityData.Speeds = new List<double> { 100, 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 };

            SpeedSegragation.CalculateSpeeds();

            Assert.Equal(new List<double> { 150, 1550, 2000 }, AuthorityData.HigherDistances);
            Assert.Equal(new List<double> { 500, 800, 1000, 2540, 3500, 5810, 7000 }, AuthorityData.LowerDistances);
            Assert.Equal(new List<double> { 120, 100, 120 }, AuthorityData.HigherSpeed);
            Assert.Equal(new List<double> { 90, 80, 50, 50, 40, 20, 0 }, AuthorityData.LowerSpeed);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void CheckEmptySegregation()
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.SpeedDistances = new List<double> {  };
            AuthorityData.Speeds = new List<double> {  };

            SpeedSegragation.CalculateSpeeds();

            Assert.Equal(new List<double> { }, AuthorityData.HigherDistances);
            Assert.Equal(new List<double> { }, AuthorityData.LowerDistances);
            Assert.Equal(new List<double> { }, AuthorityData.HigherSpeed);
            Assert.Equal(new List<double> { }, AuthorityData.LowerSpeed);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void CheckZeroSegregation()
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.SpeedDistances = new List<double> { 0 };
            AuthorityData.Speeds = new List<double> { 0 };

            SpeedSegragation.CalculateSpeeds();

            Assert.Equal(new List<double> { }, AuthorityData.HigherDistances);
            Assert.Equal(new List<double> { }, AuthorityData.LowerDistances);
            Assert.Equal(new List<double> { }, AuthorityData.HigherSpeed);
            Assert.Equal(new List<double> { }, AuthorityData.LowerSpeed);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void CheckOneSegregation()
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.SpeedDistances = new List<double> { 0, 500 };
            AuthorityData.Speeds = new List<double> { 50, 0 };

            SpeedSegragation.CalculateSpeeds();

            Assert.Equal(new List<double> { }, AuthorityData.HigherDistances);
            Assert.Equal(new List<double> { 500 }, AuthorityData.LowerDistances);
            Assert.Equal(new List<double> { }, AuthorityData.HigherSpeed);
            Assert.Equal(new List<double> { 0 }, AuthorityData.LowerSpeed);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        public void Dispose()
        {
            SpeedSegragation = null;
        }
    }
}