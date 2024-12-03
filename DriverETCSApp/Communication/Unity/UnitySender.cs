using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Unity
{
    public class UnitySender
    {
        private SenderHTTP SenderHTTP;
        private Port Port;

        public UnitySender(string ip, Port port)
        {
            SenderHTTP = new SenderHTTP(ip);
            Port = port;
        }

        public async Task SendBrakeSignal(bool brakeCommand) {
            var data = new {
                source = "DRIVER",
                messageType = "brake",
                BreakCommand = brakeCommand
            };
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            var response = await SenderHTTP.SendMessage(dataSerialized, Port.Unity);
        }

        public async Task SendIsAliveRequest()
        {
            var data = new
            {
                source = "DRIVER",
                messageType = "alive"
            };
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            var response = await SenderHTTP.SendMessage(dataSerialized, Port.Unity);
        }
    }
}
