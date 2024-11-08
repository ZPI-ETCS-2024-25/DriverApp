﻿using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations {
    public static class MaxSpeedsCalculation {

        private const double brakingAcceleration = -5; // km/(h*s)
        private static DateTime LastCountDown = DateTime.Now;

        public static void Calculate(List<double> speeds, List<double> speedDistances) {
            AuthorityData.MaxSpeedsDistances.Clear();
            AuthorityData.MaxSpeeds.Clear();

            for (int i = 1; i < speedDistances.Count; i++) {
                double previousMaxSpeed = speeds[i - 1];
                double nextMaxSpeed = speeds[i];
                if(nextMaxSpeed < previousMaxSpeed) {
                    double distance = (Math.Pow(nextMaxSpeed, 2) - Math.Pow(previousMaxSpeed, 2)) / (2 * brakingAcceleration * 3600) ;
                    double nextPosition = (speedDistances[i] / 1000 - distance) * 1000;
                    AuthorityData.MaxSpeedsDistances.Add(nextPosition);
                }
                else {
                    AuthorityData.MaxSpeedsDistances.Add(speedDistances[i]);
                }
            }

            AuthorityData.MaxSpeeds = new List<double>(speeds);
            AuthorityData.MaxSpeeds.RemoveRange(0, 1);

            for (int i = 1; i < AuthorityData.MaxSpeedsDistances.Count; i++) {
                if( AuthorityData.MaxSpeedsDistances[i] < AuthorityData.MaxSpeedsDistances[i - 1]) {
                    AuthorityData.MaxSpeedsDistances.RemoveRange(i - 1, 1);
                    AuthorityData.MaxSpeeds.RemoveRange(i - 1, 1);
                    i--;
                    //AuthorityData.MaxSpeedsDistances[i] = AuthorityData.MaxSpeedsDistances[i - 1];
                }
            }
            Console.WriteLine(string.Join(", ", AuthorityData.MaxSpeedsDistances));
        }

        public static void CountDownCalculatedMaxSpeed() {
            double passedSeconds = (DateTime.Now - LastCountDown).TotalSeconds;
            double previousSpeedLimit = AuthorityData.CalculatedSpeedLimit;
            double nextSpeedLimit = (previousSpeedLimit + brakingAcceleration * passedSeconds);

            LastCountDown = DateTime.Now;
            //Console.WriteLine(passedHours + ", " + previousSpeedLimit + ", " + (brakingAcceleration * passedHours) + ", " + nextSpeedLimit);
            
            if(nextSpeedLimit < AuthorityData.FallTo) {
                AuthorityData.CalculatedSpeedLimit = 0;
                AuthorityData.FallTo = 0;
            }
            else {
                AuthorityData.CalculatedSpeedLimit = Math.Max(nextSpeedLimit, 0);
            }
        }
    }
}
