using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class BaliseModeInfo : EventArgs
    {
        string Mode { get; set; }

        public BaliseModeInfo(string mode) 
        {
            Mode = mode;
        }
    }
}
