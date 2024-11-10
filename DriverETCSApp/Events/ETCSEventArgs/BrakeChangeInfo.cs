using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class BrakeChangeInfo
    {
        public bool RequestBrake { get; set; }

        public BrakeChangeInfo()
        {

        }

        public BrakeChangeInfo(bool requestBrake)
        {
            RequestBrake = requestBrake;
        }
    }
}
