using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using DriverETCSApp.Logic;
using DriverETCSApp.Logic.Charts;
using DriverETCSApp.Data;

namespace DriverETCSApp.UnitTests.Logic.Charts
{
    public class ChartDrawerPASPTest
    {
        private ChartDrawerPASP ChartDrawerPASP;
        private ChartScaleDrawer ChartScaleDrawer;
        private Chart Chart;

        public ChartDrawerPASPTest() 
        {
            Chart = new Chart();
            ChartScaleDrawer = new ChartScaleDrawer(Chart);
            ChartScaleDrawer.Draw();
            ChartDrawerPASP = new ChartDrawerPASP(Chart);
            ChartDrawerPASP.SetUp();
        }

        [Fact]
        public void Test()
        {
            AuthorityData.SpeedDistances = new List<double> { 0, 150, 500, 800 };
            AuthorityData.Speeds = new List<double> { 100, 120, 0 };
            AuthorityData.Gradients = new List<int> { 10, 0 };
            AuthorityData.GradientsDistances = new List<double> { 0, 500, 800 };
        }
    }
}
