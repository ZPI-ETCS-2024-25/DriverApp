using DriverETCSApp.Events.ETCSEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace DriverETCSApp.Events
{
    public static class ETCSEvents
    {
        public static event EventHandler<ModeInfo> ModeChanged;
        public static event EventHandler<ConnectionInfo> ConnectionChanged;
        public static event EventHandler<LevelInfo> LevelChanged;
        public static event EventHandler<AckInfo> AckChanged;
        public static event EventHandler<MessageInfo> NewSystemMessage;
        public static event EventHandler<ChangeLevelIcon> ChangeLevelIcon;
        public static event EventHandler MisionStarted;
        public static event EventHandler<BaliseInfo> ForceToChangeBaliseType;
        public static event EventHandler DistancesCalculationsCompleted;
        public static event EventHandler<BrakeChangeInfo> BrakeChange;

        public static void OnModeChanged(ModeInfo modeInfo)
        {
            ModeChanged?.Invoke(null, modeInfo);
        }

        public static void OnConnectionChanged(ConnectionInfo connectionInfo)
        {
            ConnectionChanged?.Invoke(null, connectionInfo);
        }

        public static void OnLevelChanged(LevelInfo levelInfo)
        {
            LevelChanged?.Invoke(null, levelInfo);
        }

        public static void OnAckChanged(AckInfo ackInfo)
        {
            AckChanged?.Invoke(null, ackInfo);
        }

        public static void OnNewSystemMessage(MessageInfo messageInfo)
        {
            NewSystemMessage?.Invoke(null, messageInfo);
        }

        public static void OnChangeLevelIcon(ChangeLevelIcon changeLevelIcon)
        {
            ChangeLevelIcon?.Invoke(null, changeLevelIcon);
        }

        public static void OnMisionStarted()
        {
            MisionStarted?.Invoke(null, EventArgs.Empty);
        }

        public static void OnForceToChangeBaliseType(BaliseInfo baliseInfo)
        {
            ForceToChangeBaliseType?.Invoke(null, baliseInfo);
        }

        public static void OnDistancesCalculationsCompleted()
        {
            DistancesCalculationsCompleted?.Invoke(null, EventArgs.Empty);
        }

        public static void OnBrakeChange(BrakeChangeInfo brakeChangeInfo)
        {
            BrakeChange?.Invoke(null, brakeChangeInfo);
        }
    }
}
