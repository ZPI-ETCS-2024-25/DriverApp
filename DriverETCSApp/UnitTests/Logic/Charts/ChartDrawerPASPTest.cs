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
using System.Drawing;
using DriverETCSApp.Design;
using DriverETCSApp.Forms.DForms;

namespace DriverETCSApp.UnitTests.Logic.Charts
{
    public class ChartDrawerPASPTest
    {
        private ChartDrawerPASP ChartDrawerPASP;
        private ChartScaleDrawer ChartScaleDrawer;
        private ChartInterpolate ChartInterpolate;
        private ChartInterpolate Interpolator;
        private Chart Chart;

        public ChartDrawerPASPTest() 
        {
            Chart = new Chart();
            Interpolator = new ChartInterpolate();
            ChartInterpolate = new ChartInterpolate();
            ChartScaleDrawer = new ChartScaleDrawer(Chart);
            ChartScaleDrawer.Draw();
            ChartDrawerPASP = new ChartDrawerPASP(Chart);
            ChartDrawerPASP.SetUp();
        }

        [Fact]
        public void PASPTest()
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.SpeedDistances = new List<double> { 0, 150, 500, 800 };
            AuthorityData.Speeds = new List<double> { 100, 50, 40, 0 };

            ChartDrawerPASP.Draw();

            List<DataPoint> expectedPoints = new List<DataPoint>
            {
                new DataPoint(100, ChartInterpolate.InterpolatePosition(0)),
                new DataPoint(100, ChartInterpolate.InterpolatePosition(150)),
                new DataPoint(50, ChartInterpolate.InterpolatePosition(150)),
                new DataPoint(50, ChartInterpolate.InterpolatePosition(500)),
                new DataPoint(25, ChartInterpolate.InterpolatePosition(500)),
                new DataPoint(25, ChartInterpolate.InterpolatePosition(800)),
                new DataPoint(0, ChartInterpolate.InterpolatePosition(800))
            };

            for (int i = 0; i < expectedPoints.Count; i++)
            {
                Assert.Equal(expectedPoints[i].XValue, Chart.Series["SeriesZoneSpeed"].Points[i].XValue);
                Assert.Equal(expectedPoints[i].YValues[0], Chart.Series["SeriesZoneSpeed"].Points[i].YValues[0]);
            }
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void PASPEmptyTest()
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.SpeedDistances = new List<double> { 0 };
            AuthorityData.Speeds = new List<double> { 0 };

            ChartDrawerPASP.Draw();

            List<DataPoint> expectedPoints = new List<DataPoint>
            {

            };

            Assert.Equal(expectedPoints.Count, Chart.Series["SeriesZoneSpeed"].Points.Count);

            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void PASPEmptyTest2()
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.SpeedDistances = new List<double> { };
            AuthorityData.Speeds = new List<double> { };

            ChartDrawerPASP.Draw();

            List<DataPoint> expectedPoints = new List<DataPoint>
            {

            };

            Assert.Equal(expectedPoints.Count, Chart.Series["SeriesZoneSpeed"].Points.Count);

            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void ZeroIndicationLineTest()
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.LowerDistances = new List<double> { 0 };
            AuthorityData.LowerSpeed = new List<double> { 0 };

            bool b = ChartDrawerPASP.DrawIndication(null);

            Assert.False(b);
            AuthorityData.AuthoritiyDataSemaphore.Release();
        }
    }
}
