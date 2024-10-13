using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DriverETCSApp.Data;
using DriverETCSApp.Design;

namespace DriverETCSApp.Logic
{
    public class ChartScaleDrawer
    {
        private Chart Chart;
        double[] Distanses;
        double[] Positions;
        double[] Lines;
        double[] LinesLabels;
        int[] LinesThin;
        double Scale;

        public ChartScaleDrawer(Chart chart, double scale)
        {
            Chart = chart;
            Scale = scale;
            Distanses = new double[] { 0, 200, 400, 600, 800, 1000, 2000, 4000, 8000 };
            Lines = new double[] { 0.5, 33, 77, 102, 120, 134, 177, 220, 263 };
            LinesLabels = new double[] { 1, 0.5, 0.5, 0.5, 0.5, 1, 0.5, 0.5, 0.5 };
            LinesThin = new int[] { 2, 1, 1, 1, 1, 2, 1, 1, 2 };
            Positions = new double[] { 0, 33, 77, 102, 120, 134, 177, 220, 263 };
        }

        public void Draw()
        {
            //clear chart data
            Chart.Series.Clear();
            Chart.ChartAreas.Clear();
            Chart.Legends.Clear();

            //create area and set min and max values on axis X and Y
            ChartArea chartArea = new ChartArea("Area");
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 100;
            chartArea.AxisX.MajorGrid.LineColor = Color.Gray;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 8000;
            chartArea.BackColor = DMIColors.DarkBlue;

            Chart.ChartAreas.Add(chartArea);

            //create custom labels
            Chart.ChartAreas[0].AxisX.CustomLabels.Clear();
            Chart.ChartAreas[0].AxisY.CustomLabels.Clear();
            for (int i = 0; i < Lines.Length; i++)
            {
                CustomLabel customLabel;
                if (i >= 1 && i <= 4)
                {
                    customLabel = new CustomLabel((Lines[i] - LinesLabels[i]) * Scale, (Lines[i] + LinesLabels[i]) * Scale, "", 0, LabelMarkStyle.LineSideMark);
                }
                else
                {
                    customLabel = new CustomLabel((Lines[i] - LinesLabels[i]) * Scale, (Lines[i] + LinesLabels[i]) * Scale, Distanses[i].ToString(), 0, LabelMarkStyle.LineSideMark);
                }
                customLabel.ForeColor = DMIColors.Grey;

                Chart.ChartAreas[0].AxisY.CustomLabels.Add(customLabel);
            }
            Chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Verdana", 16);

            //add series
            Series series = new Series("BasicArea")
            {
                ChartType = SeriesChartType.Area,
                Color = DMIColors.PASPLight,
                BorderColor = DMIColors.PASPLight,
                BorderWidth = 0
            };
            series.Points.AddXY(0, 0);
            Chart.Series.Add(series);
            series.ChartArea = chartArea.Name;

            //set axis X and Y settings
            Chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            Chart.ChartAreas[0].AxisX.Interval = 0;
            Chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            Chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            Chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            Chart.ChartAreas[0].AxisX.LineWidth = 0;

            Chart.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            Chart.ChartAreas[0].AxisY.Interval = 0;
            Chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            Chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            Chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;
            Chart.ChartAreas[0].AxisY.LineWidth = 0;

            DrawLines();
        }

        private void DrawLines()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                StripLine stripLine = new StripLine
                {
                    Interval = 0,
                    IntervalOffset = Lines[i] * Scale,
                    StripWidth = 0,
                    BorderColor = Color.Gray,
                    BorderWidth = LinesThin[i],
                    BorderDashStyle = ChartDashStyle.Solid
                };
                Chart.ChartAreas[0].AxisY.StripLines.Add(stripLine);
            }
        }
    }
}
