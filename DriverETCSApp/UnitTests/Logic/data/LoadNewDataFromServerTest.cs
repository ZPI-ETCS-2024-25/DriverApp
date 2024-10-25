using Xunit;
using DriverETCSApp.Logic.Data;
using DriverETCSApp.Data;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DriverETCSApp.UnitTests.Logic.Data
{
    public class LoadNewDataFromServerTest
    {
        private LoadNewDataFromServer LoadNewDataFromServer;

        public LoadNewDataFromServerTest()
        {
            LoadNewDataFromServer = new LoadNewDataFromServer();
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
                    ""SpeedDistances"" : [500],
                    ""Gradients"" : [5],
                    ""GradientsDistances"" : [500],
                    ""Messages"" : [""TEST1""],
                    ""MessagesDistances"" : [20],
                    ""ServerPosition"" : 0
            }");
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            LoadNewDataFromServer.LoadNewData(msg);

            Assert.Equal(new List<double> { 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 500 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 500 }, AuthorityData.GradientsDistances);
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
                    ""SpeedDistances"" : [500],
                    ""Gradients"" : [5],
                    ""GradientsDistances"" : [500],
                    ""Messages"" : [""TEST1""],
                    ""MessagesDistances"" : [20],
                    ""ServerPosition"" : 0
            }");
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            LoadNewDataFromServer.LoadNewData(msg);

            Assert.Equal(new List<double> { 0 }, AuthorityData.Speeds);
            Assert.Equal(new List<double> { 500 }, AuthorityData.SpeedDistances);
            Assert.Equal(new List<int> { 5 }, AuthorityData.Gradients);
            Assert.Equal(new List<double> { 500 }, AuthorityData.GradientsDistances);
            Assert.Equal(new List<string> { "TEST1" }, AuthorityData.Messages);
            Assert.Equal(new List<double> { 20 }, AuthorityData.MessagesDistances);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }
    }
}
