using DriverETCSApp.Communication.Unity;
using DriverETCSApp.Data;
using DriverETCSApp.Forms.EForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations {
    public static class EmergencyBrakeManager {

        private static bool isBraking = false;

        public static void CheckSpeed() {
            
            if (TrainData.CurrentSpeed > AuthorityData.currentSpeedLimit && !isBraking) {
                UnitySender sender = new UnitySender("127.0.0.1", Port.Unity);
                _ = sender.SendBrakeSignal(true);
                isBraking = true;
                MessagesForm.BrakingImage(true);
            }
            else if (TrainData.CurrentSpeed <= AuthorityData.currentSpeedLimit && isBraking) {
                UnitySender sender = new UnitySender("127.0.0.1", Port.Unity);
                _ = sender.SendBrakeSignal(false);
                isBraking = false;
                MessagesForm.BrakingImage(false);
            }
        }
    }
}
