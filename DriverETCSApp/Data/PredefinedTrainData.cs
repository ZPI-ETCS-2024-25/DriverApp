using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Data
{
    public class PredefinedTrain
    {
        public string TrainName { get; set; }
        public string TrainCat { get; set; }
        public string Length { get; set; }
        public string VMax { get; set; }
        public string BrakingMass { get; set; }

        public PredefinedTrain(string trainName, string trainCat, string length, string vmax, string brakingMass)
        {
            TrainName = trainName;
            TrainCat = trainCat;
            Length = length;
            VMax = vmax;
            BrakingMass = brakingMass;
        }
    }

    public static class PredefinedTrainData
    {
        public static PredefinedTrain DefaultTrain = new PredefinedTrain(
            "Default",
            "PASS 3",
            "100",
            "120",
            "100"
        );
    }
}
