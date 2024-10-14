using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Logic;
using DriverETCSApp.Logic.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DriverETCSApp.Forms.DForms
{

    public partial class MainDForm : BorderLessForm
    {
        private MainForm MainForm;
        private ChartScaleDrawer ChartScaller;
        private ChartDrawerPASP ChartPASPDrawer;
        private double ChartScale;

        public MainDForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            ChartScale = 30.3;

            ChartScaller = new ChartScaleDrawer(chartBackLines, ChartScale);
            ChartPASPDrawer = new ChartDrawerPASP(chartBackLines, ChartScale);

            InitalizeBasicChart();
            ChartScaller.Draw();
            ChartPASPDrawer.Draw(); 
        }

        private void InitalizeBasicChart()
        {
            if (TrainData.ETCSLevel.Equals(ETCSLevel.SHP))
            {
                chartBackLines.Visible = false;
            }
            else
            {
                chartBackLines.Visible = true;
            }
        }
    }
}
