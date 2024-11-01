using DriverETCSApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using DriverETCSApp.Logic.Charts;
using DriverETCSApp.Data;

namespace DriverETCSApp.UnitTests.Logic.Charts
{
    public class ChartScaleDrawerTest : IDisposable
    {
        private ChartScaleDrawer ChartScaleDrawer;
        private Chart Chart;

        public ChartScaleDrawerTest() 
        {
            Chart = new Chart();
            ChartScaleDrawer = new ChartScaleDrawer(Chart);
        }

        [Fact]
        public void CheckCountOfAreas()
        {
            ChartScaleDrawer.Draw();
            Assert.Equal(6, Chart.ChartAreas.Count);
        }

        [Fact]
        public void ChartNull()
        {
            Chart Chart = null;
            var ChartScaleDrawer = new ChartScaleDrawer(Chart);
            ChartScaleDrawer.Draw();
            Assert.Null(ChartScaleDrawer.GetChart());
        }

        [Fact]
        public void CheckNamesOfAreas()
        {
            ChartScaleDrawer.Draw();

            for (int i = 0; i < Chart.ChartAreas.Count; i++)
            {
                Assert.Equal(i.ToString() + "Area", Chart.ChartAreas[i].Name);
            }
        }

        [Fact]
        public void CheckAxisesOfAreas()
        {
            ChartScaleDrawer.Draw();

            for (int i = 0; i < Chart.ChartAreas.Count; i++)
            {
                if (i != 2)
                {
                    Assert.Equal(0, Chart.ChartAreas[i].AxisX.Minimum);
                    Assert.Equal(100, Chart.ChartAreas[i].AxisX.Maximum);
                }
                else
                {
                    Assert.Equal(0.5, Chart.ChartAreas[i].AxisX.Minimum);
                    Assert.Equal(1.5, Chart.ChartAreas[i].AxisX.Maximum);
                }   
            }
        }

        [Fact]
        public void CheckHeightOfAreas()
        {
            ChartScaleDrawer.Draw();

            for (int i = 0; i < Chart.ChartAreas.Count; i++)
            {
                if (i == 0)
                {
                    Assert.Equal(95, Chart.ChartAreas[i].Position.Height);
                }
                else
                {
                    Assert.Equal(94.5, Chart.ChartAreas[i].Position.Height);
                }
            }
        }

        [Fact]
        public void CheckLabels()
        {
            List<CustomLabel> expectedLabels = new List<CustomLabel>
            {
                new CustomLabel((0.5 - 1) * 30.3, (0.5 + 1) * 30.3, "0", 0, LabelMarkStyle.LineSideMark),
                new CustomLabel((33 - 0.5) * 30.3, (33 + 0.5) * 30.3, "", 0, LabelMarkStyle.LineSideMark),
                new CustomLabel((77 - 0.5) * 30.3, (77 + 0.5) * 30.3, "", 0, LabelMarkStyle.LineSideMark),
                new CustomLabel((102 - 0.5) * 30.3, (102 + 0.5) * 30.3, "", 0, LabelMarkStyle.LineSideMark),
                new CustomLabel((120 - 0.5) * 30.3, (120 + 0.5) * 30.3, "", 0, LabelMarkStyle.LineSideMark),
                new CustomLabel((134 - 1) * 30.3, (134 + 1) * 30.3, "1000", 0, LabelMarkStyle.LineSideMark),
                new CustomLabel((177 - 0.5) * 30.3, (177 + 0.5) * 30.3, "2000", 0, LabelMarkStyle.LineSideMark),
                new CustomLabel((220 - 0.5) * 30.3, (220 + 0.5) * 30.3, "4000", 0, LabelMarkStyle.LineSideMark),
                new CustomLabel((263 - 0.5) * 30.3, (263 + 0.5) * 30.3, "8000", 0, LabelMarkStyle.LineSideMark),
            };

            ChartScaleDrawer.Draw();

            for (int i = 0; i < Chart.ChartAreas.Count; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Assert.Equal(expectedLabels[j].FromPosition, Chart.ChartAreas[i].AxisY.CustomLabels[j].FromPosition);
                    Assert.Equal(expectedLabels[j].ToPosition, Chart.ChartAreas[i].AxisY.CustomLabels[j].ToPosition);
                    Assert.Equal(expectedLabels[j].Text, Chart.ChartAreas[i].AxisY.CustomLabels[j].Text);
                }
            }
        }

        [Fact]
        public void CheckLines()
        {
            List<double> expectedLines = new List<double>
            {
                0.5 * 30.3, 33 * 30.3, 77 * 30.3, 102 * 30.3, 120 * 30.3, 134 * 30.3, 177 * 30.3, 220 * 30.3, 263 * 30.3
            };

            ChartScaleDrawer.Draw();

            for (int i = 0; i < 9; i++)
            {
                Assert.Equal(expectedLines[i], Chart.ChartAreas[0].AxisY.StripLines[i].IntervalOffset);
            }
            Assert.Equal(9, Chart.ChartAreas[0].AxisY.StripLines.Count);

            for (int i = 1; i < Chart.ChartAreas.Count; i++)
            {
                Assert.Empty(Chart.ChartAreas[i].AxisY.StripLines);
            }
        }

        public void Dispose()
        {
            Chart.Dispose();
            ChartScaleDrawer = null;
        }
    }
}
