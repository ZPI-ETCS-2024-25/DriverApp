using System.Threading;

namespace DriverETCSApp.Data
{
    public static class TrainData
    {
        //train data
        public static string IDDriver = "";
        public static string TrainNumber = "";
        public static string TrainType = "";
        public static string TrainCat = "";
        public static string Length = "";
        public static string VMax = "";
        public static string BrakingMass = "";
        public static double ActualSpeed = 0;
        //etcs data
        public static string ETCSLevel = "";
        public static string ActiveMode = "";
        public static bool IsMisionStarted = false;
        public static bool IsETCSActive = false;
        public static bool IsTrainRegisterOnServer = false;
        //position data
        //public static double CalculatedPosition = 0;
        //public static string CalculatedDrivingDirection = "";
        public static double LastCalculated = 0;
        public static double CalculatedPosition = 11.11;
        //public static int CalculatedPosition = 6150;
        public static string CalculatedDrivingDirection = "N";

        public static string BalisePosition = "";
        public static int BaliseLinePosition = 0;
        //lock for this data
        public static SemaphoreSlim TrainDataSemaphofe = new SemaphoreSlim(1, 1);
    }
}
