using DriverETCSApp.Data;
using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartDrawerPASP
    {
        Chart Chart;
        ChartInterpolate Interpolator;

        public ChartDrawerPASP(Chart chart)
        {
            Chart = chart;
            Interpolator = new ChartInterpolate();
        }

        public void SetUp()
        {
            Series series = new Series("SeriesZoneSpeed")
            {
                ChartType = SeriesChartType.Area,
                Color = Color.FromArgb(128, DMIColors.PASPLight.R, DMIColors.PASPLight.G, DMIColors.PASPLight.B),
                BorderColor = Color.FromArgb(128, DMIColors.PASPLight.R, DMIColors.PASPLight.G, DMIColors.PASPLight.B),
                BorderWidth = 0,
                BackSecondaryColor = Color.Transparent
            };
            Chart.Series.Add(series);
            series.ChartArea = Chart.ChartAreas[4].Name;
            Draw();
            //Chart.Paint += new PaintEventHandler(Draw);
        }
        
        public void Draw()
        {
            if(TrainSpeedsAndDistances.Speeds.Count == 0 || TrainSpeedsAndDistances.SpeedDistances.Count == 0)
            {
                return;
            }
            (List<double> interpolateSpeeds, List<double> interpolateDistances) = Interpolator.Interpolate();

            var series = Chart.Series["SeriesZoneSpeed"];
            series.Points.Clear();

            for (int i = 0; i < interpolateSpeeds.Count; i++)
            {
                if (i != interpolateSpeeds.Count - 1)
                {
                    series.Points.AddXY(interpolateSpeeds[i], Interpolator.InterpolatePosition(interpolateDistances[i]));
                    series.Points.AddXY(interpolateSpeeds[i], Interpolator.InterpolatePosition(interpolateDistances[i + 1]));
                }
                else
                {
                    series.Points.AddXY(interpolateSpeeds[i], Interpolator.InterpolatePosition(interpolateDistances[i]));
                }
            }
        }
    }
}
