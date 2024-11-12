using DriverETCSApp.Data;
using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private SolidBrush Brush;
        private SolidBrush BrushDark;
        private Pen Pen;
        private Font Font;

        public ChartGradientDrawer(Chart chart)
        {
            Chart = chart;
            Interpolator = new ChartInterpolate();
            Series = new List<Series>();
            Pen = new Pen(DMIColors.Black, 1);
            Brush = new SolidBrush(DMIColors.Grey);
            BrushDark = new SolidBrush(DMIColors.DarkGrey);
            Font = new Font("Verdana", 8, FontStyle.Bold);
        }

        public void SetUp()
        {
            Chart.Paint += new PaintEventHandler(DrawGraphics);
        }

        public void Draw()
        {
            foreach (Series series in Series)
            {
                Chart.Series.Remove(series);
            }
            Series.Clear();

            if (AuthorityData.Gradients.Count == 0 || AuthorityData.GradientsDistances.Count == 0)
            {
                return;
            }

            for (int i = 0; i < AuthorityData.Gradients.Count; i++)
            {
                var x = Interpolator.InterpolatePosition(AuthorityData.GradientsDistances[i + 1]) - Interpolator.InterpolatePosition(AuthorityData.GradientsDistances[i]);

                if (AuthorityData.Gradients[i] >= 0)
                {
                    Series series = new Series("Gradient" + i.ToString())
                    {
                        ChartType = SeriesChartType.StackedColumn,
                        Color = DMIColors.Grey,
                        BorderWidth = 0,
                        BackSecondaryColor = Color.Transparent,
                    };
                    Chart.Series.Add(series);
                    Series.Add(series);
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
                    Series.Add(series);
                    series.ChartArea = Chart.ChartAreas[2].Name;
                    series.Points.AddXY("All", x);
                    series.Points.AddXY("All1", x);
                }
            }
        }

        public void DrawGraphics(object sender, PaintEventArgs e)
        {
            if (AuthorityData.Gradients.Count == 0 || AuthorityData.GradientsDistances.Count == 0)
            {
                return;
            }

            var graphics = e.Graphics;
            for (int i = 0; i < AuthorityData.Gradients.Count; i++)
            {
                int pixelY = (int)Chart.ChartAreas[2].AxisY.ValueToPixelPosition(Interpolator.InterpolatePosition(Math.Min(AuthorityData.GradientsDistances[i + 1], 8000)));
                int pixelY1 = (int)Chart.ChartAreas[2].AxisY.ValueToPixelPosition(Interpolator.InterpolatePosition(AuthorityData.GradientsDistances[i]));
                int pixelX = (int)Chart.ChartAreas[2].AxisX.ValueToPixelPosition(0);

                if(pixelY1 > 8000)
                {
                    return;
                }

                if (AuthorityData.Gradients[i] >= 0)
                {
                    graphics.FillRectangle(Brushes.White, pixelX + 20, pixelY, 1, pixelY1 - pixelY);
                    if (pixelY1 - pixelY >= 40)
                    {
                        graphics.DrawString("+", Font, BrushDark, pixelX + 27, pixelY);
                        graphics.DrawString("+", Font, BrushDark, pixelX + 27, pixelY1 - 13);
                    }
                    if (pixelY1 - pixelY >= 55)
                    {
                        var s = AuthorityData.Gradients[i].ToString();
                        int offset = s.Length == 1 ? 29 : 25;
                        graphics.DrawString(s, Font, BrushDark, pixelX + offset, ((pixelY + pixelY1) / 2) - 5);
                    }
                }
                else
                {
                    graphics.FillRectangle(Brush, pixelX + 20, pixelY, 1, pixelY1 - pixelY);
                    if (pixelY1 - pixelY >= 35)
                    {
                        graphics.DrawString("-", Font, Brush, pixelX + 29, pixelY);
                        graphics.DrawString("-", Font, Brush, pixelX + 29, pixelY1 - 13);
                    }
                    if (pixelY1 - pixelY >= 50)
                    {
                        var s = AuthorityData.Gradients[i].ToString().Remove(0, 1);
                        int offset = s.Length == 1 ? 29 : 25;
                        graphics.DrawString(s, Font, Brush, pixelX + offset, ((pixelY + pixelY1) / 2) - 5);
                    }
                }
                if (i != 0)
                {
                    graphics.DrawLine(Pens.Black, pixelX + 20, pixelY1, pixelX + 48, pixelY1);
                    graphics.DrawLine(Pens.Black, pixelX + 20, pixelY1 + 1, pixelX + 48, pixelY1 + 1);
                }
            }
        }
    }
}
