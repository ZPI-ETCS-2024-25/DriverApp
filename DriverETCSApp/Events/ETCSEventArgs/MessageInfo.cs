using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class MessageInfo : EventArgs
    {
        public string Message { get; set; }
        public string Time { get; set; }

        public MessageInfo(string time, string message) 
        { 
            Message = message;
            Time = time;
        }
    }
}
