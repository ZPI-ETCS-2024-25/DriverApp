using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication {
    internal abstract class Receiver {
        protected string ip;
        protected Port port = Port.DriverApp;

        public abstract void StartListening();
        public abstract void StopListening();
        protected abstract void HandleIncomingConnection();

        public Receiver(string ip) {
            this.ip = ip;
        }
    }
}
