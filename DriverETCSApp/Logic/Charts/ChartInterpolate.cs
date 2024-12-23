﻿using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartInterpolate
    {
        public ChartInterpolate() { }

        public double InterpolatePosition(double value)
        {
            for (int i = 0; i < ChartData.Distanses.Length - 1; i++)
            {
                if (value >= ChartData.Distanses[i] && value <= ChartData.Distanses[i + 1])
                {
                    double ratio = (value - ChartData.Distanses[i]) / (ChartData.Distanses[i + 1] - ChartData.Distanses[i]);
                    return (ChartData.Positions[i] + ratio * (ChartData.Positions[i + 1] - ChartData.Positions[i])) * ChartData.Scale;
                }
            }
            return 9000;
        }

        public (List<double>, List<double>) Interpolate()
        {
            List<double> interpolatedSpeeds = new List<double>();
            List<double> interpolatedDistances = new List<double>();

            var actualMaxSpeed = AuthorityData.Speeds[0];
            var actualSpeed = actualMaxSpeed;
            var actualDistance = AuthorityData.SpeedDistances[1];
            interpolatedDistances.Add(0);

            for (int i = 1; i < AuthorityData.Speeds.Count; i++)
            {
                if (i == AuthorityData.Speeds.Count - 1)
                {
                    interpolatedSpeeds.Add(CalculateQuaterForPASP(actualSpeed / actualMaxSpeed));
                    interpolatedDistances.Add(AuthorityData.SpeedDistances[i]);
                    interpolatedSpeeds.Add(AuthorityData.Speeds[i]);
                }
                else if (actualSpeed <= AuthorityData.Speeds[i])
                {
                    actualDistance = AuthorityData.SpeedDistances[i + 1];
                }
                else
                {
                    var actualScale = CalculateQuaterForPASP(actualSpeed / actualMaxSpeed);
                    var newScale = CalculateQuaterForPASP(AuthorityData.Speeds[i] / actualMaxSpeed);
                    if (actualScale > newScale)
                    {
                        interpolatedSpeeds.Add(actualScale);
                        interpolatedDistances.Add(actualDistance);
                        actualSpeed = AuthorityData.Speeds[i];
                        actualDistance = AuthorityData.SpeedDistances[i + 1];
                    }
                    else
                    {
                        actualDistance = AuthorityData.SpeedDistances[i + 1];
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
            else if (value < 1 && value >= 0.75)
            {
                return 75;
            }
            else if (value < 0.75 && value >= 0.5)
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
