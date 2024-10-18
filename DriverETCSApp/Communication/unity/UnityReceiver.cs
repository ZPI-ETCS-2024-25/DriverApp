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

        public async void Proccess(string message)
        {
            MessageFromBalise decodedMessage = JsonConvert.DeserializeObject<MessageFromBalise>(message);
            decodedMessage.Kilometer = decodedMessage.Kilometer.Replace('.', ',');

            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
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
                else if (decodedMessage.MessageType.Contains("LTA"))
                {
                    Position(decodedMessage);
                }
                //start communication with RBC (server)
                else if (decodedMessage.MessageType.Contains("RE"))
                {
                    await RegisterOnServer(decodedMessage);
                    Position(decodedMessage);
                }
                //force to change level to STM
                else if (decodedMessage.MessageType.Contains("LTO"))
                {
                    await EndOfETCSZone(decodedMessage);
                }
            }
            finally
            {
                Data.TrainData.TrainDataSemaphofe.Release();
            }
        }

        private void Position(MessageFromBalise message)
        {
            if (!message.Kilometer.Equals(TrainData.BalisePosition))
            {
                TrainData.BalisePosition = message.Kilometer;
                TrainData.BaliseLinePosition = message.Line;
                TrainData.CalculatedPosition = Convert.ToInt32(Convert.ToDouble(message.Kilometer) * 100);

                if (message.GroupSize != 1)
                {
                    if (message.Number == 1)
                    {
                        TrainData.CalculatedDrivingDirection = "N";
                    }
                    else if (message.Number == message.GroupSize)
                    {
                        TrainData.CalculatedDrivingDirection = "P";
                    }
                }

                _ = ServerSender.SendPositionData(message.Kilometer, message.Track);
            }
        }

        private async Task EndOfETCSZone(MessageFromBalise message)
        {
            await ServerSender.UnregisterTrainData();
        }

        private async Task RegisterOnServer(MessageFromBalise message)
        {
            if (!TrainData.IsTrainRegisterOnServer)
            {
                await ServerSender.SendTrainData();
                TrainData.IsTrainRegisterOnServer = true;
            }
        }

        private async Task ForceToEnterETCSZone(MessageFromBalise message)
        {

        }
    }
}