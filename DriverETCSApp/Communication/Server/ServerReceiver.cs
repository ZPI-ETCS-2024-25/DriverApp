using DriverETCSApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Server
{
    public class ServerReceiver
    {
        public ServerReceiver() { }

        public void Proccess(string message)
        {
            dynamic decodedMessage = JsonConvert.DeserializeObject(message);
            if (decodedMessage.MessageType.Equals("MA"))
            {
                LoadNewAuthorityData(decodedMessage);
            }
        }

        private void LoadNewAuthorityData(dynamic decodedMessage)
        {
            lock (TrainSpeedsAndDistances.SpeedDistanceAndGradientLock) 
            {
                TrainSpeedsAndDistances.Speeds = decodedMessage.Speeds;
                TrainSpeedsAndDistances.SpeedDistances = decodedMessage.SpeedDistances;
                TrainSpeedsAndDistances.Gradients = decodedMessage.Gradients;
                TrainSpeedsAndDistances.GradientsDistances = decodedMessage.GradientsDistances;
            }
        }
    }
}
