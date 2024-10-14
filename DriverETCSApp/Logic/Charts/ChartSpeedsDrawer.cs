using DriverETCSApp.Data;
using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartSpeedsDrawer
    {
        Chart Chart;
        ChartInterpolate Interpolator;

        public ChartSpeedsDrawer(Chart chart)
        {
            Chart = chart;
            Interpolator = new ChartInterpolate();
        }

        public void Draw()
        {
            if (TrainSpeedsAndDistances.Speeds.Count == 0 || TrainSpeedsAndDistances.SpeedDistances.Count == 0)
            {
                return;
            }

            Series series = new Series("SeriesPoiontsSpeed")
            {
                ChartType = SeriesChartType.Point,
                MarkerColor = Color.FromArgb(128, DMIColors.Grey),
                MarkerSize = 10,
                MarkerStyle = MarkerStyle.Circle
            };

            for (int i = 1; i < TrainSpeedsAndDistances.Speeds.Count; i++)
            {
                series.Points.AddXY(50, Interpolator.InterpolatePosition(TrainSpeedsAndDistances.SpeedDistances[i]));
            }
            Chart.Series.Add(series);
            series.ChartArea = Chart.ChartAreas[3].Name;
        }
    }
}
