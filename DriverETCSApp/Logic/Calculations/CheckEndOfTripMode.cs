using DriverETCSApp.Data;
using DriverETCSApp.Events;

namespace DriverETCSApp.Logic.Calculations
{
    public class CheckEndOfTripMode
    {
        public static bool IsTripAckActive = false;

        public CheckEndOfTripMode() { }

        public void CheckEndOfTrip()
        {
            if(TrainData.ActiveMode.Equals(ETCSModes.TR) && !IsTripAckActive)
            {
                if(TrainData.CurrentSpeed == 0)
                {
                    ETCSEvents.OnPostTripAck();
                    IsTripAckActive = true;
                }
            }
        }
    }
}
