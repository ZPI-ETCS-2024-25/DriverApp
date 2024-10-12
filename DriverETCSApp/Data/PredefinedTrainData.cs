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
        public string Weight { get; set; }
        public string BrakingMass { get; set; }

        public PredefinedTrain(string trainName, string trainCat, string length, string weight, string brakingMass)
        {
            TrainName = trainName;
            TrainCat = trainCat;
            Length = length;
            Weight = weight;
            BrakingMass = brakingMass;
        }
    }

    public static class PredefinedTrainData
    {
        public static PredefinedTrain DefaultTrain = new PredefinedTrain(
            "Default",
            "PASS 3",
            "30",
            "15",
            "100"
        );
    }
}
