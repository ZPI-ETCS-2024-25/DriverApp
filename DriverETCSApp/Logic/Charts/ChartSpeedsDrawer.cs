using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.Logic.Charts
{
    public class ChartSpeedsDrawer
    {
        Chart Chart;

        public ChartSpeedsDrawer(Chart chart)
        {
            Chart = chart;
        }

        public void Draw()
        {
            Series series1 = new Series("BasicArea")
            {
                ChartType = SeriesChartType.Area,
                Color = Color.Transparent,
                BorderColor = Color.Transparent,
                BorderWidth = 0
            };
            series1.Points.AddXY(0, 0);
            Chart.Series.Add(series1);
            series1.ChartArea = Chart.ChartAreas[0].Name;
        }
    }
}
