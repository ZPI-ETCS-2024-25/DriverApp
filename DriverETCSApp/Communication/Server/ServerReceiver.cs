﻿using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Logic.Data;
using DriverETCSApp.Properties;
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
            switch (decodedMessage.MessageType)
            {
                case "MA":
                    LoadNewAuthorityData(decodedMessage);
                    break;
                case "RA":
                    ConnectionWithRBC(decodedMessage);
                    break;
            }
        }

        private void LoadNewAuthorityData(dynamic decodedMessage)
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            try
            {
                LoadNewDataFromServer.LoadNewData(decodedMessage);
            }
            finally
            {
                AuthorityData.AuthoritiyDataSemaphore.Release();
            }
        }

        private async void ConnectionWithRBC(dynamic decodedMessage)
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                if (decodedMessage.RegisterSuccess)
                {
                    TrainData.IsTrainRegisterOnServer = true;
                    TrainData.IsConnectionWorking = true;
                    ETCSEvents.OnConnectionChanged(new Events.ETCSEventArgs.ConnectionInfo(Resources.ConnectionSet));
                }
                else
                {
                    TrainData.IsTrainRegisterOnServer = false;
                    TrainData.IsConnectionWorking = false;
                }
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }
        }
    }
}

/*
{
    "MessageType" : "MA",
    "Speeds" : [250, 200, 160, 130, 100, 60, 50, 40, 0],
    "SpeedDistances" : [0, 1500, 2800, 4100, 4500, 5000, 5100, 6500, 8500],
    "Gradients" : [-2, 7, -5, 10, -15, 25, -33, 40, 5],
    "GradientsDistances" : [0, 100, 500, 1500, 2500, 2800, 3900, 5300, 6500, 8500],
    "Messages" : ["fefs"],
    "MessagesDistances" : [5000],
    "ServerPosition" : 5555
}
*/
