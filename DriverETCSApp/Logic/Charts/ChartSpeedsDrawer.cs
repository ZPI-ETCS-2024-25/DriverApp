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
    public class ChartSpeedsDrawer
    {
        private Chart Chart;
        private ChartInterpolate Interpolator;
        private Pen Pen;
        private Pen PenYellow;
        private SolidBrush SolidBrush;
        private SolidBrush SolidBrushYellow;
        Font Font;

        private int LineLength;

        public ChartSpeedsDrawer(Chart chart)
        {
            Chart = chart;
            Pen = new Pen(DMIColors.Grey, 2);
            SolidBrush = new SolidBrush(DMIColors.Grey);
            PenYellow = new Pen(DMIColors.Yellow, 2);
            SolidBrushYellow = new SolidBrush(DMIColors.Yellow);
            Interpolator = new ChartInterpolate();
            Font = new Font("Verdana", 8, FontStyle.Bold);
            LineLength = 20;
        }

        public void SetUp()
        {
            Chart.Paint += new PaintEventHandler(DrawPoints);
        }

        public void DrawPoints(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            for (int i = 0; i < TrainSpeedsAndDistances.HigherSpeed.Count; i++)
            {
                int pixelX = (int)Chart.ChartAreas[3].AxisX.ValueToPixelPosition(50);
                int pixelY = (int)Chart.ChartAreas[3].AxisY.ValueToPixelPosition(Interpolator.InterpolatePosition(TrainSpeedsAndDistances.HigherDistances[i]));

                graphics.DrawLine(Pen, pixelX - LineLength / 2, pixelY, pixelX + LineLength / 2, pixelY);

                Point[] triangleUp = new Point[]
                {
                    new Point(pixelX + 5, pixelY - 11),
                    new Point(pixelX, pixelY - 2),
                    new Point(pixelX + 10, pixelY - 2)
                };
                graphics.FillPolygon(SolidBrush, triangleUp);

                graphics.DrawString(TrainSpeedsAndDistances.HigherSpeed[i].ToString(), Font, SolidBrush, pixelX + 10, pixelY - 10);
            }

            for (int i = 0; i < TrainSpeedsAndDistances.LowerSpeed.Count; i++)
            {
                int pixelX = (int)Chart.ChartAreas[3].AxisX.ValueToPixelPosition(50);
                int pixelY = (int)Chart.ChartAreas[3].AxisY.ValueToPixelPosition(Interpolator.InterpolatePosition(TrainSpeedsAndDistances.LowerDistances[i]));

                graphics.DrawLine(Pen, pixelX - LineLength / 2, pixelY, pixelX + LineLength / 2, pixelY);

                Point[] triangleDown = new Point[]
                {
                    new Point(pixelX + 5, pixelY + 11),
                    new Point(pixelX, pixelY + 2),
                    new Point(pixelX + 10, pixelY + 2)
                };
                graphics.FillPolygon(SolidBrush, triangleDown);

                graphics.DrawString(TrainSpeedsAndDistances.LowerSpeed[i].ToString(), Font, SolidBrush, pixelX + 10, pixelY);
            }
        }

        /*public void Update()
        {
            var series = Chart.Series["SeriesPointsSpeedLower"];
            series.Points.Clear();
            var series1 = Chart.Series["SeriesPointsSpeedHigher"];
            series1.Points.Clear();

            if (TrainSpeedsAndDistances.Speeds.Count == 0 || TrainSpeedsAndDistances.SpeedDistances.Count == 0)
            {
                return;
            }

            for (int i = 0; i < TrainSpeedsAndDistances.LowerSpeed.Count; i++)
            {
                series.Points.AddXY(50, Interpolator.InterpolatePosition(TrainSpeedsAndDistances.LowerDistances[i]));
            }

            for (int i = 0; i < TrainSpeedsAndDistances.HigherSpeed.Count; i++)
            {
                series1.Points.AddXY(50, Interpolator.InterpolatePosition(TrainSpeedsAndDistances.HigherDistances[i]));
            }

            Chart.Invalidate();
        }*/
    }
}
