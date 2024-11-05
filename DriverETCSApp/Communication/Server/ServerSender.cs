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
        private ServerReceiver ServerReceiver;
        private Port ServerPort;

        public ServerSender(string ip, Port port)
        {
            SenderHTTP = new SenderHTTP(ip);
            ServerReceiver = new ServerReceiver();
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
            var responce = await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "register");
            AnalyzeResponce(responce);
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
            var responce = await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "updatedata");
            AnalyzeResponce(responce);
        }

        public async Task UnregisterTrainData()
        {
            var data = new
            {
                TrainId = TrainData.TrainNumber
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            var responce = await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "unregister");
            AnalyzeResponce(responce);
        }

        public async Task SendPositionData(double kilometer, string track)
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
            var responce = await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "updateposition");
            AnalyzeResponce(responce);
        }

        public async Task SendMARequest()
        {
            var data = new
            {
                TrainId = TrainData.TrainNumber
            };
            string dataSerialized = JsonSerializer.Serialize(data);
            var responce = await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "marequest");
            AnalyzeResponce(responce);
        }

        public async Task SendSpeedUpdate(double currSpeed, string trainNumber)
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                var data = new
                {
                    TrainId = trainNumber,
                    Speed = currSpeed
                };
                string dataSerialized = JsonSerializer.Serialize(data);
                var responce = await SenderHTTP.SendMessageToEndpoint(dataSerialized, Port.Server, "speedupdate");
                //AnalyzeResponce(responce);
            }
            finally
            {
                Data.TrainData.TrainDataSemaphofe.Release();
            }
        }

        private void AnalyzeResponce(string responce)
        {
            if (string.IsNullOrEmpty(responce))
            {
                return;
            }

            ServerReceiver.Proccess(responce);
        }
    }
}
