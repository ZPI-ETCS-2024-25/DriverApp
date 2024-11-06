using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations {
    public static class MaxSpeedsCalculation {

        private const double brakingAcceleration = -10; // km/h^2

        public static void Calculate(List<double> speeds, List<double> speedDistances) {
            AuthorityData.MaxSpeeds = new List<double>(speeds);
            AuthorityData.MaxSpeedsDistances.Clear();

            for (int i = 1; i < speedDistances.Count; i++) {
                double previousMaxSpeed = speeds[i - 1];
                double nextMaxSpeed = speeds[i];
                if(nextMaxSpeed < previousMaxSpeed) {
                    double distance = (Math.Pow(nextMaxSpeed, 2) - Math.Pow(previousMaxSpeed, 2)) / (2 * brakingAcceleration);
                    double nextPosition = speedDistances[i] - distance;
                    AuthorityData.MaxSpeedsDistances.Add(nextPosition);
                }
                else {
                    AuthorityData.MaxSpeedsDistances.Add(speedDistances[i]);
                }
            }

            for(int i = 1; i < AuthorityData.MaxSpeedsDistances.Count; i++) {
                if( AuthorityData.MaxSpeedsDistances[i] < AuthorityData.MaxSpeedsDistances[i - 1]) {
                    AuthorityData.MaxSpeedsDistances[i] = AuthorityData.MaxSpeedsDistances[i - 1];
                }
            }

            AuthorityData.currentSpeedLimit = AuthorityData.MaxSpeeds[0];
        }

    }
}
