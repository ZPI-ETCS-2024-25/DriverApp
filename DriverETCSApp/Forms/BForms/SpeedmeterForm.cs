using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Logic.Calculations;
using DriverETCSApp.Logic.Data;
using DriverETCSApp.Logic.Position;
using DriverETCSApp.Properties;
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
using System.Xml.Linq;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace DriverETCSApp.Forms.BForms {
    public partial class SpeedmeterForm : BorderLessForm {

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
        private (int, int) speedCap = (0, 0); // orange
        private (int, int) speedWarning = (0, 0); // yellow

        private Font numbersFont;
        public SpeedmeterForm() {
            InitializeComponent();
            clockSize = (int)(clockPanel.Width * clockScale);
            clockOffset = (clockPanel.Width - clockSize) / 2;
            halfClockSize = (int)(clockSize / 2f);

            needleLength = halfClockSize - 30;

            numbersFont = new Font(this.Font.FontFamily, 17f, this.Font.Style, this.Font.Unit);

            ETCSEvents.ModeChanged += modeChanged;

            if (instance == null)
                instance = this;

            DistancesCalculator.OnCalculactionFinished.Add(UpdateWarningAndCap);
        }

        private void UpdateWarningAndCap() {
            if (AuthorityData.MaxSpeeds.Count > 0) {
                double max = AuthorityData.MaxSpeeds[0];
                SetSpeedWarning(0, (int)max);
            }
            else {
                SetSpeedWarning(0, 0);
                SetSpeedCap(0, 0);
            }
        }

        private void clockPanel_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the ticks and numbers
            using (var brush = new SolidBrush(DMIColors.Grey)) {
                using (var pen = new Pen(DMIColors.Grey, 3)) {
                    for (int i = 0; i <= linesCount; i++) {
                        int angle = i * clockAngle / linesCount - clockAngleOffset;
                        double radians = angle * Math.PI / 180;
                        int x1 = halfClockSize + (int)(halfClockSize * Math.Cos(radians)) + clockOffset;
                        int y1 = halfClockSize + (int)(halfClockSize * Math.Sin(radians)) + clockOffset;

                        int x2 = halfClockSize + (int)((halfClockSize - linesLength / (i % 2 + 1)) * Math.Cos(radians)) + clockOffset;
                        int y2 = halfClockSize + (int)((halfClockSize - linesLength / (i % 2 + 1)) * Math.Sin(radians)) + clockOffset;
                        g.DrawLine(pen, x1, y1, x2, y2);

                        // Draw speed numbers
                        if (i % 2 == 0) {
                            string text = (i * speedPerLine).ToString();
                            int xText = halfClockSize + (int)((halfClockSize - linesLength - speedNumbersOffset) * Math.Cos(radians)) - 20 + clockOffset;
                            int yText = halfClockSize + (int)((halfClockSize - linesLength - speedNumbersOffset) * Math.Sin(radians)) - 20 + clockOffset;
                            g.DrawString(text, numbersFont, brush, xText, yText);
                        }
                    }
                }
            }

            float needleTarget = speed / (float)speedPerLine;

            // Draw the needle
            {
                Color needleColor = GetColorForNeedle();

                int needleAngle = (int)(needleTarget * clockAngle / linesCount) - clockAngleOffset;
                double needleRadians = needleAngle * Math.PI / 180;
                int xNeedle = halfClockSize + (int)(needleLength * Math.Cos(needleRadians)) + clockOffset;
                int yNeedle = halfClockSize + (int)(needleLength * Math.Sin(needleRadians)) + clockOffset;
                g.DrawLine(new Pen(needleColor, 15), halfClockSize, halfClockSize, xNeedle + (halfClockSize - xNeedle) * 0.25f, yNeedle + (halfClockSize - yNeedle) * 0.25f);
                g.DrawLine(new Pen(needleColor, 5), halfClockSize, halfClockSize, xNeedle, yNeedle);

                // Draw needle circle
                g.FillEllipse(new SolidBrush(needleColor), halfClockSize - needleCircleRadius, halfClockSize - needleCircleRadius, needleCircleRadius * 2, needleCircleRadius * 2);
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

            // Draw Arc of Warning
            if (speedWarning != (0, 0)) {
                Rectangle rect = new Rectangle(clockOffset, clockOffset, clockSize, clockSize);

                float startAngle = -clockAngleOffset + speedWarning.Item1 * clockAngle / linesCount / speedPerLine;
                float sweepAngle = (speedWarning.Item2 - speedWarning.Item1) * clockAngle / linesCount / speedPerLine;

                Pen pen = new Pen(Color.Yellow, 8);
                e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);

                int offset = 15;
                Rectangle insideRect = new Rectangle(clockOffset + offset, clockOffset + offset, clockSize - 2*offset, clockSize - 2*offset);
                float pointerBoldness = 2f;
                float pointer = -clockAngleOffset + speedWarning.Item2 * clockAngle / linesCount / speedPerLine - pointerBoldness;
                e.Graphics.DrawArc(new Pen(Color.Yellow, 32), insideRect, pointer, pointerBoldness);
            }

            // Draw Arc of Cap
            if (speedCap != (0, 0) && speedCap.Item1 < speed) {
                int offset = 12;
                Rectangle rect = new Rectangle(clockOffset + offset, clockOffset + offset, clockSize - 2 * offset, clockSize - 2 * offset);

                float startAngle = -clockAngleOffset + speedCap.Item1 * clockAngle / linesCount / speedPerLine - 0.2f;
                float sweepAngle = (speedCap.Item2 - speedCap.Item1) * clockAngle / linesCount / speedPerLine;

                Pen pen = new Pen(speed > speedCap.Item2 ? Color.Red : Color.Orange, 32);
                e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
            }
        }

        private Color GetColorForNeedle() {
            if (speedWarning == (0, 0) || speed <= speedWarning.Item1)
                return Color.White;
            else if (speed <= speedWarning.Item2) {
                return Color.Yellow;
            }
            else if (speed <= speedCap.Item2) {
                return Color.Orange;
            }
            else
                return Color.Red;
        }

        public int GetSpeed() {
            return speed;
        }

        public static void SetSpeed(int newSpeed) {
            if (newSpeed < 0 || newSpeed > linesCount * speedPerLine) 
                return;

            instance.speed = newSpeed;
            instance.clockPanel.Invalidate();
        }

        public (int, int) GetSpeedWarning() {
            return speedWarning;
        }

        public static void SetSpeedWarning(int min, int max) {
            instance.speedWarning = (min, max);
            instance.clockPanel.Invalidate();
        }

        public (int, int) GetSpeedCap() {
            return speedCap;
        }

        public static void SetSpeedCap(int min, int max) {
            instance.speedCap = (min, max);
            instance.clockPanel.Invalidate();
        }

        public void ChangeMode(Bitmap newImage) {
            if(newImage != null) {
                modePicture.Image = newImage;
            }
        }

        private void btnTest1_Click(object sender, EventArgs e) {
            SetSpeed(this.GetSpeed() + 5);
            if (TrainData.CurrentSpeed < 180)
                TrainData.CurrentSpeed += 5;
        }

        private void btnTest2_Click(object sender, EventArgs e) {
            SetSpeed(this.GetSpeed() - 5);
            if(TrainData.CurrentSpeed > 0)
                TrainData.CurrentSpeed -= 5;
        }

        private void btnTest3_Click(object sender, EventArgs e) {
            //SetSpeedWarning(0, 60);
            //SetSpeedCap(0, 70);
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            AuthorityData.SpeedDistances = new List<double> {0, 200, 500, 1000, 2000 };
            AuthorityData.Speeds = new List<double> {10, 100, 140, 20, 50 };
            AuthorityData.Gradients = new List<int> { 10, 0, -2, 1, 5, -3 };
            AuthorityData.GradientsDistances = new List<double> { 0, 500, 1050, 2500, 3500, 4000, 7000 };
            TrainData.CalculatedDrivingDirection = "N";
            MaxSpeedsCalculation.Calculate(AuthorityData.Speeds, AuthorityData.SpeedDistances);

            AuthorityData.AuthoritiyDataSemaphore.Release();
        }

        private void modeChanged(object sender, ModeInfo e) {
            ChangeMode(e.Bitmap);
            TrainData.ActiveMode = e.Mode;
        }

        private void SpeedmeterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ETCSEvents.ModeChanged -= modeChanged;
        }
    }
}