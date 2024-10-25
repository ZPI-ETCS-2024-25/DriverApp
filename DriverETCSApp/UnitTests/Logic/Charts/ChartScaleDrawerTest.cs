using DriverETCSApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.UnitTests.Logic.Charts
{
    public class ChartScaleDrawerTest
    {
        private ChartScaleDrawer ChartScaleDrawer;
        private Chart Chart;

        public ChartScaleDrawerTest() 
        {
            Chart = new Chart();
            ChartScaleDrawer = new ChartScaleDrawer(Chart);
        }
    }
}
