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
                    await Position(decodedMessage);
                }
                //force to change level to L2
                else if (decodedMessage.MessageType.Contains("CLT"))
                {
                    //await ForceToEnterETCSZone(decodedMessage);
                    await Position(decodedMessage);
                }
                //ack to change level (form L2 to STM or STM to L2)
                else if (decodedMessage.MessageType.Contains("LTA"))
                {
                    await SendMARequest(decodedMessage);
                    await Position(decodedMessage);
                }
                //start communication with RBC (server)
                else if (decodedMessage.MessageType.Contains("RE"))
                {
                    await RegisterOnServer(decodedMessage);
                    await Position(decodedMessage);
                }
                //force to change level to STM
                else if (decodedMessage.MessageType.Contains("LTO"))
                {
                    await ForceToEndOfETCSZone(decodedMessage);
                }
            }
            finally
            {
                Data.TrainData.TrainDataSemaphofe.Release();
            }
        }

        private async Task Position(MessageFromBalise message)
        {
            if (!message.Kilometer.Equals(TrainData.BalisePosition) && TrainData.IsTrainRegisterOnServer)
            {
                TrainData.BalisePosition = message.Kilometer;
                TrainData.BaliseLinePosition = message.Line;
                TrainData.CalculatedPosition = Convert.ToDouble(message.Kilometer) * 1000;
                TrainData.LastCalculated = TrainData.CalculatedPosition;

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

                await ServerSender.SendPositionData(message.Kilometer, message.Track);
            }
        }

        private async Task ForceToEndOfETCSZone(MessageFromBalise message)
        {
            if (TrainData.IsTrainRegisterOnServer)
            {
                await ServerSender.UnregisterTrainData();
            }
        }

        private async Task RegisterOnServer(MessageFromBalise message)
        {
            if (!TrainData.IsTrainRegisterOnServer)
            {
                await ServerSender.SendTrainData();
            }
        }

        private async Task SendMARequest(MessageFromBalise message)
        {
            if (TrainData.IsTrainRegisterOnServer) //tutaj potem dodaæ sprawdzanie czy ETCS ju¿ nie jest aktywny
            {
                await ServerSender.SendMARequest();
            }
        }
    }
}