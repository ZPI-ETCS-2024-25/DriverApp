using DriverETCSApp.Communication.Unity;
using DriverETCSApp.Data;
using DriverETCSApp.Forms.CForms;
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

            double currentSpeedLimitation = AuthorityData.Speeds.Count > 0 ? AuthorityData.Speeds[0] : 0; 

            if (TrainData.CurrentSpeed > currentSpeedLimitation && !isBraking) {
                UnitySender sender = new UnitySender("127.0.0.1", Port.Unity);
                _ = sender.SendBrakeSignal(true);
                isBraking = true;
                EmptyCForm.BrakingImage(true);
            }
            else if (TrainData.CurrentSpeed <= currentSpeedLimitation && isBraking) {
                UnitySender sender = new UnitySender("127.0.0.1", Port.Unity);
                _ = sender.SendBrakeSignal(false);
                isBraking = false;
                EmptyCForm.BrakingImage(false);
            }
        }
    }
}
