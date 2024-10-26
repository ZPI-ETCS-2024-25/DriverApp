using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Server
{
    public class ServerSender
    {
        private SenderHTTP SenderHTTP;
        private Port ServerPort;

        public ServerSender(string ip, Port port)
        {
            SenderHTTP = new SenderHTTP(ip);
            ServerPort = port;
        }

        public async Task SendTrainData()
        {
            //create data
            var data = new
            {
                TrainId = TrainData.TrainNumber,
                LengthMeters = TrainData.Length,
                MaxSpeed = TrainData.VMax,
                BrakeWeight = TrainData.BrakingMass
            };
            //serialize
            string dataSerialized = JsonSerializer.Serialize(data);
            //send
            await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "register");
        }

        public async Task UpdateTrainData(string oldNumber)
        {
            var data = new
            {
                TrainNumer = oldNumber,
                TrainId = TrainData.TrainNumber,
                LengthMeters = TrainData.Length,
                MaxSpeed = TrainData.VMax,
                BrakeWeight = TrainData.BrakingMass
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "updatedata");
        }

        public async Task UnregisterTrainData()
        {
            var data = new
            {
                TrainId = TrainData.TrainNumber
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            TrainData.IsTrainRegisterOnServer = false;
            await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "unregister");
        }

        public async Task SendPositionData(string kilometer, string track)
        {
            var data = new
            {
                TrainId = TrainData.TrainNumber,
                Kilometer = kilometer,
                Track = track,
                LineNumber = TrainData.BaliseLinePosition,
                Direction = TrainData.CalculatedDrivingDirection
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "updateposition");
        }

        public async Task SendMARequest()
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            var data = new
            {
                TrainId = TrainData.TrainNumber
            };
            TrainData.TrainDataSemaphofe.Release();
            string dataSerialized = JsonSerializer.Serialize(data);
            await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "marequest");
        }

        public async Task SendSpeedUpdate(double currSpeed)
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                var data = new
                {
                    TrainId = TrainData.TrainNumber,
                    Speed = currSpeed
                };
                string dataSerialized = JsonSerializer.Serialize(data);
                await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "speedupdate");
            }
            finally
            {
                Data.TrainData.TrainDataSemaphofe.Release();
            }
        }
    }
}
