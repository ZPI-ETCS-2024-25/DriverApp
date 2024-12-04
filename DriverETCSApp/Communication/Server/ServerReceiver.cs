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
        private DataEncryptDecrypt DataEncryptDecrypt;

        private static DateTime LastMessageDateTime = DateTime.Now;
        private static SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

        public ServerReceiver()
        {
            LoadNewDataFromServer = new LoadNewDataFromServer();
            DataEncryptDecrypt = new DataEncryptDecrypt(EncryptionData.Key, EncryptionData.IV);
        }

        public async void Proccess(string basicMessage)
        {
            dynamic decodedBasicMessage = JsonConvert.DeserializeObject(basicMessage);
            string message = decodedBasicMessage.Content.ToString();
            //string message = basicMessage;

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            string decryptedMessage = DataEncryptDecrypt.Decrypt(Convert.FromBase64String(message));
            dynamic decodedMessage = JsonConvert.DeserializeObject(decryptedMessage);
            //dynamic decodedMessage = JsonConvert.DeserializeObject(message);
            Console.WriteLine(decodedMessage);
            await Semaphore.WaitAsync();
            var s = decodedMessage["Timestamp"].ToString(Formatting.None).Trim('"');
            DateTime messageTime = DateTime.ParseExact(s, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture);
            if (messageTime <= LastMessageDateTime)
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

        private void LoadNewAuthorityData(dynamic decodedMessage)
        {
            LoadNewDataFromServer.LoadNewData(decodedMessage);
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
