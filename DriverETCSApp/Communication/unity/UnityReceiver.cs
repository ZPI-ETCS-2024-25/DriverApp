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

        public UnityReceiver()
        {
            BalisesManager = new BalisesManager();
        }

        public void Proccess(string message)
        {
            dynamic decodedMessage = JsonConvert.DeserializeObject(message);
            switch (decodedMessage.MessageType.ToString()) {
                case "FB": //From Balise
                    SetDistanceFromBalise(message);
                    break;
                case "NS": //New speed
                    SpeedChanged(message);
                    break;
            }
        }

        private void SetDistanceFromBalise(dynamic message) {
            MessageFromBalise decodedMessage = JsonConvert.DeserializeObject<MessageFromBalise>(message);
            BalisesManager.Manage(decodedMessage);
        }

        private void SpeedChanged(dynamic message) {
            SpeedData speedData = JsonConvert.DeserializeObject<SpeedData>(message);
            TrainData.CurrentSpeed = speedData.NewSpeed;
        }
    }
}