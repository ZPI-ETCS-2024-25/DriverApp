using DriverETCSApp.Communication.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Data
{
    public static class AuthorityData
    {
        //lock
        public static SemaphoreSlim AuthoritiyDataSemaphore = new SemaphoreSlim(1, 1);
        //speed data
        public static List<double> Speeds = new List<double>();
        public static List<double> SpeedDistances = new List<double>();
        public static List<double> LowerSpeed = new List<double>();
        public static List<double> LowerDistances = new List<double>();
        public static List<double> HigherSpeed = new List<double>();
        public static List<double> HigherDistances = new List<double>();
        //calculated speed data
        public static List<double> MaxSpeedsDistances = new List<double>();
        public static double CalculatedSpeedLimit = 0;
        public const double NOTICE_DISTANCE = 500;
        public const int WARNING_SPEED_RANGE = 10;
        //gradients data
        public static List<int> Gradients = new List<int>();
        public static List<double> GradientsDistances = new List<double>();
        //messages data
        public static List<string> Messages = new List<string>();
        public static List<double> MessagesDistances = new List<double>();
        //
        public static List<int> Lines = new List<int>();
        public static List<double> LinesDistances = new List<double>();
    }
}
