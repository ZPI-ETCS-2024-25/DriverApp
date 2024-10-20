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

            for (int i = 0; i < AuthorityData.HigherSpeed.Count; i++)
            {
                int pixelX = (int)Chart.ChartAreas[3].AxisX.ValueToPixelPosition(50);
                int pixelY = (int)Chart.ChartAreas[3].AxisY.ValueToPixelPosition(Interpolator.InterpolatePosition(AuthorityData.HigherDistances[i]));

                graphics.DrawLine(Pen, pixelX - LineLength / 2, pixelY + 1, pixelX + LineLength / 2, pixelY + 1);

                Point[] triangleUp = new Point[]
                {
                    new Point(pixelX + 5, pixelY - 10),
                    new Point(pixelX, pixelY - 1),
                    new Point(pixelX + 10, pixelY - 1)
                };
                graphics.FillPolygon(SolidBrush, triangleUp);

                graphics.DrawString(AuthorityData.HigherSpeed[i].ToString(), Font, SolidBrush, pixelX + 10, pixelY - 10);
            }

            for (int i = 0; i < AuthorityData.LowerSpeed.Count; i++)
            {
                int pixelX = (int)Chart.ChartAreas[3].AxisX.ValueToPixelPosition(50);
                var x = AuthorityData.LowerDistances[i];
                int pixelY = (int)Chart.ChartAreas[3].AxisY.ValueToPixelPosition(Interpolator.InterpolatePosition(x));

                graphics.DrawLine(Pen, pixelX - LineLength / 2, pixelY + 1, pixelX + LineLength / 2, pixelY + 1);

                Point[] triangleDown = new Point[]
                {
                    new Point(pixelX + 5, pixelY + 12),
                    new Point(pixelX, pixelY + 3),
                    new Point(pixelX + 10, pixelY + 3)
                };
                graphics.FillPolygon(SolidBrush, triangleDown);

                var y = AuthorityData.LowerSpeed[i].ToString();
                graphics.DrawString(y, Font, SolidBrush, pixelX + 10, pixelY);
            }
        }
    }
}
