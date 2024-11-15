using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations {
    public static class MaxSpeedsCalculation {

        private static double brakingAcceleration = -1.8; // km/(h*s)
        public static double distanceFromLimit = 0;
        private static double previousLimit = 0;

        public static void Calculate(List<double> _speeds, List<double> _speedDistances) {
            List<double> speeds = new List<double>(_speeds);
            List<double> speedDistances = new List<double>(_speedDistances);
            AuthorityData.MaxSpeedsDistancesPoints.Clear();
            AuthorityData.MaxSpeedsDistances.Clear();
            AuthorityData.MaxSpeeds.Clear();
            AuthorityData.MaxSpeeds = new List<double>(speeds);
            AuthorityData.MaxSpeeds.RemoveRange(0, 1);

            for (int i = 1; i < speedDistances.Count; i++) {
                double previousMaxSpeed = speeds[i - 1];
                double nextMaxSpeed = speeds[i];
                if (nextMaxSpeed < previousMaxSpeed) {
                    double distance = (Math.Pow(nextMaxSpeed, 2) - Math.Pow(previousMaxSpeed, 2)) / (2 * brakingAcceleration * 3600);
                    double nextPosition = (speedDistances[i] / 1000 - distance) * 1000;
                    if (AuthorityData.MaxSpeedsDistances.Count > 0 && nextPosition < speedDistances[i - 1] /*+ AuthorityData.NOTICE_DISTANCE*/) {
                        speeds.RemoveRange(i - 1, 1);
                        speedDistances.RemoveRange(i - 1, 1);
                        AuthorityData.MaxSpeeds.RemoveRange(i - 2, 1);
                        AuthorityData.MaxSpeedsDistances.RemoveRange(i - 2, 1);
                        AuthorityData.MaxSpeedsDistancesPoints.RemoveRange(i - 2, 1);
                        i -= 2;
                        
                        continue;
                    }
                    AuthorityData.MaxSpeedsDistances.Add(nextPosition);
                    AuthorityData.MaxSpeedsDistancesPoints.Add(speedDistances[i]);
                }
                else {
                    AuthorityData.MaxSpeedsDistances.Add(speedDistances[i]);
                    AuthorityData.MaxSpeedsDistancesPoints.Add(speedDistances[i]);
                }
            }

            for (int i = 1; i < AuthorityData.MaxSpeedsDistances.Count; i++) {
                if( AuthorityData.MaxSpeedsDistances[i] < AuthorityData.MaxSpeedsDistances[i - 1]) {
                    AuthorityData.MaxSpeedsDistances.RemoveRange(i - 1, 1);
                    AuthorityData.MaxSpeeds.RemoveRange(i - 1, 1);
                    AuthorityData.MaxSpeedsDistancesPoints.RemoveRange(i - 1, 1);
                    i--;
                    //AuthorityData.MaxSpeedsDistances[i] = AuthorityData.MaxSpeedsDistances[i - 1];
                }
            }
        }

        public static void CountDownCalculatedMaxSpeed(double distancePassed) {
            double previousSpeedLimit = AuthorityData.CalculatedSpeedLimit;

            distanceFromLimit += distancePassed;
            double nextSpeedLimit = Math.Max(Math.Sqrt(Math.Pow(previousSpeedLimit, 2) + 2 * brakingAcceleration * 3600 * distanceFromLimit / 1000), AuthorityData.FallTo);
            if (Double.IsNaN(nextSpeedLimit))
            {
                nextSpeedLimit = previousLimit;
                //nextSpeedLimit = 0.1;
            }
            else
            {
                previousLimit = nextSpeedLimit;
            }

            Console.WriteLine(distancePassed.ToString() + " " + distanceFromLimit.ToString() + " " + nextSpeedLimit.ToString());
            if (nextSpeedLimit < AuthorityData.FallTo) {
                AuthorityData.CalculatedSpeedLimit = AuthorityData.FallTo;
                distanceFromLimit = 0;
            }
            else {
                AuthorityData.CalculatedSpeedLimit = Math.Max(nextSpeedLimit, 0);
            }

        }

        public static void SetBrakingAcceleration(double brakePercentage)
        {
            brakingAcceleration = brakePercentage / 100 * 3.6 * 0.4 * -1;
        }

        public static void SetBrakingAccelerationByValue(double brakeAcceleration)
        {
            brakingAcceleration = brakeAcceleration;
        }
    }
}
