using DriverETCSApp.Data;
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
        private ServerSender ServerSender;

        public UnityReceiver() 
        {
            ServerSender = new ServerSender("127.0.0.1", Port.Server);
        }

        public void Proccess(string message) 
        {
            MessageFromBalise decodedMessage = JsonConvert.DeserializeObject<MessageFromBalise>(message);
            decodedMessage.Kilometer = decodedMessage.Kilometer.Replace('.', ',');

            //normal balise with information about position
            if (decodedMessage.MessageType.Contains("CBF"))
            {
                Position(decodedMessage);
            }
            //force to change level to L2
            else if (decodedMessage.MessageType.Contains("CLT"))
            {
                Position(decodedMessage);
            }
            //ack to change level (form L2 to STM or STM to L2)
            else if(decodedMessage.MessageType.Contains("LTA"))
            {
                Position(decodedMessage);
            }
            //start communication with RBC (server)
            else if (decodedMessage.MessageType.Contains("RE"))
            {
                Position(decodedMessage);
            }
            //force to change level to STM
            else if (decodedMessage.MessageType.Contains("LTO"))
            {
                EndOfETCSZone(decodedMessage);
            }
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

        private void EndOfETCSZone(MessageFromBalise message)
        {
            _ = ServerSender.UnregisterTrainData();
        }

        private async Task RegisterOnServer(MessageFromBalise message)
        {
            if (!TrainData.IsTrainRegisterOnServer)
            {
                await ServerSender.SendTrainData();
            }
            else
            {

            }
        }

        private void ForceToEnterETCSZone(MessageFromBalise message)
        {

        }
    }
}