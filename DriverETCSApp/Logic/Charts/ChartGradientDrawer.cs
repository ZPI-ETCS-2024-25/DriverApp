using DriverETCSApp.Data;
using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartGradientDrawer
    {
        private Chart Chart;
        private ChartInterpolate Interpolator;
        private List<Series> Series;
        private Pen Pen;

        public ChartGradientDrawer(Chart chart)
        {
            Chart = chart;
            Interpolator = new ChartInterpolate();
            Series = new List<Series>();
            Pen = new Pen(DMIColors.Black, 2);
        }

        public void SetUp()
        {
            Chart.Paint += new PaintEventHandler(DrawGraphics);
            Draw();
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
                var x = Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i + 1]) - Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i]);

                if (TrainSpeedsAndDistances.Gradients[i] >= 0)
                {
                    Series series = new Series("Gradient" + i.ToString())
                    {
                        ChartType = SeriesChartType.StackedColumn,
                        Color = DMIColors.Grey,
                        BorderWidth = 0,
                        BackSecondaryColor = Color.Transparent,
                    };
                    Chart.Series.Add(series);
                    series.ChartArea = Chart.ChartAreas[2].Name;
                    series.Points.AddXY("All", x);
                    series.Points.AddXY("All1", x);
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
                    series.Points.AddXY("All", x);
                    series.Points.AddXY("All1", x);
                }
            }
        }

        public void DrawGraphics(object sender, PaintEventArgs e)
        {
            if (TrainSpeedsAndDistances.Gradients.Count == 0 || TrainSpeedsAndDistances.GradientsDistances.Count == 0)
            {
                return;
            }

            var graphics = e.Graphics;
            for (int i = 0; i < TrainSpeedsAndDistances.Gradients.Count; i++)
            {
                int pixelY = (int)Chart.ChartAreas[3].AxisX.ValueToPixelPosition(Interpolator.InterpolatePosition(TrainSpeedsAndDistances.GradientsDistances[i + 1]));
                int pixelX = (int)Chart.ChartAreas[3].AxisX.ValueToPixelPosition(0);
                graphics.DrawLine(Pen, pixelX, pixelY - 1, pixelX + 15, pixelY - 1);

                if (TrainSpeedsAndDistances.Gradients[i] >= 0)
                {

                }
                else
                {

                }
            }
        }
    }
}
