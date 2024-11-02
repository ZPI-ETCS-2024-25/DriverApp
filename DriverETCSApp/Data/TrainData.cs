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
        public static double CurrentSpeed = 0;
        public static double LastSpeed = 0;


        //etcs data
        public static string ETCSLevel = "";
        public static string ActiveMode = "";
        public static bool IsMisionStarted = false;
        public static bool IsETCSActive = false;
        public static bool IsTrainRegisterOnServer = false;
        public static bool IsConnectionWorking = false;


        //position data
        public static double CalculatedPosition = 0;
        public static string CalculatedDrivingDirection = "";
        public static double LastCalculated = 0;
        //public static double CalculatedPosition = 11.11;
        //public static int CalculatedPosition = 6150;
        //public static string CalculatedDrivingDirection = "N";

        public static double BalisePosition = -55;
        public static int BaliseLinePosition = 0;
        public static string BaliseTrackPosition = "";
        
        //lock for this data
        public static SemaphoreSlim TrainDataSemaphofe = new SemaphoreSlim(1, 1);

        //ONLY FOR UNIT TESTS!
        public static void Reset()
        {
            IDDriver = "";
            TrainNumber = "";
            TrainType = "";
            TrainCat = "";
            Length = "";
            VMax = "";
            BrakingMass = "";
            CurrentSpeed = 0;

            ETCSLevel = "";
            ActiveMode = "";
            IsMisionStarted = false;
            IsETCSActive = false;
            IsTrainRegisterOnServer = false;
            IsConnectionWorking = false;

            CalculatedPosition = 0;
            CalculatedDrivingDirection = "";
            LastCalculated = 0;

            BalisePosition = -55;
            BaliseLinePosition = 0;
            BaliseTrackPosition = "";

            if (TrainDataSemaphofe.CurrentCount == 0)
            {
                try
                {
                    TrainDataSemaphofe.Release();
                }
                catch { }
            }
        }
    }
}
