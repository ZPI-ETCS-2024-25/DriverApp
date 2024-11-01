using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations {
    public static class PositionApproximation {

        static private DateTime lastApproximation = DateTime.Now;

        public static void ApproximatePosition() {
            TimeSpan timeDifference = DateTime.Now - lastApproximation;
            double currentSpeed = AuthorityData.CurrentSpeed;
            double previousPosition = AuthorityData.CurrentPosition;

            AuthorityData.CurrentPosition = previousPosition + currentSpeed * timeDifference.TotalSeconds;
            lastApproximation = DateTime.Now;
        }
    }
}
