using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Data
{
    public static class TrainSpeedsAndDistances
    {
        public static List<double> SpeedDistances = new List<double> { 0, 150, 500, 800, 1000, 1550, 2000, 2540, 3500, 5810, 7000 };
        public static List<double> Speeds = new List<double> { 100, 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 };
        public static List<int> Gradients = new List<int> { 10, 0, -2, 1, 5, -3 };
        public static List<double> GradientsDistances = new List<double> { 0, 500, 1050, 2500, 3500, 4000, 7000 };
        //public static List<double> Speeds = new List<double>();
        //public static List<double> SpeedDistances = new List<double>();
        //public static List<int> Gradients = new List<int>();
        //public static List<double> GradientsDistances = new List<double>();

        public static List<double> LowerSpeed = new List<double>();
        public static List<double> LowerDistances = new List<double>();
        public static List<double> HigherSpeed = new List<double>();
        public static List<double> HigherDistances = new List<double>();
    }
}
