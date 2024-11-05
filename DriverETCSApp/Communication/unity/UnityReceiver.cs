using DriverETCSApp.Communication.Unity;
using DriverETCSApp.Data;
using DriverETCSApp.Logic.Balises;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Server
{
    public class UnityReceiver
    {
        private BalisesManager BalisesManager;
        
        private DateTime lastSpeedSend = DateTime.Now;
        private const int secondsToSend = 2;

        public UnityReceiver()
        {
            BalisesManager = new BalisesManager();
        }

        public void Proccess(string message)
        {
            dynamic decodedMessage = JsonConvert.DeserializeObject(message);
            switch (decodedMessage.messageType.ToString()) {
                case "NS": //New speed
                    SpeedChanged(message);
                    break;
                default: //From Balise
                    SetDistanceFromBalise(message);
                    break;
            }
        }

        private void SetDistanceFromBalise(dynamic message) {
            MessageFromBalise decodedMessage = JsonConvert.DeserializeObject<MessageFromBalise>(message);
            BalisesManager.Manage(decodedMessage);
        }

        private async void SpeedChanged(dynamic message) {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                SpeedData speedData = JsonConvert.DeserializeObject<SpeedData>(message);
                TrainData.CurrentSpeed = speedData.NewSpeed;
                Forms.BForms.SpeedmeterForm.SetSpeed((int)speedData.NewSpeed);

                if ((DateTime.Now - lastSpeedSend).TotalSeconds > secondsToSend)
                {
                    ServerSender sender = new ServerSender("127.0.0.1", Port.Server);
                    _ = sender.SendSpeedUpdate(speedData.NewSpeed);
                    lastSpeedSend = DateTime.Now;
                }
                if(TrainData.CurrentSpeed > AuthorityData.MaxSpeeds[0]) {
                    UnitySender sender = new UnitySender("127.0.0.1", Port.Unity);
                    _ = sender.SendBrakeSignal();
                }

            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }
        }
    }
}