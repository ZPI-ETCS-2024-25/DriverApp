using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations
{
    public class CheckEndOfTripMode
    {
        public CheckEndOfTripMode() { }

        public void CheckEndOfTrip()
        {
            if(TrainData.ActiveMode.Equals(ETCSModes.TR))
            {
                if(TrainData.CurrentSpeed == 0)
                {

                }
            }
        }
    }
}
