using DriverETCSApp.Data;
using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartGradientDrawer
    {
        private Chart Chart;
        private ChartInterpolate Interpolator;

        public ChartGradientDrawer(Chart chart)
        {
            Chart = chart;
            Interpolator = new ChartInterpolate();
        }

        public void SetUp()
        {
            Series series = new Series("SeriesGradientPositive")
            {
                ChartType = SeriesChartType.StackedColumn,
                Color = DMIColors.Grey,
                BorderWidth = 0,
                BackSecondaryColor = Color.Transparent,
            };
            //series["PointWidth"] = "0.9";
            Chart.Series.Add(series);
            series.ChartArea = Chart.ChartAreas[2].Name;

            Series series1 = new Series("SeriesGradientNegative")
            {
                ChartType = SeriesChartType.StackedColumn,
                Color = DMIColors.Grey,
                BorderWidth = 0,
                BackSecondaryColor = Color.Transparent
            };
            //series1["PointWidth"] = "0.8";
            Chart.Series.Add(series1);
            series1.ChartArea = Chart.ChartAreas[2].Name;

            Draw();
        }

        public void Draw()
        {
            if (TrainSpeedsAndDistances.Gradients.Count == 0 || TrainSpeedsAndDistances.GradientsDistances.Count == 0)
            {
                return;
            }

            var series = Chart.Series["SeriesGradientPositive"];
            var series1 = Chart.Series["SeriesGradientNegative"];
            series.Points.Clear();
            series1.Points.Clear();

            for(int i = 0; i < TrainSpeedsAndDistances.Gradients.Count; i++)
            {
                if (TrainSpeedsAndDistances.Gradients[i] >= 0)
                {
                    //series.Points.Add(0, Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i + 1]) - Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i]));
                    series.Points.Add(TrainSpeedsAndDistances.GradientsDistances[i], 90);
                }
                else // < 0
                {
                    //series1.Points.Add(0, Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i + 1]) - Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i]));
                }
            }
        }
    }
}
