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
            Series series = new Series("SeriesGradient")
            {
                ChartType = SeriesChartType.Area,
                //Color = Color.FromArgb(128, DMIColors.PASPLight.R, DMIColors.PASPLight.G, DMIColors.PASPLight.B),
                BorderWidth = 0,
                BackSecondaryColor = Color.Transparent
            };
            Chart.Series.Add(series);
            series.ChartArea = Chart.ChartAreas[2].Name;
            Draw();
        }

        public void Draw()
        {
            if (TrainSpeedsAndDistances.Gradients.Count == 0 || TrainSpeedsAndDistances.GradientsDistances.Count == 0)
            {
                return;
            }

            var series = Chart.Series["SeriesGradient"];
            series.Points.Clear();
        }
    }
}
