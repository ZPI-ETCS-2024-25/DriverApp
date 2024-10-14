using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.LinkLabel;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartDrawerPASP
    {
        double[] Distanses;
        double[] Positions;
        double[] Lines;
        double[] LinesLabels;
        Chart Chart;
        double Scale;
        List<double> SpeedDistances;
        List<double> Speeds;

        public ChartDrawerPASP(Chart chart, double scale)
        {
            //SpeedDistances = new List<double> { 0, 150, 500, 800, 1000, 1550, 2000, 2540, 3500, 5810, 7000 };
            //Speeds = new List<double> { 100, 120, 90, 80, 50, 100, 120, 50, 40, 20, 0 };
            SpeedDistances = new List<double>();
            Speeds = new List<double>();
            Distanses = new double[] { 0, 200, 400, 600, 800, 1000, 2000, 4000, 8000 };
            Positions = new double[] { 0, 33, 77, 102, 120, 134, 177, 220, 263 };
            Lines = new double[] { 0.5, 33, 77, 102, 120, 134, 177, 220, 263 };
            LinesLabels = new double[] { 1, 0.5, 0.5, 0.5, 0.5, 1, 0.5, 0.5, 0.5 };
            Chart = chart;
            Scale = scale;
        }

        public void SetDistancesAndSpeeds(List<double> distances, List<double> speeds)
        {
            SpeedDistances = distances;
            Speeds = speeds;
        }
        
        public void Draw()
        {
            if(Speeds.Count == 0 || SpeedDistances.Count == 0)
            {
                return;
            }
            (List<double> interpolateSpeeds, List<double> interpolateDistances) = Interpolate(Speeds, SpeedDistances);

            Chart.Series.Clear();
            Series series = new Series("SeriesZoneSpeed")
            {
                ChartType = SeriesChartType.Area,
                Color = Color.FromArgb(128, DMIColors.PASPLight.R, DMIColors.PASPLight.G, DMIColors.PASPLight.B),
                BorderColor = Color.FromArgb(128, DMIColors.PASPLight.R, DMIColors.PASPLight.G, DMIColors.PASPLight.B),
                BorderWidth = 0,
                BackSecondaryColor = Color.Transparent
            };

            for (int i = 0; i < interpolateSpeeds.Count; i++)
            {
                if (i != interpolateSpeeds.Count - 1)
                {
                    series.Points.AddXY(interpolateSpeeds[i], InterpolatePosition(interpolateDistances[i], Scale));
                    series.Points.AddXY(interpolateSpeeds[i], InterpolatePosition(interpolateDistances[i + 1], Scale));
                }
                else
                {
                    series.Points.AddXY(interpolateSpeeds[i], InterpolatePosition(interpolateDistances[i], Scale));
                }
            }
            Chart.Series.Add(series);
            series.ChartArea = Chart.ChartAreas[4].Name;

            Series series1 = new Series("BasicArea")
            {
                ChartType = SeriesChartType.Area,
                Color = Color.Transparent,
                BorderColor = Color.Transparent,
                BorderWidth = 0
            };
            series1.Points.AddXY(0, 0);
            Chart.Series.Add(series1);
            series1.ChartArea = Chart.ChartAreas[0].Name;
        }

        private double InterpolatePosition(double value, double k)
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
