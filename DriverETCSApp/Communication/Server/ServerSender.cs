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
                Type = "Register",
                TrainId = TrainData.TrainNumber,
                LengthMeters = TrainData.Length,
                MaxSpeed = TrainData.VMax,
                BrakeWeight = TrainData.BrakingMass
            };
            //serialize
            string dataSerialized = JsonSerializer.Serialize(data);
            TrainData.IsTrainRegisterOnServer = true;
            //send
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }

        public async Task UpdateTrainData(string oldNumber)
        {
            var data = new
            {
                Type = "UpdateData",
                TrainNumer = oldNumber,
                TrainId = TrainData.TrainNumber,
                LengthMeters = TrainData.Length,
                MaxSpeed = TrainData.VMax,
                BrakeWeight = TrainData.BrakingMass
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }

        public async Task UnregisterTrainData()
        {
            var data = new
            {
                Type = "Unregister",
                TrainId = TrainData.TrainNumber
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            TrainData.IsTrainRegisterOnServer = false;
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }

        public async Task SendPositionData(string kilometer, string track)
        {
            var data = new
            {
                Type = "UpdatePosition",
                TrainId = TrainData.TrainNumber,
                Kilometer = kilometer,
                Track = track,
                LineNumber = TrainData.BaliseLinePosition,
                Direction = TrainData.CalculatedDrivingDirection
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }

        public async Task SendMARequest()
        {
            var data = new
            {
                Type = "MARequest",
                TrainId = TrainData.TrainNumber
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }

        public async Task SendSpeedUpdate(double currSpeed)
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                var data = new
                {
                    Type = "SpeedUpdate",
                    TrainId = TrainData.TrainNumber,
                    Speed = currSpeed
                };
                string dataSerialized = JsonSerializer.Serialize(data);
                await SenderHTTP.SendMessage(dataSerialized, Port.Server);
            }
            finally
            {
                Data.TrainData.TrainDataSemaphofe.Release();
            }
        }
    }
}
