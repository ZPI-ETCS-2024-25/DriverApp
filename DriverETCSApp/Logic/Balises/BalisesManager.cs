using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Balises
{
    public class BalisesManager
    {
        private ServerSender ServerSender;
        private string LastBaliseType;

        public BalisesManager()
        {
            ServerSender = new ServerSender("127.0.0.1", Port.Server);

            // "" (empty) -> wait for balises (probably RE), default, set to "" after OFF and balise RE
            //ON -> ETCS ON, wait for commands from balises
            //GO_OFF -> set at LTA balise (ETCS to SHP), should ignore RA, LTA, CLT commands
            //OFF -> set after LTO, should ignore every balises
            //Ignore_OFF -> set after ETCS is activated, require to ignore LTA and LTO messages
            LastBaliseType = "";
            ETCSEvents.ForceToChangeBaliseType += ForceChangeType;
        }

        public async void Manage(MessageFromBalise decodedMessage)
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                if(decodedMessage.kilometer.Equals(TrainData.BalisePosition))
                {
                    return;
                }

                //normal balise with information about position
                if (decodedMessage.messageType.Contains("CBF"))
                {
                    await Position(decodedMessage);
                }
                //force to change level to L2
                else if (decodedMessage.messageType.Contains("CLT"))
                {
                    await ForceToEnterETCSZone(decodedMessage);
                }
                //ack to change level (from L2 to STM or STM to L2)
                else if (decodedMessage.messageType.Contains("LTA"))
                {
                    await ChangeLevel(decodedMessage);
                }
                //start communication with RBC (server)
                else if (decodedMessage.messageType.Contains("RE"))
                {
                    await RegisterOnServer(decodedMessage);
                }
                //force to change level to STM
                else if (decodedMessage.messageType.Contains("LTO"))
                {
                    await ForceToEndOfETCSZone(decodedMessage);
                }
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }
        }

        private async Task Position(MessageFromBalise message)
        {
            if(LastBaliseType.Equals("OFF"))
            {
                TrainData.BalisePosition = message.kilometer;
                return;
            }

            if (!message.kilometer.Equals(TrainData.BalisePosition) && TrainData.IsConnectionWorking && TrainData.IsTrainRegisterOnServer)
            {
                TrainData.BalisePosition = message.kilometer;
                TrainData.BaliseLinePosition = message.lineNumber;
                TrainData.CalculatedPosition = Convert.ToDouble(message.kilometer) * 1000;

                if (message.numberOfBalises != 1)
                {
                    if (message.number == 1)
                    {
                        TrainData.CalculatedDrivingDirection = "N";
                    }
                    else if (message.number == message.numberOfBalises)
                    {
                        TrainData.CalculatedDrivingDirection = "P";
                    }
                }

                await ServerSender.SendPositionData(message.kilometer, message.trackNumber);
            }
        }

        private async Task ForceToEndOfETCSZone(MessageFromBalise message)
        {
            if (LastBaliseType.Equals("Ignore_OFF"))
            {
                await Position(message);
                return;
            }

            if (TrainData.IsConnectionWorking && TrainData.IsTrainRegisterOnServer)
            {
                if(TrainData.IsETCSActive)
                {
                    ETCSEvents.OnLevelChanged(new LevelInfo(Resources.SHP, false));
                }

                LastBaliseType = "OFF";
                await ServerSender.UnregisterTrainData();
            }
        }

        private async Task ForceToEnterETCSZone(MessageFromBalise message)
        {
            if (LastBaliseType.Equals("OFF"))
            {
                TrainData.BalisePosition = message.kilometer;
                return;
            }

            if (TrainData.IsConnectionWorking && TrainData.IsTrainRegisterOnServer)
            {
                if(!TrainData.IsETCSActive)
                {
                    ETCSEvents.OnLevelChanged(new LevelInfo(Resources.L2, true));
                }
                LastBaliseType = "Ignore_OFF";
                await Position(message);
            }
        }

        private async Task RegisterOnServer(MessageFromBalise message)
        {
            if(LastBaliseType.Equals("OFF"))
            {
                TrainData.BalisePosition = message.kilometer;
                return;
            }

            if (!TrainData.IsConnectionWorking && TrainData.IsTrainRegisterOnServer)
            {
                await ServerSender.SendTrainData();
            }

            LastBaliseType = "";
            await Position(message);
        }

        private async Task ChangeLevel(MessageFromBalise message)
        {
            if (!TrainData.IsConnectionWorking || !TrainData.IsTrainRegisterOnServer)
            {
                return;
            }

            //ACK to enter to ETCS zone
            if (LastBaliseType.Equals(""))
            {
                ETCSEvents.OnAckChanged(new AckInfo(Resources.L2AckWhite, Resources.L2AckYellow, Resources.L2, true));
            }
            //ACK to leave ETCS zone
            else if(LastBaliseType.Equals("ON"))
            {
                LastBaliseType = "GO_OFF";
                ETCSEvents.OnAckChanged(new AckInfo(Resources.SHPAckWhite, Resources.SHPAckYellow, Resources.SHP, false));
            }
            //at the beggining of ETCS zone
            else if(LastBaliseType.Equals("Ignore_OFF"))
            {
                LastBaliseType = "ON";
            }

            await Position(message);
        }

        private void ForceChangeType(object sender, BaliseInfo e)
        {
            LastBaliseType = e.Info;
        }
    }
}
