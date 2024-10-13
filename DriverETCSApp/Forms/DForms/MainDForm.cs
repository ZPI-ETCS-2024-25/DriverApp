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
        private double Scale;

        public MainDForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            Scale = 30.3;

            ChartScaller = new ChartScaleDrawer(chartBackLines, Scale);
            ChartPASPDrawer = new ChartDrawerPASP(chartBackLines, Scale);

            InitalizeBasicChart();
            ChartScaller.Draw();
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
