using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriverETCSApp.Forms.EForms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.EForms
{
    public class MessageTest
    {
        [Fact]
        public void Test()
        {
            var now = DateTime.Now.ToString("HH:mm");
            var msg = "Test";
            var message = new Message(now, msg);

            Assert.Equal(now, message.date);
            Assert.Equal(msg, message.message);
            Assert.Equal(30, message.timeToDie);
            Assert.False(message.IsExpired());
        }
    }
}
