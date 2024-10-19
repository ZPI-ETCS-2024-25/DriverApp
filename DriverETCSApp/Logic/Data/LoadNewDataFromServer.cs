using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Data
{
    public class LoadNewDataFromServer
    {
        public LoadNewDataFromServer() { }

        public void LoadNewData(dynamic decodedMessage)
        {
            List<double> speeds = decodedMessage.Speeds.ToObject<List<double>>();
            List<double> speeddistances = decodedMessage.SpeedDistances.ToObject<List<double>>();
            List<int> gradients = decodedMessage.Gradients.ToObject<List<int>>();
            List<double> gradientsDistances = decodedMessage.GradientsDistances.ToObject<List<double>>();
            int position = (int)(decodedMessage.Position * 1000);
            int diffrence = TrainData.CalculatedDrivingDirection.Equals("N") ? TrainData.CalculatedPosition - position : TrainData.CalculatedPosition + position;
            ClearLists();

            int lastIndex = -1;
            for (int i = 0; i < speeddistances.Count; i++)
            {
                speeddistances[i] = speeddistances[i] - diffrence;
                if (speeddistances[i] < 0)
                {
                    lastIndex = i;
                }
            }
            if (lastIndex != -1)
            {
                speeddistances.RemoveRange(0, lastIndex);
                speeddistances[0] = 0;
            }

            lastIndex = -1;
            for (int i = 0; i < gradientsDistances.Count; i++)
            {
                gradientsDistances[i] = gradientsDistances[i] - diffrence;
                if (gradientsDistances[i] < 0)
                {
                    lastIndex = i;
                }
            }
            if (lastIndex != -1)
            {
                gradientsDistances.RemoveRange(0, lastIndex);
                gradientsDistances[0] = 0;
            }

            TrainSpeedsAndDistances.Speeds = speeds;
            TrainSpeedsAndDistances.SpeedDistances = speeddistances;
            TrainSpeedsAndDistances.Gradients = gradients;
            TrainSpeedsAndDistances.GradientsDistances = gradientsDistances;
        }

        private void ClearLists()
        {
            TrainSpeedsAndDistances.Speeds.Clear();
            TrainSpeedsAndDistances.SpeedDistances.Clear();
            TrainSpeedsAndDistances.Gradients.Clear();
            TrainSpeedsAndDistances.GradientsDistances.Clear();
        }
    }
}
