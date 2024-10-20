using DriverETCSApp.Data;
using DriverETCSApp.Logic.Data;
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
        private LoadNewDataFromServer LoadNewDataFromServer;

        public ServerReceiver() 
        {
            LoadNewDataFromServer = new LoadNewDataFromServer();
        }

        public void Proccess(string message)
        {
            dynamic decodedMessage = JsonConvert.DeserializeObject(message);
            if (decodedMessage.MessageType == "MA")
            {
                LoadNewAuthorityData(decodedMessage);
            }
        }

        private void LoadNewAuthorityData(dynamic decodedMessage)
        {
            lock (AuthorytiData.SpeedDistanceAndGradientLock) 
            {
                LoadNewDataFromServer.LoadNewData(decodedMessage);
            }
        }
    }
}

/*
{
    "MessageType" : "MA",
    "Speeds" : [200, 100, 200, 60, 0],
    "SpeedDistances" : [0, 2000, 2500, 5000, 5550],
    "Gradients" : [-2, 5, 3, 0, 7, -2, -1],
    "GradientsDistances" : [0, 300, 700, 1000, 1500, 2000, 4000, 5550]
}

{
    "MessageType" : "MA",
    "Speeds" : [250, 200, 160, 130, 100, 60, 50, 40, 0],
    "SpeedDistances" : [0, 1500, 2800, 4100, 4500, 5000, 5100, 6500, 8500],
    "Gradients" : [-2, 7, -5, 10, -15, 25, -33, 40, 5],
    "GradientsDistances" : [0, 100, 500, 1500, 2500, 2800, 3900, 5300, 6500, 8500]
}
*/
