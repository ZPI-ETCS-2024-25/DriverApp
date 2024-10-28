using DriverETCSApp.Data;
using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartDrawerPASP
    {
        private Chart Chart;
        private ChartInterpolate Interpolator;

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
                Color = Color.FromArgb(128, DMIColors.PASPLight),
                BorderColor = Color.FromArgb(128, DMIColors.PASPLight),
                BorderWidth = 0,
                BackSecondaryColor = Color.Transparent
            };
            Chart.Series.Add(series);
            series.ChartArea = Chart.ChartAreas[4].Name;

            Chart.Paint += new PaintEventHandler(DrawIndicationLine);
        }
        
        public void Draw()
        {
            var series = Chart.Series["SeriesZoneSpeed"];
            series.Points.Clear();

            if (AuthorityData.Speeds.Count <= 1 || AuthorityData.SpeedDistances.Count <= 1)
            {
                return;
            }
            (List<double> interpolateSpeeds, List<double> interpolateDistances) = Interpolator.Interpolate();

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

        private void DrawIndicationLine(object sender, PaintEventArgs e)
        {
            DrawIndication(e.Graphics);
        }

        public void DrawIndication(Graphics graphics)
        {
            if (AuthorityData.LowerSpeed.Count <= 0 || AuthorityData.LowerDistances.Count <= 0)
            {
                return;
            }

            int pixelY = (int)Chart.ChartAreas[4].AxisY.ValueToPixelPosition(Interpolator.InterpolatePosition(AuthorityData.LowerDistances[0] - 400));
            int pixelX = (int)Chart.ChartAreas[4].AxisX.ValueToPixelPosition(0);

            using (var pen = new Pen(DMIColors.Yellow, 2))
            {
                graphics.DrawLine(pen, pixelX, pixelY, pixelX + 190, pixelY);
            }
        }
    }
}
