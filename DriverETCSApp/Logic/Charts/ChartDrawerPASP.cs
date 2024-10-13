using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartDrawerPASP
    {
        double[] Distanses;
        double[] Positions;
        Chart Chart;
        double Scale;

        public ChartDrawerPASP(Chart chart, double scale)
        {
            Distanses = new double[] { 0, 200, 400, 600, 800, 1000, 2000, 4000, 8000 };
            Positions = new double[] { 0, 33, 77, 102, 120, 134, 177, 220, 263 };
            chart = Chart;
            Scale = scale;
        }

        private double InterpolatePosition(double value, float k)
        {
            for (int i = 0; i < Distanses.Length - 1; i++)
            {
                if (value >= Distanses[i] && value <= Distanses[i + 1])
                {
                    double ratio = (value - Distanses[i]) / (Distanses[i + 1] - Distanses[i]);
                    return (Positions[i] + ratio * (Positions[i + 1] - Positions[i])) * k;
                }
            }
            return 8001;
        }

        private (List<double>, List<double>) Interpolate(List<double> speedList, List<double> distancesList)
        {
            List<double> interpolatedSpeeds = new List<double>();
            List<double> interpolatedDistances = new List<double>();

            var actualMaxSpeed = speedList[0];
            var actualSpeed = actualMaxSpeed;
            var actualDistance = distancesList[1];
            interpolatedDistances.Add(0);

            for (int i = 1; i < speedList.Count; i++)
            {
                if (i == speedList.Count - 1)
                {
                    interpolatedSpeeds.Add(CalculateQuaterForPASP(actualSpeed / actualMaxSpeed));
                    interpolatedDistances.Add(distancesList[i]);
                    interpolatedSpeeds.Add(speedList[i]);
                }
                else if (actualSpeed <= speedList[i])
                {
                    actualDistance = distancesList[i + 1];
                }
                else
                {
                    var actualScale = CalculateQuaterForPASP(actualSpeed / actualMaxSpeed);
                    var newScale = CalculateQuaterForPASP(speedList[i] / actualMaxSpeed);
                    if (actualScale > newScale)
                    {
                        interpolatedSpeeds.Add(actualScale);
                        interpolatedDistances.Add(actualDistance);
                        actualSpeed = speedList[i];
                        actualDistance = distancesList[i + 1];
                    }
                    else
                    {
                        actualDistance = distancesList[i + 1];
                    }
                }
            }
            return (interpolatedSpeeds, interpolatedDistances);
        }

        private double CalculateQuaterForPASP(double value)
        {
            if (value == 1)
            {
                return 100;
            }
            else if (value <= 0.99 && value >= 0.75)
            {
                return 75;
            }
            else if (value <= 0.74 && value >= 0.5)
            {
                return 50;
            }
            else
            {
                return 25;
            }
        }
    }
}
