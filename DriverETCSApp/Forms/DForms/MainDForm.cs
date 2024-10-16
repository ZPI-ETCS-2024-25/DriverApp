using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Logic;
using DriverETCSApp.Logic.Charts;
using DriverETCSApp.Logic.Data;
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
        private SpeedSegragation SpeedSegragation;
        private ChartScaleDrawer ChartScaller;
        private ChartDrawerPASP ChartPASPDrawer;
        private ChartSpeedsDrawer ChartSpeedsDrawer;

        public MainDForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            SpeedSegragation = new SpeedSegragation();

            ChartScaller = new ChartScaleDrawer(chartBackLines);
            ChartPASPDrawer = new ChartDrawerPASP(chartBackLines);
            ChartSpeedsDrawer = new ChartSpeedsDrawer(chartBackLines);

            InitalizeBasicChart();
            SpeedSegragation.CalculateSpeeds();

            ChartScaller.Draw();
            ChartPASPDrawer.Draw();
            ChartSpeedsDrawer.SetUp();
        }

        //protected override void PaintForm(object sender, PaintEventArgs e) { }

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
