using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Logic;
using DriverETCSApp.Logic.Charts;
using DriverETCSApp.Logic.Data;
using DriverETCSApp.Logic.Position;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private ChartGradientDrawer ChartGradientDrawer;
        private DistancesCalculator DistancesCalculator;
        private bool IsChartDrawing;

        public MainDForm(MainForm mainForm, DistancesCalculator distancesCalculator)
        {
            InitializeComponent();
            MainForm = mainForm;
            IsChartDrawing = false;
            DistancesCalculator = distancesCalculator;
            DistancesCalculator.DistancesCalculationsCompleted += DistancesCalculationCompleted;
            SpeedSegragation = new SpeedSegragation();

            ChartScaller = new ChartScaleDrawer(PlanningChart);
            ChartPASPDrawer = new ChartDrawerPASP(PlanningChart);
            ChartSpeedsDrawer = new ChartSpeedsDrawer(PlanningChart);
            ChartGradientDrawer = new ChartGradientDrawer(PlanningChart);

            InitalizeBasicChart();
            Init();

            ETCSEvents.ModeChanged += ChangeVisibilityOfChart;
        }

        private async void Init()
        {
            if (PlanningChart == null)
            {
                return;
            }

            await AuthorityData.AuthoritiyDataSemaphore.WaitAsync();
            try
            {
                SpeedSegragation.CalculateSpeeds();

                ChartScaller.Draw();
                ChartPASPDrawer.SetUp();
                ChartSpeedsDrawer.SetUp();
                ChartGradientDrawer.SetUp();

                ChartPASPDrawer.Draw();
                ChartGradientDrawer.Draw();
            }
            finally
            {
                AuthorityData.AuthoritiyDataSemaphore.Release();
            }
        }

        private async void InitalizeBasicChart()
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            if (!TrainData.ActiveMode.Equals(ETCSModes.FS))
            {
                PlanningChart.Visible = false;
            }
            else
            {
                PlanningChart.Visible = true;
            }
            Data.TrainData.TrainDataSemaphofe.Release();
        }

        private void DistancesCalculationCompleted(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(async () =>
                {
                    if (!IsDisposed && !Disposing)
                    {
                        await PASPInvalidate();
                    }
                }));
            }
        }

        public async Task PASPInvalidate()
        {
            if (IsChartDrawing)
            {
                return;
            }

            IsChartDrawing = true;
            await AuthorityData.AuthoritiyDataSemaphore.WaitAsync();
            try
            {
                if(PlanningChart == null)
                {
                    return;
                }
                PlanningChart.Invalidate();
                PlanningChart.Update();
                ChartPASPDrawer.Draw();
                ChartGradientDrawer.Draw();
            }
            finally
            {
                AuthorityData.AuthoritiyDataSemaphore.Release();
                IsChartDrawing = false;
            }
        }

        private void ChangeVisibilityOfChart(object sender, ModeInfo e)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    if (!IsDisposed && !Disposing)
                    {
                        if (e.Mode.Equals(ETCSModes.FS))
                        {
                            PlanningChart.Visible = true;
                        }
                        else
                        {
                            PlanningChart.Visible = false;
                        }
                    }
                }));
            }
        }
    }
}
