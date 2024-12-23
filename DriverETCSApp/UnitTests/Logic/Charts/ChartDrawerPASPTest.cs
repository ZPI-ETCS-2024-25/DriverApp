﻿using Xunit;
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
    public class ChartDrawerPASPTest : IDisposable
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
            if(AuthorityData.AuthoritiyDataSemaphore.CurrentCount == 0)
                AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        [Fact]
        public void PASPTest()
        {
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
        }

        [Fact]
        public void PASPEmptyTest()
        {
            AuthorityData.SpeedDistances = new List<double> { 0 };
            AuthorityData.Speeds = new List<double> { 0 };

            ChartDrawerPASP.Draw();

            List<DataPoint> expectedPoints = new List<DataPoint>
            {

            };

            Assert.Equal(expectedPoints.Count, Chart.Series["SeriesZoneSpeed"].Points.Count);
        }

        [Fact]
        public void PASPEmptyTest2()
        {
            AuthorityData.SpeedDistances = new List<double> { };
            AuthorityData.Speeds = new List<double> { };

            ChartDrawerPASP.Draw();

            List<DataPoint> expectedPoints = new List<DataPoint>
            {

            };

            Assert.Equal(expectedPoints.Count, Chart.Series["SeriesZoneSpeed"].Points.Count);
        }

        [Fact]
        public void ZeroIndicationLineTest()
        {
            AuthorityData.MaxSpeedsDistances = new List<double> { };

            bool b = ChartDrawerPASP.DrawIndication(null);
            Assert.False(b);
        }

        public void Dispose()
        {
            ChartDrawerPASP = null;
            ChartScaleDrawer = null;
            ChartInterpolate = null;
            Interpolator = null;
            Chart.Dispose();
        }
    }
}
