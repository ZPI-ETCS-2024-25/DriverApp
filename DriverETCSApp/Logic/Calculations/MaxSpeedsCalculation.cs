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
            AuthorityData.MaxSpeeds = speeds;
            AuthorityData.MaxSpeedsDistances = speedDistances;

            for(int i = 0; i <= AuthorityData.MaxSpeedsDistances.Count; i++) {
                AuthorityData.MaxSpeedsDistances[i] -= 10;
            }
            
            
        }

    }
}
