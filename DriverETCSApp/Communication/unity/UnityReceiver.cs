using DriverETCSApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Server
{
    public class UnityReceiver
    {
        private ServerSender ServerSender;

        public UnityReceiver() 
        {
            ServerSender = new ServerSender("127.0.0.1", Port.Server);
        }

        public void Proccess(string message) 
        {
            MessageFromBalise decodedMessage = JsonConvert.DeserializeObject<MessageFromBalise>(message);
            decodedMessage.Kilometer = decodedMessage.Kilometer.Replace('.', ',');
            Position(decodedMessage);
        }

        private void Position(MessageFromBalise message)
        {
            if (!message.Kilometer.Equals(TrainData.BalisePosition))
            {
                TrainData.BalisePosition = message.Kilometer;
                TrainData.BaliseLinePosition = message.LineNumber;
                TrainData.CalculatedPosition = Convert.ToInt32(Convert.ToDouble(message.Kilometer) * 100);

                if (message.NumberOfBalises != 1)
                {
                    if (message.Number == 1)
                    {
                        TrainData.CalculatedDrivingDirection = "N";
                    }
                    else if(message.Number == message.NumberOfBalises)
                    {
                        TrainData.CalculatedDrivingDirection = "P";
                    }
                }

                _ = ServerSender.SendPositionData(message.Kilometer, message.TrackNumber);
            }
        }
    }
}