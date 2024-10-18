using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Unity
{
    public class UnitySender
    {
        private SenderHTTP SenderHTTP;
        private Port Port;

        public UnitySender(string ip, Port port) 
        {
            SenderHTTP = new SenderHTTP(ip);
            Port = port;
        }
    }
}
