using DriverETCSApp.Logic.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DriverETCSApp.UnitTests.Logic.Charts
{
    public class ChartInterpolateTest
    {
        private ChartInterpolate ChartInterpolate;

        public ChartInterpolateTest() 
        {
            ChartInterpolate = new ChartInterpolate();
        }

        [Fact]
        public void OutOfRangePositionTest()
        {
            double expected = 9000;
            double value = ChartInterpolate.InterpolatePosition(9000);
            Assert.Equal(expected, value);
        }

        [Fact]
        public void ZeroPosition()
        {
            double expected = 0;
            double value = ChartInterpolate.InterpolatePosition(0);
            Assert.Equal(expected, value);
        }

        [Fact]
        public void FirstPosition()
        {
            double expected = 749.92500000000007;
            double value = ChartInterpolate.InterpolatePosition(150);
            Assert.Equal(expected, value);
        }

        [Fact]
        public void MultiPosition()
        {
            double expected = 4125.345;
            double value = ChartInterpolate.InterpolatePosition(1050);
            Assert.Equal(expected, value);
        }
    }
}
