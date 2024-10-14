﻿using System;
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
            Chart.BackColor = Color.Transparent;

            //create area and set min and max values on axis X and Y
            float[] width = new float[] { 100, 30, 7, 6, 37, 1};
            float[] xPos = new float[] { 0, 16, 46, 56, 62, 99};
            for (int i = 0; i < 6; i++)
            {
                ChartArea chartArea = new ChartArea(i.ToString() + "Area");
                chartArea.AxisX.Minimum = 0;
                chartArea.AxisX.Maximum = 100;
                chartArea.AxisX.MajorGrid.LineColor = Color.Gray;
                chartArea.AxisY.Minimum = 0;
                chartArea.AxisY.Maximum = 8000;
                chartArea.BackColor = Color.Transparent;
                chartArea.Position.Width = width[i];
                chartArea.Position.Height = 95;
                chartArea.Position.X = xPos[i];
                chartArea.Position.Y = 3;
                Chart.ChartAreas.Add(chartArea);

                //create custom labels
                chartArea.AxisX.CustomLabels.Clear();
                chartArea.AxisY.CustomLabels.Clear();
                    for (int j = 0; j < Lines.Length; j++)
                    {
                        CustomLabel customLabel;
                        if (j >= 1 && j <= 4)
                        {
                            customLabel = new CustomLabel((Lines[j] - LinesLabels[j]) * Scale, (Lines[j] + LinesLabels[j]) * Scale, "", 0, LabelMarkStyle.LineSideMark);
                        }
                        else
                        {
                            customLabel = new CustomLabel((Lines[j] - LinesLabels[j]) * Scale, (Lines[j] + LinesLabels[j]) * Scale, Distanses[j].ToString(), 0, LabelMarkStyle.LineSideMark);
                        }
                        customLabel.ForeColor = DMIColors.Grey;

                        chartArea.AxisY.CustomLabels.Add(customLabel);
                    }
                    chartArea.AxisY.LabelStyle.Font = new Font("Verdana", 16);
            }
            Chart.ChartAreas[4].BackColor = Color.FromArgb(128, DMIColors.PASPDark.R, DMIColors.PASPDark.G, DMIColors.PASPDark.B);
            Chart.ChartAreas[5].BackColor = Color.FromArgb(128, DMIColors.PASPDark.R, DMIColors.PASPDark.G, DMIColors.PASPDark.B);

            //add series
            Series series = new Series("BasicArea")
            {
                ChartType = SeriesChartType.Area,
                Color = Color.Transparent,
                BorderColor = Color.Transparent,
                BorderWidth = 0
            };
            series.Points.AddXY(0, 0);
            Chart.Series.Add(series);
            series.ChartArea = Chart.ChartAreas[0].Name;

            //set axis X and Y settings
            for (int i = 0; i < 6; i++)
            {
                Chart.ChartAreas[i].AxisX.LabelStyle.Enabled = false;
                Chart.ChartAreas[i].AxisX.Interval = 0;
                Chart.ChartAreas[i].AxisX.MajorTickMark.Enabled = false;
                Chart.ChartAreas[i].AxisX.MinorTickMark.Enabled = false;
                Chart.ChartAreas[i].AxisX.MajorGrid.Enabled = false;
                Chart.ChartAreas[i].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
                Chart.ChartAreas[i].AxisX.LineWidth = 0;

                Chart.ChartAreas[i].AxisY.Interval = 0;
                Chart.ChartAreas[i].AxisY.MajorTickMark.Enabled = false;
                Chart.ChartAreas[i].AxisY.MinorTickMark.Enabled = false;
                Chart.ChartAreas[i].AxisY.MajorGrid.Enabled = false;
                Chart.ChartAreas[i].AxisY.MajorGrid.LineColor = Color.Gray;
                Chart.ChartAreas[i].AxisY.MajorGrid.LineWidth = 1;
                Chart.ChartAreas[i].AxisY.LineWidth = 0;
            }

            Chart.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            Chart.ChartAreas[1].AxisY.LabelStyle.Enabled = false;
            Chart.ChartAreas[2].AxisY.LabelStyle.Enabled = false;
            Chart.ChartAreas[3].AxisY.LabelStyle.Enabled = false;
            Chart.ChartAreas[4].AxisY.LabelStyle.Enabled = false;
            Chart.ChartAreas[5].AxisY.LabelStyle.Enabled = false;

            DrawLines();
        }

        private void DrawLines()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                //for (int j = 1; j < 6; j++)
                //{
                    StripLine stripLine = new StripLine
                    {
                        Interval = 0,
                        IntervalOffset = Lines[i] * Scale,
                        StripWidth = 0,
                        BorderColor = Color.FromArgb(255, DMIColors.Grey),
                        BorderWidth = LinesThin[i],
                        BorderDashStyle = ChartDashStyle.Solid
                    };
                
                    Chart.ChartAreas[0].AxisY.StripLines.Add(stripLine);
               //}
                //Chart.ChartAreas[0].AxisY.StripLines.Add(stripLine);
            }
        }
    }
}
