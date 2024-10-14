using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Data
{
    public class SpeedSegragation
    {
        public SpeedSegragation() { }

        public void CalculateSpeeds()
        {
            TrainSpeedsAndDistances.LowerDistances.Clear();
            TrainSpeedsAndDistances.HigherDistances.Clear();
            TrainSpeedsAndDistances.LowerSpeed.Clear();
            TrainSpeedsAndDistances.HigherSpeed.Clear();
            if(TrainSpeedsAndDistances.Speeds.Count == 0)
            {
                return;
            }

            double actualSpeed = TrainSpeedsAndDistances.Speeds[0];

            for (int i = 1; i < TrainSpeedsAndDistances.Speeds.Count; i++)
            {
                if(actualSpeed < TrainSpeedsAndDistances.Speeds[i])
                {
                    TrainSpeedsAndDistances.HigherDistances.Add(TrainSpeedsAndDistances.SpeedDistances[i]);
                    TrainSpeedsAndDistances.HigherSpeed.Add(TrainSpeedsAndDistances.Speeds[i]);
                }
                else
                {
                    TrainSpeedsAndDistances.LowerDistances.Add(TrainSpeedsAndDistances.SpeedDistances[i]);
                    TrainSpeedsAndDistances.LowerSpeed.Add(TrainSpeedsAndDistances.Speeds[i]);
                }
                actualSpeed = TrainSpeedsAndDistances.Speeds[i];
            }
        }
    }
}
