using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations {
    public static class MaxSpeedsCalculation {

        public static void Calculate(List<double> speeds, List<double> speedDistances) {
            AuthorityData.MaxSpeeds = new List<double>(speeds);
            AuthorityData.MaxSpeedsDistances.Clear();

            for (int i = 0; i < speedDistances.Count; i++) {
                AuthorityData.MaxSpeedsDistances.Add(Math.Max(speedDistances[i] - 10, 0));
            }
            AuthorityData.currentSpeedLimit = AuthorityData.MaxSpeeds[0];


        }

    }
}
