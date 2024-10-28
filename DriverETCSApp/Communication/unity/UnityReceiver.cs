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
            MessageFromBalise decodedMessage = JsonConvert.DeserializeObject<MessageFromBalise>(message);

            BalisesManager.Manage(decodedMessage);
        }
    }
}