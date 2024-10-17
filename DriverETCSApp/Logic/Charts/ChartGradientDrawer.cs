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
        private List<Series> Series;

        public ChartGradientDrawer(Chart chart)
        {
            Chart = chart;
            Interpolator = new ChartInterpolate();
            Series = new List<Series>();
        }

        public void Draw()
        {
            foreach (Series series in Series)
            {
                series.Points.Clear();
            }

            if (TrainSpeedsAndDistances.Gradients.Count == 0 || TrainSpeedsAndDistances.GradientsDistances.Count == 0)
            {
                return;
            }

            for (int i = 0; i < TrainSpeedsAndDistances.Gradients.Count; i++)
            {
                if (TrainSpeedsAndDistances.Gradients[i] >= 0)
                {
                    Series series = new Series("Gradient" + i.ToString())
                    {
                        ChartType = SeriesChartType.StackedColumn,
                        Color = DMIColors.Red,
                        BorderWidth = 0,
                        BackSecondaryColor = Color.Transparent,
                    };
                    Chart.Series.Add(series);
                    series.ChartArea = Chart.ChartAreas[2].Name;
                    var x = Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i + 1]) - Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i]);
                    series.Points.AddXY("All", x);
                    series["PointWidth"] = "0.9";
                }
                else
                {
                    Series series = new Series("Gradient" + i.ToString())
                    {
                        ChartType = SeriesChartType.StackedColumn,
                        Color = DMIColors.DarkGrey,
                        BorderWidth = 0,
                        BackSecondaryColor = Color.Transparent,
                    };
                    Chart.Series.Add(series);
                    series.ChartArea = Chart.ChartAreas[2].Name;
                    var x = Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i + 1]) - Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i]);
                    series.Points.AddXY("All", x);
                    series["PointWidth"] = "0.8";
                }
            }
        }
    }
}
