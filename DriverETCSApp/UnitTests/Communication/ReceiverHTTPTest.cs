using DriverETCSApp.Communication;
using DriverETCSApp.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Communication
{
    public class ReceiverHTTPTest
    {
        private ReceiverHTTP ReceiverHTTP;

        public ReceiverHTTPTest()
        {
            ReceiverHTTP = new ReceiverHTTP("127.0.0.1");
        }

        [Fact]
        public void TestReceiverHTTP()
        {
            ReceiverHTTP.StartListening();
            Assert.True(ReceiverHTTP.IsListening());
            ReceiverHTTP.StopListening();
            Assert.False(ReceiverHTTP.IsListening());
        }
    }
}
