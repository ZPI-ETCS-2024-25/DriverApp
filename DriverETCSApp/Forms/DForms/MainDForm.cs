﻿using DriverETCSApp.Data;
using DriverETCSApp.Design;
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
        DistancesCalculator DistancesCalculator;

        public MainDForm(MainForm mainForm, DistancesCalculator distancesCalculator)
        {
            InitializeComponent();
            MainForm = mainForm;
            DistancesCalculator = distancesCalculator;
            distancesCalculator.DistancesCalculationsCompleted += DistancesCalculationCompleted;
            SpeedSegragation = new SpeedSegragation();

            ChartScaller = new ChartScaleDrawer(chartBackLines);
            ChartPASPDrawer = new ChartDrawerPASP(chartBackLines);
            ChartSpeedsDrawer = new ChartSpeedsDrawer(chartBackLines);
            ChartGradientDrawer = new ChartGradientDrawer(chartBackLines);

            InitalizeBasicChart();
            SpeedSegragation.CalculateSpeeds();

            Init();
        }

        private async void Init()
        {
            await AuthoritiyData.AuthoritiyDataSemaphore.WaitAsync();
            try
            {
                ChartScaller.Draw();
                ChartPASPDrawer.SetUp();
                ChartSpeedsDrawer.SetUp();
                ChartGradientDrawer.SetUp();
            }
            finally
            {
                AuthoritiyData.AuthoritiyDataSemaphore.Release();
            }
        }

        private async void InitalizeBasicChart()
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            if (TrainData.ETCSLevel.Equals(ETCSLevel.SHP) /*|| !TrainData.IsETCSActive*/)
            {
                chartBackLines.Visible = false;
            }
            else
            {
                chartBackLines.Visible = true;
            }
            Data.TrainData.TrainDataSemaphofe.Release();
        }

        private void DistancesCalculationCompleted(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Invalidate();
            }));
        }

        public new async void Invalidate()
        {
            await AuthoritiyData.AuthoritiyDataSemaphore.WaitAsync();
            try
            {
                chartBackLines.Invalidate();
            }
            finally
            {
                AuthoritiyData.AuthoritiyDataSemaphore.Release();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AuthoritiyData.Speeds = new List<double> { 40, 20, 40, 10, 20, 10, 20, 30, 40, 20, 0 };
            AuthoritiyData.SpeedDistances = new List<double> { 0, 150, 500, 800, 1000, 1550, 2000, 2540, 3500, 5810, 7000 };
            AuthoritiyData.Gradients = new List<int> { 0 };
            AuthoritiyData.GradientsDistances = new List<double> { 0, 7000 };
            SpeedSegragation.CalculateSpeeds();
            this.Invalidate();
            await Task.Delay(3000);

            AuthoritiyData.Speeds = new List<double> { 40,  0 };
            AuthoritiyData.SpeedDistances = new List<double> { 0, 500 };
            AuthoritiyData.Gradients = new List<int> { 40, 20, 40, -10, 20, 10, 20, -30, 40, 20 };
            AuthoritiyData.GradientsDistances = new List<double> { 0, 150, 500, 800, 1000, 1550, 2000, 2540, 3500, 5810, 7000 };
            SpeedSegragation.CalculateSpeeds();
            this.Invalidate();
            await Task.Delay(3000);

            AuthoritiyData.Speeds = new List<double> { 160, 140, 120, 200, 60, 0 };
            AuthoritiyData.SpeedDistances = new List<double> { 0, 500, 750, 800, 1640, 2050 };
            AuthoritiyData.Gradients = new List<int> { 0, 10, 20 };
            AuthoritiyData.GradientsDistances = new List<double> { 0, 1000, 4000, 7000 };
            SpeedSegragation.CalculateSpeeds();
            this.Invalidate();
        }
    }
}
