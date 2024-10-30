using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Logic;
using DriverETCSApp.Logic.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Charts
{
    public class ChartGradientDrawerTest
    {
        private ChartGradientDrawer ChartGradientDrawer;
        private ChartScaleDrawer ChartScaleDrawer;
        private ChartInterpolate Interpolator;
        private Chart Chart;

        public ChartGradientDrawerTest()
        {

        }

        private void SetUp()
        {
            Chart = new Chart();
            Interpolator = new ChartInterpolate();
            ChartScaleDrawer = new ChartScaleDrawer(Chart);
            ChartScaleDrawer.Draw();
            ChartGradientDrawer = new ChartGradientDrawer(Chart);
        }

        [Fact]
        public void TestMultipleIterations()
        {
            SetUp();
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.GradientsDistances = new List<double> { 0, 150, 500, 800, 1000 };
            AuthorityData.Gradients = new List<int> { 5, 0, -2, 0 };

            ChartGradientDrawer.Draw();

            List<DataPoint> expectedPoints = new List<DataPoint>
            {
                new DataPoint(0, Interpolator.InterpolatePosition(150) - Interpolator.InterpolatePosition(0)),
                new DataPoint(0, Interpolator.InterpolatePosition(500) - Interpolator.InterpolatePosition(150)),
                new DataPoint(0, Interpolator.InterpolatePosition(800) - Interpolator.InterpolatePosition(500)),
                new DataPoint(0, Interpolator.InterpolatePosition(1000) - Interpolator.InterpolatePosition(800))
            };

            Assert.Equal(5, Chart.Series.Count);

            for (int i = 0; i < Chart.Series.Count - 1; i++)
            {
                var series = Chart.Series["Gradient" + i.ToString()];
                Assert.Equal("Gradient" + i.ToString(), series.Name);
                Assert.Equal(SeriesChartType.StackedColumn, series.ChartType);
                Assert.Equal(2, series.Points.Count);
                Assert.Equal(expectedPoints[i].YValues[0], series.Points[0].YValues[0]);
                Assert.Equal(expectedPoints[i].YValues[0], series.Points[1].YValues[0]);

                if (AuthorityData.Gradients[i] >= 0)
                {
                    Assert.Equal(DMIColors.Grey, series.Color);
                }
                else
                {
                    Assert.Equal(DMIColors.DarkGrey, series.Color);
                }
            }

            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void TestZeroIteration()
        {
            SetUp();
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.GradientsDistances = new List<double> { };
            AuthorityData.Gradients = new List<int> { };

            ChartGradientDrawer.Draw();

            List<DataPoint> expectedPoints = new List<DataPoint>
            {

            };

            Assert.Single(Chart.Series);

            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void TestSingleIterations()
        {
            SetUp();
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.GradientsDistances = new List<double> { 0, 150 };
            AuthorityData.Gradients = new List<int> { 5 };

            ChartGradientDrawer.Draw();

            List<DataPoint> expectedPoints = new List<DataPoint>
            {
                new DataPoint(0, Interpolator.InterpolatePosition(150) - Interpolator.InterpolatePosition(0)),
            };

            Assert.Equal(2, Chart.Series.Count);

            for (int i = 0; i < Chart.Series.Count - 1; i++)
            {
                var series = Chart.Series["Gradient" + i.ToString()];
                Assert.Equal("Gradient" + i.ToString(), series.Name);
                Assert.Equal(SeriesChartType.StackedColumn, series.ChartType);
                Assert.Equal(2, series.Points.Count);
                Assert.Equal(expectedPoints[i * 2].YValues[0], series.Points[0].YValues[0]);
                Assert.Equal(expectedPoints[i * 2].YValues[0], series.Points[1].YValues[0]);

                if (AuthorityData.Gradients[i] >= 0)
                {
                    Assert.Equal(DMIColors.Grey, series.Color);
                }
                else
                {
                    Assert.Equal(DMIColors.DarkGrey, series.Color);
                }
            }

            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void TestSeriesClear()
        {
            SetUp();
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.GradientsDistances = new List<double> { 0, 150 };
            AuthorityData.Gradients = new List<int> { 5 };
            ChartGradientDrawer.Draw();

            AuthorityData.GradientsDistances = new List<double> { 0, 150 };
            AuthorityData.Gradients = new List<int> { };
            ChartGradientDrawer.Draw();

            Assert.Single(Chart.Series);

            AuthorityData.AuthoritiyDataSemaphore.Release();
        }
    }
}
