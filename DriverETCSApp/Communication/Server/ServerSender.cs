﻿using DriverETCSApp.Data;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Server
{
    public class ServerSender
    {
        private SenderHTTP SenderHTTP;
        private ServerReceiver ServerReceiver;
        private Port ServerPort;
        private DataEncryptDecrypt DataEncryptDecrypt;

        public ServerSender(string ip, Port port)
        {
            SenderHTTP = new SenderHTTP(ip);
            ServerReceiver = new ServerReceiver();
            ServerPort = port;
            DataEncryptDecrypt = new DataEncryptDecrypt(EncryptionData.Key, EncryptionData.IV);
        }

        public async Task SendTrainData()
        {
            //create data
            var data = new
            {
                TrainId = TrainData.TrainNumber,
                LengthMeters = string.IsNullOrEmpty(TrainData.Length) ? 0 : Int32.Parse(TrainData.Length),
                MaxSpeed = string.IsNullOrEmpty(TrainData.VMax) ? 0 : Int32.Parse(TrainData.VMax),
                BrakeWeight = string.IsNullOrEmpty(TrainData.BrakingMass) ? 0 : Int32.Parse(TrainData.BrakingMass)
            };
            //serialize
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            string dataEncrypted = Convert.ToBase64String(DataEncryptDecrypt.Encrypt(dataSerialized));
            //send
            var responce = await SenderHTTP.SendMessageToEndpoint(dataEncrypted, Port.Server, "register");
            AnalyzeResponce(responce);
        }

        public async Task UpdateTrainData(string oldNumber)
        {
            var data = new
            {
                TrainNumer = oldNumber,
                TrainId = TrainData.TrainNumber,
                LengthMeters = string.IsNullOrEmpty(TrainData.Length) ? 0 : Int32.Parse(TrainData.Length),
                MaxSpeed = string.IsNullOrEmpty(TrainData.VMax) ? 0 : Int32.Parse(TrainData.VMax),
                BrakeWeight = string.IsNullOrEmpty(TrainData.BrakingMass) ? 0 : Int32.Parse(TrainData.BrakingMass)
            };
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            string dataEncrypted = Convert.ToBase64String(DataEncryptDecrypt.Encrypt(dataSerialized));
            var responce = await SenderHTTP.SendMessageToEndpoint(dataEncrypted, Port.Server, "updatedata");
            //AnalyzeResponce(responce);
        }

        public async Task UnregisterTrainData()
        {
            var data = new
            {
                TrainId = TrainData.TrainNumber
            };
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            string dataEncrypted = Convert.ToBase64String(DataEncryptDecrypt.Encrypt(dataSerialized));
            var responce = await SenderHTTP.SendMessageToEndpoint(dataEncrypted, Port.Server, "unregister");
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
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            string dataEncrypted = Convert.ToBase64String(DataEncryptDecrypt.Encrypt(dataSerialized));
            var responce = await SenderHTTP.SendMessageToEndpoint(dataEncrypted, Port.Server, "updateposition");
            //AnalyzeResponce(responce);
        }

        public async Task SendMARequest()
        {
            var data = new
            {
                TrainId = TrainData.TrainNumber
            };
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            string dataEncrypted = Convert.ToBase64String(DataEncryptDecrypt.Encrypt(dataSerialized));
            var responce = await SenderHTTP.SendMessageToEndpoint(dataEncrypted, Port.Server, "marequest");
            AnalyzeResponce(responce);
        }

        public void SendSpeedUpdate(double currSpeed, string trainNumber)
        {
            var data = new
            {
                TrainId = trainNumber,
                Speed = currSpeed
            };
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            string dataEncrypted = Convert.ToBase64String(DataEncryptDecrypt.Encrypt(dataSerialized));
            _ = SenderHTTP.SendMessageToEndpoint(dataEncrypted, Port.Server, "speedupdate");
            //AnalyzeResponce(responce);
        }

        public async Task<bool> SendIsAliveRequest()
        {
            var data = new
            {
                TrainId = 0
            };
            string dataSerialized = System.Text.Json.JsonSerializer.Serialize(data);
            string dataEncrypted = Convert.ToBase64String(DataEncryptDecrypt.Encrypt(dataSerialized));
            var isAlive = await SenderHTTP.SendMessageToEndpoint(dataEncrypted, Port.Server, "alive");

            if (string.IsNullOrEmpty(isAlive))
            {
                return false;
            }

            dynamic decodedMessage1 = JsonConvert.DeserializeObject<JsonObject>(isAlive);
            string decryptedMessage = DataEncryptDecrypt.Decrypt(Convert.FromBase64String(decodedMessage1.Content));
            dynamic decodedMessage = JsonConvert.DeserializeObject(decryptedMessage);
            bool value = decodedMessage.IsAlive;
            return value;
        }

        private void AnalyzeResponce(string responce)
        {
            if (string.IsNullOrEmpty(responce))
            {
                return;
            }

            ServerReceiver.Proccess(responce);
        }

        private class JsonObject
        {
            public string Content { get; set; }
        }
    }
}
