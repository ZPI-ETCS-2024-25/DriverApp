using DriverETCSApp.Communication.Unity;
using DriverETCSApp.Data;
using DriverETCSApp.Logic.Balises;
using DriverETCSApp.Logic.Calculations;
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
        private CheckEndOfTripMode CheckEndOfTripMode;
        
        private DateTime lastSpeedSend = DateTime.Now;
        private const int secondsToSend = 2;
        private ServerSender sender;

        public UnityReceiver()
        {
            BalisesManager = new BalisesManager();
            CheckEndOfTripMode = new CheckEndOfTripMode();
            sender = new ServerSender("127.0.0.1", Port.Server);
        }

        public void Proccess(string message)
        {
            dynamic decodedMessage = JsonConvert.DeserializeObject(message);
            switch (decodedMessage.messageType.ToString()) {
                case "NS": //New speed
                    SpeedChanged(message);
                    break;
                case "isAlive":
                    isAlive(decodedMessage);
                    break;
                default: //From Balise
                    SetDistanceFromBalise(decodedMessage);
                    break;
            }
        }

        private void SetDistanceFromBalise(dynamic message) {
            string tmp = message.kilometer.ToString();
            tmp = tmp.Replace(",", ".");
            message.kilometer = tmp;
            MessageFromBalise decodedMessage = JsonConvert.DeserializeObject<MessageFromBalise>(message.ToString());
            BalisesManager.Manage(decodedMessage);
        }

        private void isAlive(dynamic message)
        {
            TrainData.isUnityAlive = message.isAlive;
        }

        public async void SpeedChanged(string message) {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                SpeedData speedData = JsonConvert.DeserializeObject<SpeedData>(message);
                TrainData.CurrentSpeed = speedData.NewSpeed;
                Forms.BForms.SpeedmeterForm.SetSpeed((int)speedData.NewSpeed);
                Forms.BForms.SpeedmeterForm.GetInstance().InvalidateClockPanel();

                if ((DateTime.Now - lastSpeedSend).TotalSeconds > secondsToSend)
                {
                    sender.SendSpeedUpdate(speedData.NewSpeed, TrainData.TrainNumber);
                    lastSpeedSend = DateTime.Now;
                }
                EmergencyBrakeManager.CheckSpeed();
                CheckEndOfTripMode.CheckEndOfTrip();
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }
        }
    }
}