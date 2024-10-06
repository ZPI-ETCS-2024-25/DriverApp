using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp {
    internal abstract class Sender {
        protected string ip;

        public abstract void SendMessage(string msg, Port destination);

        public Sender(string ip) {
            this.ip = ip;
        }
    }
}
