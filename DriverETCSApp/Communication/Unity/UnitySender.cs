﻿using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;
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
                messageType = "brake",
                BreakCommand = brakeCommand
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            var response = await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }
    }
}
