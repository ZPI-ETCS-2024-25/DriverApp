﻿using DriverETCSApp.Communication;
using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Forms.CForms;
using DriverETCSApp.Forms.EForms;
using DriverETCSApp.Logic.Calculations;
using DriverETCSApp.Logic.Data;
using DriverETCSApp.Logic.Position;
using DriverETCSApp.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp.Forms.BForms
{
    public partial class SpeedmeterForm : BorderLessForm
    {
        private static SpeedmeterForm instance;

        private const int linesCount = 18;
        private const int linesLength = 40;
        private const int speedPerLine = 10;
        private const int clockAngle = 270;
        private const int clockAngleOffset = -135;
        private const int speedNumbersOffset = 35;
        private const int needleCircleRadius = 30;
        private const float clockScale = 0.95f; // 0-1f

        private int clockSize;
        private int clockOffset;
        private int halfClockSize;
        private int needleLength;

        private int speed = 0;
        private (int, int) speedWarning = (0, 0); // yellow / white
        private bool isWarningYellow = false;
        private (int, int) speedCap = (0, 0); // orange
        private int speedLimit = 0;

        private Font numbersFont;
        public SpeedmeterForm()
        {
            InitializeComponent();
            
            clockSize = (int)(clockPanel.Width * clockScale);
            clockOffset = (clockPanel.Width - clockSize) / 2;
            halfClockSize = (int)(clockSize / 2f);

            needleLength = halfClockSize - 30;

            numbersFont = new Font(this.Font.FontFamily, 17f, this.Font.Style, this.Font.Unit);

            ETCSEvents.ModeChanged += modeChanged;
            ETCSEvents.DistancesCalculationsCompleted += UpdateWarningAndCap;

            if (instance == null)
                instance = this;
        }

        private void UpdateWarningAndCap(object sender, EventArgs e)
        {
            if (IsHandleCreated && !IsDisposed && !Disposing)
            {
                try
                {
                    Invoke(new Action(async () =>
                    {
                        if (!IsDisposed && !Disposing)
                        {
                            await AuthorityData.AuthoritiyDataSemaphore.WaitAsync();
                            // Speed limit and speed warning
                            if (AuthorityData.CalculatedSpeedLimit > 0)
                            {
                                double decresingSpeedLimit = AuthorityData.CalculatedSpeedLimit;
                                double nextSpeedlimit = AuthorityData.FallTo;
                                //Console.WriteLine(" " + decresingSpeedLimit);
                                SetSpeedLimit(Math.Max((int)nextSpeedlimit, AuthorityData.MIN_SPEED_LIMIT));
                                SetSpeedWarning((int)nextSpeedlimit, (int)decresingSpeedLimit, true);
                            }
                            else if (AuthorityData.Speeds.Count > 0 && AuthorityData.Speeds[0] > 0)
                            {
                                double speedlimit = AuthorityData.Speeds[0];
                                SetSpeedLimit((int)speedlimit);

                                if (AuthorityData.Speeds.Count > 1 && AuthorityData.MaxSpeedsDistances.Count > 0 &&
                                AuthorityData.MaxSpeedsDistances[0] <= AuthorityData.NOTICE_DISTANCE
                                /*&& AuthorityData.MaxSpeeds[0] < AuthorityData.Speeds[0]*/)
                                {
                                    double nextSpeedlimit = AuthorityData.MaxSpeeds[0];
                                    SetSpeedWarning((int)nextSpeedlimit, (int)speedlimit, false);
                                }
                                else
                                    SetSpeedWarning(0, 0);
                            }
                            else
                            {
                                SetSpeedWarning(0, 0);
                                SetSpeedCap(0, 0);
                            }

                            // Orange Speed Cap
                            int lastAllowedSpeed = Math.Max(speedLimit, speedWarning.Item2);
                            if (lastAllowedSpeed > 0)
                                SetSpeedCap(lastAllowedSpeed, lastAllowedSpeed + AuthorityData.WARNING_SPEED_RANGE);
                            else
                                SetSpeedCap(0, 0);

                            AuthorityData.AuthoritiyDataSemaphore.Release();
                            InvalidateClockPanel();
                        }
                    }));
                }
                catch { }
            }
        }

        public async void InvalidateClockPanel()
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            instance.clockPanel.Invalidate();
            TrainData.TrainDataSemaphofe.Release();
        }

        public static SpeedmeterForm GetInstance()
        {
            return instance;
        }

        private void clockPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Color needleColor = GetColorForNeedle();
                bool tmp = !TrainData.ActiveMode.Equals(ETCSModes.FS);

                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                float needleTarget = speed / (float)speedPerLine;

                // Draw the needle
                {
                    int needleAngle = (int)(needleTarget * clockAngle / linesCount) - clockAngleOffset;
                    double needleRadians = needleAngle * Math.PI / 180;
                    int xNeedle = halfClockSize + (int)(needleLength * Math.Cos(needleRadians)) + clockOffset;
                    int yNeedle = halfClockSize + (int)(needleLength * Math.Sin(needleRadians)) + clockOffset;

                    using (Pen pen = new Pen(needleColor, 15))
                    {
                        g.DrawLine(pen, halfClockSize, halfClockSize, xNeedle + (halfClockSize - xNeedle) * 0.25f, yNeedle + (halfClockSize - yNeedle) * 0.25f);
                    }
                    using (Pen pen = new Pen(needleColor, 5))
                    {
                        g.DrawLine(pen, halfClockSize, halfClockSize, xNeedle, yNeedle);
                    }

                    // Draw needle circle
                    using (SolidBrush brush = new SolidBrush(needleColor))
                    {
                        g.FillEllipse(brush, halfClockSize - needleCircleRadius, halfClockSize - needleCircleRadius, needleCircleRadius * 2, needleCircleRadius * 2);
                    }
                    {
                        Font largerFont = new Font(this.Font.FontFamily, 20f, this.Font.Style, this.Font.Unit);
                        string text = speed.ToString();
                        SizeF textSize = e.Graphics.MeasureString(text, largerFont);
                        int begin = (halfClockSize - needleCircleRadius);

                        int xText = begin + (needleCircleRadius * 2 - (int)textSize.Width) / 2;
                        int yText = begin + (needleCircleRadius * 2 - (int)textSize.Height) / 2;

                        g.DrawString(speed.ToString(), largerFont, Brushes.Black, xText, yText);
                    }

                }
                //is not in FS mode then return (dont go to next steps)
                if (tmp)
                {
                    return;
                }

                // Draw Arc of Speed Limit
                if (speedLimit > 0)
                {
                    Rectangle rect = new Rectangle(clockOffset, clockOffset, clockSize, clockSize);

                    float startAngle = -clockAngleOffset + 0 * clockAngle / linesCount / speedPerLine;
                    float sweepAngle = (speedLimit) * clockAngle / linesCount / speedPerLine;

                    using (Pen pen = new Pen(DMIColors.DarkGrey, 8))
                    {
                        e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
                    }
                }

                // Draw Arc of Warning
                if (speedWarning != (0, 0))
                {
                    int offset = speedWarning.Item2 < AuthorityData.MIN_SPEED_LIMIT ? 2 : 0;
                    Rectangle rect = new Rectangle(clockOffset + offset, clockOffset + offset, clockSize - 2 * offset, clockSize - 2 * offset);

                    float startAngle = -clockAngleOffset + speedWarning.Item1 * clockAngle / linesCount / speedPerLine;
                    float sweepAngle = (speedWarning.Item2 - speedWarning.Item1) * clockAngle / linesCount / speedPerLine;
                    float penSize = speedWarning.Item2 < AuthorityData.MIN_SPEED_LIMIT ? 4 : 8;

                    Color penColor = isWarningYellow ? DMIColors.Yellow : DMIColors.White;
                    using (Pen pen = new Pen(penColor, penSize))
                    {
                        e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
                    }


                    offset = 16;
                    Rectangle insideRect = new Rectangle(clockOffset + offset, clockOffset + offset, clockSize - 2 * offset, clockSize - 2 * offset);
                    float pointerBoldness = 2f;
                    float pointer = -clockAngleOffset + speedWarning.Item2 * clockAngle / linesCount / speedPerLine - pointerBoldness;

                    using (Pen pen = new Pen(penColor, 25))
                    {
                        e.Graphics.DrawArc(pen, insideRect, pointer, pointerBoldness);
                    }
                }

                // Draw Arc of Cap
                if (speedCap != (0, 0) && speedCap.Item1 < speed)
                {
                    int offset = 12;
                    Rectangle rect = new Rectangle(clockOffset + offset, clockOffset + offset, clockSize - 2 * offset, clockSize - 2 * offset);

                    float startAngle = -clockAngleOffset + speedCap.Item1 * clockAngle / linesCount / speedPerLine - 0.2f;
                    float sweepAngle = (speedCap.Item2 - speedCap.Item1) * clockAngle / linesCount / speedPerLine;

                    using (Pen pen = new Pen(speed > speedCap.Item2 ? DMIColors.Red : DMIColors.Orange, 32))
                    {
                        e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                clockPanel_Paint(sender, e);
            }
        }

        private Color GetColorForNeedle()
        {
            if (TrainData.ActiveMode.Equals(ETCSModes.FS)) //check if in FS mode
            {
                if (speed <= speedLimit)
                {
                    if (isWarningYellow /*& speed <= AuthorityData.MIN_SPEED_LIMIT*/)
                        return DMIColors.Yellow;
                    else
                        return DMIColors.White;
                }
                else if (speed <= speedWarning.Item2)
                {
                    if (isWarningYellow)
                        return DMIColors.Yellow;
                    else
                        return DMIColors.White;
                }
                else if (speed <= speedCap.Item2)
                {
                    return DMIColors.Orange;
                }
                else
                    return DMIColors.Red;
            }
            else if (TrainData.ActiveMode.Equals(ETCSModes.SB) || TrainData.ActiveMode.Equals(ETCSModes.PT)) //if in STAND BY or POST TRIP mode brake if train is moving
            {
                if (TrainData.CurrentSpeed > 0)
                {
                    return DMIColors.Red;
                }
                else
                {
                    return DMIColors.White;
                }
            }
            else if (TrainData.ActiveMode.Equals(ETCSModes.STM)) //if in SHP mode brake if train is moving faster then Vmax
            {
                if (TrainData.CurrentSpeed > Double.Parse(TrainData.VMax) + 5)
                {
                    return DMIColors.Red;
                }
                else
                {
                    return DMIColors.White;
                }
            }
            else if (TrainData.ActiveMode.Equals(ETCSModes.OS)) //if in OS mode brake if train is moving faster than 20 (+5 tolerance)
            {
                if (TrainData.CurrentSpeed > 25)
                {
                    return DMIColors.Red;
                }
                else
                {
                    return DMIColors.White;
                }
            }
            else if (TrainData.ActiveMode.Equals(ETCSModes.TR)) //if in TR mode brake
            {
                return DMIColors.Red;
            }
            else
            {
                return DMIColors.Red;
            }
        }

        public int GetSpeed()
        {
            return speed;
        }

        public static void SetSpeed(int newSpeed)
        {
            if (newSpeed < 0 || newSpeed > linesCount * speedPerLine)
                return;

            instance.speed = newSpeed;
        }

        public (int, int) GetSpeedWarning()
        {
            return speedWarning;
        }

        public static void SetSpeedWarning(int min, int max, bool isYellow = false)
        {
            instance.speedWarning = (min, max);
            instance.isWarningYellow = isYellow;
        }

        public static void SetSpeedLimit(int newSpeed)
        {
            instance.speedLimit = newSpeed;
        }

        public (int, int) GetSpeedCap()
        {
            return speedCap;
        }

        public static void SetSpeedCap(int min, int max)
        {
            instance.speedCap = (min, max);
        }

        public void ChangeMode(Bitmap newImage)
        {
            if (newImage != null)
            {
                modePicture.Image = newImage;
            }
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            UnityReceiver receiver = new UnityReceiver();
            SpeedData speedData = new SpeedData();
            if (TrainData.CurrentSpeed < 180)
            {
                speedData.NewSpeed = this.GetSpeed() + 5;
                var json = JsonConvert.SerializeObject(speedData);
                receiver.SpeedChanged(json);
            }
            Invalidate();
        }

        private async void btnTest2_Click(object sender, EventArgs e)
        {
            UnityReceiver receiver = new UnityReceiver();
            SpeedData speedData = new SpeedData();
            if (TrainData.CurrentSpeed > 0)
                speedData.NewSpeed = this.GetSpeed() - 5;
            var json = JsonConvert.SerializeObject(speedData);
            receiver.SpeedChanged(json);
            Invalidate();
        }

        private async void btnTest3_Click(object sender, EventArgs e)
        {
            //SetSpeedWarning(0, 60);
            //SetSpeedCap(0, 70);
            await AuthorityData.AuthoritiyDataSemaphore.WaitAsync();
            AuthorityData.SpeedDistances = new List<double> { 0, 440, 450 };
            AuthorityData.Speeds = new List<double> { 100, 140, 60 };
            MaxSpeedsCalculation.SetBrakingAccelerationByValue(-3);
            //AuthorityData.SpeedDistances = new List<double> { 0, 450, 500, 1500 };
            //AuthorityData.Speeds = new List<double> { 130, 90, 140, 60 };
            //AuthorityData.SpeedDistances = new List<double> { 0, 250, 300};
            //AuthorityData.Speeds = new List<double> { 60, 0, 70 };
            AuthorityData.Gradients = new List<int> { 10 };
            AuthorityData.GradientsDistances = new List<double> { 0, 450 };
            TrainData.CalculatedDrivingDirection = "N";
            TrainData.ActiveMode = ETCSModes.FS;
            MaxSpeedsCalculation.Calculate(AuthorityData.Speeds, AuthorityData.SpeedDistances);
            //Console.WriteLine(" TEST " + string.Join(", ", AuthorityData.MaxSpeedsDistances));

            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        private void modeChanged(object sender, ModeInfo e)
        {
            ChangeMode(e.Bitmap);
            Console.WriteLine(e.Mode);
            TrainData.ActiveMode = e.Mode;
            TrainData.IsETCSActive = !TrainData.ActiveMode.Equals(ETCSModes.SB);
        }

        private void SpeedmeterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ETCSEvents.ModeChanged -= modeChanged;
            ETCSEvents.DistancesCalculationsCompleted -= UpdateWarningAndCap;
        }
    }
}