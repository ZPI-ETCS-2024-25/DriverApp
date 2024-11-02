using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations {
    public static class PositionApproximation {

        static private DateTime lastApproximation = DateTime.Now;

        public static double ApproximateMovedDistance() {
            TimeSpan timeDifference = DateTime.Now - lastApproximation;
            double currentSpeed = TrainData.CurrentSpeed;
            lastApproximation = DateTime.Now;

            return currentSpeed * timeDifference.TotalSeconds;
        }

        public static void ResetLastApproximationTimer() {
            lastApproximation = DateTime.Now;
        }
    }
}
