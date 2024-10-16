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
            var data = new {
                TrainId = TrainData.TrainNumber,
                LengthMeters = TrainData.Length,
                MaxSpeed = TrainData.VMax,
                BrakeWeight = TrainData.BrakingMass
            };
            //serialize
            string dataSerialized = JsonSerializer.Serialize(data);
            //send
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }

        public async Task UpdateTrainData(string oldNumber)
        {
            //create data
            var data = new
            {
                TrainNumer = oldNumber,
                TrainId = TrainData.TrainNumber,
                LengthMeters = TrainData.Length,
                MaxSpeed = TrainData.VMax,
                BrakeWeight = TrainData.BrakingMass
            };
            //serialize
            string dataSerialized = JsonSerializer.Serialize(data);
            //send
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }

        public async Task UnregisterTrainData()
        {
            //create data
            var data = new
            {
                TrainId = TrainData.TrainNumber
            };
            //serialize
            string dataSerialized = JsonSerializer.Serialize(data);
            //send
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }

        public async Task SendPositionData(string kilometer, string track)
        {
            var data = new
            {
                TrainId = TrainData.TrainNumber,
                Kilometer = kilometer,
                Track = track
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            await SenderHTTP.SendMessage(dataSerialized, Port.Server);
        }
    }
}
