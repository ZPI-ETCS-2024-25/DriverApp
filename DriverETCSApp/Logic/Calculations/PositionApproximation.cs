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
            double currentSpeed = TrainData.CurrentSpeed / 3.6;
            double lastSpeed = TrainData.LastSpeed / 3.6;
            lastApproximation = DateTime.Now;

            var distance = (lastSpeed * timeDifference.TotalSeconds) + (0.5 * (currentSpeed - lastSpeed) * timeDifference.TotalSeconds);
            TrainData.LastSpeed = TrainData.CurrentSpeed;

            return distance;
        }

        public static void ResetLastApproximationTimer() {
            lastApproximation = DateTime.Now;
        }
    }
}
