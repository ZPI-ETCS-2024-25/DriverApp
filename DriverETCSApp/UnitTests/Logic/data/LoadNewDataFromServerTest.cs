using Xunit;
using DriverETCSApp.Logic.Data;
using DriverETCSApp.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;

namespace DriverETCSApp.UnitTests.Logic.Data
{
    public class LoadNewDataFromServerTest : IDisposable
    {
        private LoadNewDataFromServer LoadNewDataFromServer;

        public LoadNewDataFromServerTest()
        {
            LoadNewDataFromServer = new LoadNewDataFromServer();

            TrainData.BaliseLinePosition = 1;
        }

        [Fact]
        public void EmptyTest()
        {
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : """",
                    ""Speeds"" : [],
                    ""SpeedDistances"" : [],
                    ""Gradients"" : [],
                    ""GradientsDistances"" : [],
                    ""Messages"" : [],
                    ""MessagesDistances"" : [],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 1000],
                    ""ServerPosition"" : 0
            }");
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            LoadNewDataFromServer.LoadNewData(msg);

            Assert.Equal(new List<double> { }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { }, AuthorityData.Messages);
            Assert.Equal(new List<double> { }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void SingleIterationTest()
        {
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [0],
                    ""SpeedDistances"" : [0],
                    ""Gradients"" : [5],
                    ""GradientsDistances"" : [0],
                    ""Messages"" : [""TEST1""],
                    ""MessagesDistances"" : [20],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 1000],
                    ""ServerPosition"" : 0
            }");
            
            TrainData.CalculatedPosition = 0;
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 20 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void MultipleIterationTest()
        {
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [100, 50, 0],
                    ""SpeedDistances"" : [0, 500, 1000, 2800],
                    ""Gradients"" : [5, 2, -3],
                    ""GradientsDistances"" : [0, 500, 1800, 2800],
                    ""Messages"" : [""TEST1"", ""Test""],
                    ""MessagesDistances"" : [20, 1000],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0
            }");

            TrainData.CalculatedPosition = 0;
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 100, 50, 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0, 500, 1000, 2800 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5, 2, -3 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0, 500, 1800, 2800 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1", "Test" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 20, 1000 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void SingleIterationNDirectionNegativeTest()
        {
            TrainData.CalculatedDrivingDirection = "N";
            TrainData.CalculatedPosition = 500;
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [0],
                    ""SpeedDistances"" : [0],
                    ""Gradients"" : [5],
                    ""GradientsDistances"" : [0],
                    ""Messages"" : [""TEST1""],
                    ""MessagesDistances"" : [0],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0.450
            }");
            
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { }, AuthorityData.Messages);
            Assert.Equal(new List<double> { }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void MultipleIterationNDirectionNegativeTest()
        {
            TrainData.CalculatedDrivingDirection = "N";
            TrainData.CalculatedPosition = 500;
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [100, 50, 0],
                    ""SpeedDistances"" : [0, 500, 1000, 2800],
                    ""Gradients"" : [5, 2, -3],
                    ""GradientsDistances"" : [0, 500, 1800, 2800],
                    ""Messages"" : [""TEST1"", ""Test""],
                    ""MessagesDistances"" : [120, 1000],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0.450
            }");
            
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 100, 50, 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0, 450, 950, 2750 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5, 2, -3 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0, 450, 1750, 2750 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1", "Test" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 70, 950 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void SingleIterationNDirectionPositiveTest()
        {
            TrainData.CalculatedDrivingDirection = "N";
            TrainData.CalculatedPosition = 500;
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [0],
                    ""SpeedDistances"" : [0],
                    ""Gradients"" : [5],
                    ""GradientsDistances"" : [0],
                    ""Messages"" : [""TEST1""],
                    ""MessagesDistances"" : [0],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0.550
            }");
            
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 0 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void MultipleIterationNDirectionPositiveTest()
        {
            TrainData.CalculatedDrivingDirection = "N";
            TrainData.CalculatedPosition = 500;
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [100, 50, 0],
                    ""SpeedDistances"" : [0, 500, 1000, 2800],
                    ""Gradients"" : [5, 2, -3],
                    ""GradientsDistances"" : [0, 500, 1800, 2800],
                    ""Messages"" : [""TEST1"", ""Test""],
                    ""MessagesDistances"" : [120, 1000],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0.550
            }");
            
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 100, 50, 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0, 550, 1050, 2850 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5, 2, -3 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0, 550, 1850, 2850 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1", "Test" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 170, 1050 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void SingleIterationPDirectionNegativeTest()
        {
            TrainData.CalculatedDrivingDirection = "P";
            TrainData.CalculatedPosition = 450;
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [0],
                    ""SpeedDistances"" : [0],
                    ""Gradients"" : [5],
                    ""GradientsDistances"" : [0],
                    ""Messages"" : [""TEST1""],
                    ""MessagesDistances"" : [0],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0.500
            }");
            
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { }, AuthorityData.Messages);
            Assert.Equal(new List<double> { }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void MultipleIterationPDirectionNegativeTest()
        {
            TrainData.CalculatedDrivingDirection = "P";
            TrainData.CalculatedPosition = 450;
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [100, 50, 0],
                    ""SpeedDistances"" : [0, 500, 1000, 2800],
                    ""Gradients"" : [5, 2, -3],
                    ""GradientsDistances"" : [0, 500, 1800, 2800],
                    ""Messages"" : [""TEST1"", ""Test""],
                    ""MessagesDistances"" : [120, 1000],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0.500
            }");
            
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 100, 50, 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0, 450, 950, 2750 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5, 2, -3 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0, 450, 1750, 2750 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1", "Test" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 70, 950 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void SingleIterationPDirectionPositiveTest()
        {
            TrainData.CalculatedDrivingDirection = "P";
            TrainData.CalculatedPosition = 550;
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [0],
                    ""SpeedDistances"" : [0],
                    ""Gradients"" : [5],
                    ""GradientsDistances"" : [0],
                    ""Messages"" : [""TEST1""],
                    ""MessagesDistances"" : [0],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0.500
            }");
            
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 0 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void MultipleIterationPDirectionPositiveTest()
        {
            TrainData.CalculatedDrivingDirection = "P";
            TrainData.CalculatedPosition = 550;
            dynamic msg = JsonConvert.DeserializeObject(@"
            {
                    ""MessageType"" : ""MA"",
                    ""Speeds"" : [100, 50, 0],
                    ""SpeedDistances"" : [0, 500, 1000, 2800],
                    ""Gradients"" : [5, 2, -3],
                    ""GradientsDistances"" : [0, 500, 1800, 2800],
                    ""Messages"" : [""TEST1"", ""Test""],
                    ""MessagesDistances"" : [120, 1000],
                    ""Lines"" : [1],
                    ""LinesDistances"" : [0, 2800],
                    ""ServerPosition"" : 0.500
            }");
            
            LoadNewDataFromServer.LoadNewData(msg);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            Assert.Equal(new List<double> { 100, 50, 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 0, 550, 1050, 2850 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5, 2, -3 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 0, 550, 1850, 2850 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1", "Test" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 170, 1050 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        public void Dispose()
        {
            LoadNewDataFromServer = null;
        }
    }
}
