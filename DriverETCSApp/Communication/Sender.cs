using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication
{
    public abstract class Sender {
        protected string ip;

        public abstract Task<string> SendMessage(string msg, Port destination);
        public abstract Task<string> SendMessageToEndpoint(string msg, Port destination, string endpoint);

        public Sender(string ip) {
            this.ip = ip;
        }
    }
}
