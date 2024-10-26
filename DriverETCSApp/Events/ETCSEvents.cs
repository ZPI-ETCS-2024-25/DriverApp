using DriverETCSApp.Events.ETCSEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Events
{
    public static class ETCSEvents
    {
        public static event EventHandler<ModeInfo> ModeChanged;
        public static event EventHandler<ConnectionInfo> ConnectionChanged;
        public static event EventHandler<LevelInfo> LevelChanged;
        public static event EventHandler<AckInfo> AckChanged;
        public static event EventHandler<MessageInfo> NewSystemMessage;
        public static event EventHandler ForceToChangeBaliseType;

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
    }
}
