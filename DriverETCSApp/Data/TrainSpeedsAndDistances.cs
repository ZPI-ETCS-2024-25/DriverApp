using DriverETCSApp.Communication.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Data
{
    public static class TrainSpeedsAndDistances
    {
        private static List<double> speedDistances = new List<double> { 0, 150, 500, 800, 1000, 1550, 2000, 2540, 3500, 5810, 7000 };
        private static List<double> speeds = new List<double> { 100, 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 };
        private static List<int> gradients = new List<int> { 10, 0, -2, 1, 5, -3 };
        private static List<double> gradientsDistances = new List<double> { 0, 500, 1050, 2500, 3500, 4000, 7000 };
        private static object _lock = new object();

        /*private static List<double> speeds = new List<double>();
        private static List<double> speedDistances = new List<double>();
        private static List<int> gradients = new List<int>();
        private static List<double> gradientsDistances = new List<double>();*/

        public static List<double> LowerSpeed = new List<double>();
        public static List<double> LowerDistances = new List<double>();
        public static List<double> HigherSpeed = new List<double>();
        public static List<double> HigherDistances = new List<double>();

        #region
        public static List<double> Speeds
        {
            get
            {
                lock (_lock)
                {
                    return speeds;
                }
            }
            set
            {
                lock (_lock)
                {
                    speeds = value;
                }
            }
        }

        public static List<double> SpeedDistances
        {
            get
            {
                lock (_lock)
                {
                    return speedDistances;
                }
            }
            set
            {
                lock (_lock)
                {
                    speedDistances = value;
                }
            }
        }

        public static List<int> Gradients
        {
            get
            {
                lock (_lock)
                {
                    return gradients;
                }
            }
            set
            {
                lock (_lock)
                {
                    gradients = value;
                }
            }
        }

        public static List<double> GradientsDistances
        {
            get
            {
                lock (_lock)
                {
                    return gradientsDistances;
                }
            }
            set
            {
                lock (_lock)
                {
                    gradientsDistances = value;
                }
            }
        }
        #endregion
    }
}
