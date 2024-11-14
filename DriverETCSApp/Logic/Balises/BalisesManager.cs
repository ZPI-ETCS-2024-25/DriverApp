using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Logic.Calculations;
using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Balises
{
    public class BalisesManager : IDisposable
    {
        private ServerSender ServerSender;
        private string LastBaliseType;
        Dictionary<string, Func<MessageFromBalise, Task>> Dict;

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
            Dict = new Dictionary<string, Func<MessageFromBalise, Task>>();
            Dict["CBF"] = Position;
            Dict["CLT"] = ForceToEnterETCSZone;
            Dict["LTA"] = ChangeLevel;
            Dict["RE"] = RegisterOnServer;
            Dict["LTO"] = ForceToEndOfETCSZone;
        }

        public async void Manage(MessageFromBalise decodedMessage)
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                if (decodedMessage.kilometer.Equals(TrainData.BalisePosition)
                    && decodedMessage.trackNumber.Equals(TrainData.BaliseTrackPosition)
                    && decodedMessage.lineNumber == TrainData.BaliseLinePosition)
                {
                    return;
                }

                await Dict[decodedMessage.messageType](decodedMessage);
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }
        }

        private async Task Position(MessageFromBalise message)
        {
            if (LastBaliseType.Equals("OFF"))
            {
                TrainData.BalisePosition = message.kilometer;
                return;
            }

            TrainData.CalculatedPosition += PositionApproximation.ApproximateMovedDistance();

            var tmp = Math.Abs(TrainData.CalculatedPosition - TrainData.LastCalculated);

            TrainData.BalisePosition = message.kilometer;

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

            if (message.lineNumber != TrainData.BaliseLinePosition && !TrainData.BaliseTrackPosition.Equals(""))
            {
                TrainData.LastCalculated = TrainData.CalculatedDrivingDirection.Equals("N") ? message.kilometer * 1000 - tmp : message.kilometer * 1000 + tmp;
            }
            else if(TrainData.BaliseTrackPosition != message.trackNumber && !TrainData.BaliseTrackPosition.Equals(""))
            {
                TrainData.LastCalculated -= 20;
            }

            TrainData.BaliseLinePosition = message.lineNumber;
            TrainData.BaliseTrackPosition = message.trackNumber;
            TrainData.CalculatedPosition = Convert.ToDouble(message.kilometer) * 1000;
            if(TrainData.LastCalculated == 0)
            {
                TrainData.LastCalculated = TrainData.CalculatedPosition;
            }

            if (TrainData.IsConnectionWorking && TrainData.IsTrainRegisterOnServer)
            {
                //_ = ServerSender.SendPositionData(message.kilometer, message.trackNumber);
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

            TrainData.BalisePosition = message.kilometer;
            TrainData.CalculatedPosition = Convert.ToDouble(message.kilometer) * 1000;
            if (TrainData.IsConnectionWorking && TrainData.IsTrainRegisterOnServer)
            {
                if (TrainData.IsETCSActive)
                {
                    ETCSEvents.OnLevelChanged(new LevelInfo(Resources.SHP, false));
                }

                LastBaliseType = "OFF";
                await ServerSender.UnregisterTrainData();
                TrainData.IsConnectionWorking = false;
                TrainData.IsTrainRegisterOnServer = false;
                ETCSEvents.OnConnectionChanged(new ConnectionInfo(null));
            }
        }

        private async Task ForceToEnterETCSZone(MessageFromBalise message)
        {
            if (LastBaliseType.Equals("OFF") || LastBaliseType.Equals("GO_OFF"))
            {
                TrainData.BalisePosition = message.kilometer;
                TrainData.CalculatedPosition = Convert.ToDouble(message.kilometer) * 1000;
                return;
            }

            if (TrainData.IsConnectionWorking && TrainData.IsTrainRegisterOnServer)
            {
                if (!TrainData.IsETCSActive)
                {
                    ETCSEvents.OnLevelChanged(new LevelInfo(Resources.L2, true));
                    LastBaliseType = "Ignore_OFF";
                }
                else if(TrainData.ActiveMode.Equals(ETCSModes.OS))
                {
                    if (ServerSender != null)
                    {
                        TrainData.BalisePosition = message.kilometer;
                        TrainData.CalculatedPosition = Convert.ToDouble(message.kilometer) * 1000;
                        await Position(message);
                        await ServerSender?.SendMARequest();
                        ETCSEvents.OnModeChanged(new ModeInfo(Resources.FS, ETCSModes.FS));
                        return;
                    }
                }
            }
            await Position(message);
        }

        private async Task RegisterOnServer(MessageFromBalise message)
        {
            if (LastBaliseType.Equals("OFF") || LastBaliseType.Equals("GO_OFF"))
            {
                TrainData.BalisePosition = message.kilometer;
                TrainData.CalculatedPosition = message.kilometer * 1000;
                LastBaliseType = "";
                return;
            }

            LastBaliseType = "";
            if (!TrainData.IsConnectionWorking && !TrainData.IsTrainRegisterOnServer)
            {
                await ServerSender.SendTrainData();
            }

            await Position(message);
        }

        private async Task ChangeLevel(MessageFromBalise message)
        {
            if (!TrainData.IsConnectionWorking || !TrainData.IsTrainRegisterOnServer)
            {
                TrainData.BalisePosition = message.kilometer;
                TrainData.CalculatedPosition = message.kilometer * 1000;
                return;
            }

            //ACK to enter to ETCS zone
            if (LastBaliseType.Equals(""))
            {
                ETCSEvents.OnAckChanged(new AckInfo(Resources.L2AckWhite, Resources.L2AckYellow, Resources.L2, true));
            }
            //ACK to leave ETCS zone
            else if (LastBaliseType.Equals("ON"))
            {
                LastBaliseType = "GO_OFF";
                ETCSEvents.OnAckChanged(new AckInfo(Resources.SHPAckWhite, Resources.SHPAckYellow, Resources.SHP, false));
            }
            //at the beggining of ETCS zone
            else if (LastBaliseType.Equals("Ignore_OFF"))
            {
                TrainData.BalisePosition = message.kilometer;
                TrainData.CalculatedPosition = message.kilometer * 1000;
                LastBaliseType = "ON";
            }
            else if (LastBaliseType.Equals("OFF"))
            {
                return;
            }

            await Position(message);
        }

        private void ForceChangeType(object sender, BaliseInfo e)
        {
            LastBaliseType = e.Info;
        }

        public string GetLastBaliseType()
        {
            return LastBaliseType;
        }

        public void Dispose()
        {
            ETCSEvents.ForceToChangeBaliseType -= ForceChangeType;
        }
    }
}
