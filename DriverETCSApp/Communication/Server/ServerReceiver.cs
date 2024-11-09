using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Logic.Calculations;
using DriverETCSApp.Logic.Data;
using DriverETCSApp.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Server
{
    public class ServerReceiver
    {
        private LoadNewDataFromServer LoadNewDataFromServer;

        private static DateTime LastMessageDateTime = DateTime.Now;
        private static SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

        public ServerReceiver()
        {
            LoadNewDataFromServer = new LoadNewDataFromServer();

        }

        public async void Proccess(string message)
        {
            dynamic decodedMessage = JsonConvert.DeserializeObject(message);

            await Semaphore.WaitAsync();
            DateTime messageTime = DateTime.ParseExact(decodedMessage.GenTime.ToObject<string>(), "HH:mm:ss-dd-MM-yyyy", CultureInfo.InvariantCulture);
            if(messageTime <= LastMessageDateTime)
            {
                Console.WriteLine("Pomijanie wiadomości z serwera przez TimeGen");
                Semaphore.Release();
                return;
            }
            LastMessageDateTime = messageTime;
            Semaphore.Release();

            switch (decodedMessage.MessageType.ToString())
            {
                case "MA":
                    LoadNewAuthorityData(decodedMessage);
                    break;
                case "RE":
                    ConnectionWithRBC(decodedMessage);
                    break;
                case "LTO":
                    UnregisterRBC(decodedMessage);
                    break;
            }
        }

        private async void LoadNewAuthorityData(dynamic decodedMessage)
        {
            if (await LoadNewDataFromServer.LoadNewData(decodedMessage))
            {
                MaxSpeedsCalculation.Calculate(AuthorityData.Speeds, AuthorityData.SpeedDistances);
            }
        }
        private void ConnectionWithRBC(dynamic decodedMessage)
        {

            if (Convert.ToBoolean(decodedMessage.RegisterSuccess))
            {
                TrainData.IsTrainRegisterOnServer = true;
                TrainData.IsConnectionWorking = true;
                ETCSEvents.OnConnectionChanged(new Events.ETCSEventArgs.ConnectionInfo(Resources.ConnectionSet));
            }
            else
            {
                TrainData.IsTrainRegisterOnServer = false;
                TrainData.IsConnectionWorking = false;
                ETCSEvents.OnConnectionChanged(new Events.ETCSEventArgs.ConnectionInfo(null));
            }
        }

        private void UnregisterRBC(dynamic decodedMessage)
        {
            TrainData.IsTrainRegisterOnServer = false;
            TrainData.IsConnectionWorking = false;
            ETCSEvents.OnConnectionChanged(new Events.ETCSEventArgs.ConnectionInfo(null));
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
