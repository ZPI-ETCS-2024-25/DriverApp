using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class BaliseInfo : EventArgs
    {
        public string Info { get; set; }

        public BaliseInfo(string info) 
        {
            Info = info;
        }
    }
}
