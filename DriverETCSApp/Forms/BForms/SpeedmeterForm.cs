using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DriverETCSApp.Forms.BForms {
    public partial class SpeedmeterForm : BorderLessForm {

        private const int linesCount = 18;
        private const int linesLength = 30;
        private const int speedPerLine = 10;
        private const int clockAngle = 270;
        private const int clockAngleOffset = -135;
        private const int speedNumbersOffset = 20;
        private const int needleCircleRadius = 30;
        
        private int clockSize;
        private int halfClockSize;
        private int needleLength;

        private int speed = 0;
        private (int, int) speedCap = (0, 0); // orange
        private (int, int) speedWarning = (0, 0); // yellow

        public SpeedmeterForm() {
            InitializeComponent();
            this.DoubleBuffered = true;

            clockSize = (int)(clockPanel.Width * 0.99f);
            halfClockSize = (int)(clockSize / 2f);

            needleLength = halfClockSize - 50;
        }

        private void clockPanel_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the dial background
            g.FillEllipse(Brushes.White, 0, 0, clockSize, clockSize);
            g.DrawEllipse(Pens.Black, 0, 0, clockSize, clockSize);

            // Draw the ticks and numbers            
            for (int i = 0; i <= linesCount; i++) {
                int angle = i * clockAngle / linesCount - clockAngleOffset;
                double radians = angle * Math.PI / 180;
                int x1 = halfClockSize + (int)(halfClockSize * Math.Cos(radians));
                int y1 = halfClockSize + (int)(halfClockSize * Math.Sin(radians));

                int x2 = halfClockSize + (int)((halfClockSize - linesLength / (i % 2 + 1)) * Math.Cos(radians));
                int y2 = halfClockSize + (int)((halfClockSize - linesLength / (i % 2 + 1)) * Math.Sin(radians));
                g.DrawLine(Pens.Black, x1, y1, x2, y2);

                // Draw speed numbers
                if (i % 2 == 0) {
                    string text = (i * speedPerLine).ToString();
                    int xText = halfClockSize + (int)((halfClockSize - linesLength - speedNumbersOffset) * Math.Cos(radians)) - 10;
                    int yText = halfClockSize + (int)((halfClockSize - linesLength - speedNumbersOffset) * Math.Sin(radians)) - 10;
                    g.DrawString(text, this.Font, Brushes.Black, xText, yText);
                }
            }

            float needleTarget = speed / (float)speedPerLine;

            // Draw the needle
            int needleAngle = (int)(needleTarget * clockAngle / linesCount) - clockAngleOffset;
            double needleRadians = needleAngle * Math.PI / 180;
            int xNeedle = halfClockSize + (int)(needleLength * Math.Cos(needleRadians));
            int yNeedle = halfClockSize + (int)(needleLength * Math.Sin(needleRadians));
            g.DrawLine(new Pen(Color.Red, 10), halfClockSize, halfClockSize, xNeedle, yNeedle);

            // Draw needle circle
            g.FillEllipse(Brushes.Red, halfClockSize - needleCircleRadius, halfClockSize - needleCircleRadius, needleCircleRadius * 2, needleCircleRadius * 2);
            { 
                Font largerFont = new Font(this.Font.FontFamily, 20f, this.Font.Style, this.Font.Unit);
                string text = speed.ToString();
                SizeF textSize = e.Graphics.MeasureString(text, largerFont);
                int begin = (halfClockSize - needleCircleRadius);

                int xText = begin + (needleCircleRadius * 2 - (int)textSize.Width) / 2;
                int yText = begin + (needleCircleRadius * 2 - (int)textSize.Height) / 2;

                g.DrawString(speed.ToString(), largerFont, Brushes.Black, xText, yText);
            }

            // Draw Arc of Warning
            if(speedWarning != (0,0)) {
                Rectangle rect = new Rectangle(0, 0, clockSize, clockSize);

                // Define the starting angle and the sweep angle
                float startAngle = -clockAngleOffset + speedWarning.Item1 * clockAngle / linesCount / speedPerLine;
                float sweepAngle = (speedWarning.Item2 - speedWarning.Item1) * clockAngle / linesCount / speedPerLine; // Sweep angle in degrees 

                Pen pen = new Pen(Color.Yellow, 8);
                e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
            }

            // Draw Arc of Cap
            if (speedCap != (0, 0) && speedCap.Item1 < speed ) {
                Rectangle rect = new Rectangle(0, 0, clockSize, clockSize);

                // Define the starting angle and the sweep angle
                float startAngle = -clockAngleOffset + speedCap.Item1 * clockAngle / linesCount / speedPerLine;
                float sweepAngle = (speedCap.Item2 - speedCap.Item1) * clockAngle / linesCount / speedPerLine; // Sweep angle in degrees 

                Pen pen = new Pen(Color.Orange, 12);
                e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
            }
        }

        public int GetSpeed() {
            return speed;
        }

        public void SetSpeed(int newSpeed) {
            speed = newSpeed;
            clockPanel.Invalidate();
        }

        public (int, int) GetSpeedWarning() {
            return speedWarning;
        }

        public void SetSpeedWarning(int min, int max) {
            speedWarning = (min, max);
            clockPanel.Invalidate();
        }

        public (int, int) GetSpeedCap() {
            return speedCap;
        }

        public void SetSpeedCap(int min, int max) {
            speedCap = (min, max);
            clockPanel.Invalidate();
        }

        private void btnTest1_Click(object sender, EventArgs e) {
            SetSpeed(this.GetSpeed() + 5);
        }

        private void btnTest2_Click(object sender, EventArgs e) {
            SetSpeed(this.GetSpeed() - 5);
        }

        private void btnTest3_Click(object sender, EventArgs e) {
            SetSpeedWarning(0, 120);
            SetSpeedCap(120, 147);
        }
    }
}
