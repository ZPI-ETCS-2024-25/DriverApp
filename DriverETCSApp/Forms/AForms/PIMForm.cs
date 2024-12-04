using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Events;
using DriverETCSApp.Logic.Position;
using Newtonsoft.Json.Serialization;
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

namespace DriverETCSApp.Forms.AForms
{
    public partial class PIMForm : BorderLessForm
    {
        const float rectStartX = 0.6f; // Percentage 0-1
        const float rectStartY = 0.2f;
        const float rectWidth = 0.3f;
        const float rectHeight = 0.8f;

        Font numbersFont;

        List<(float percentage, bool isBold)> listOfLines = new List<(float, bool)> {
            (0f, true),
            (0.065f, false),
            (0.125f, false),
            (0.185f, false),
            (0.245f, false),
            (0.3f, true),
            (0.37f, false),
            (0.46f, false),
            (0.59f, false),
            (0.8f, false),
            (1f, true)
        };

        int distanceLeft = 2000;
        float columnPercentage = 1f; // Percentage 0-1

        public PIMForm()
        {
            InitializeComponent();
            numbersFont = new Font(this.Font.FontFamily, 17f, this.Font.Style, this.Font.Unit);

            ETCSEvents.DistancesCalculationsCompleted += UpdateDistanceLeft;
        }

        private void UpdateDistanceLeft(object sender, EventArgs e) {
            if (IsHandleCreated && !IsDisposed && !Disposing)
            {
                try
                {
                    Invoke(new Action(async () =>
                    {
                        if (!IsDisposed && !Disposing)
                        {
                            await TrainData.TrainDataSemaphofe.WaitAsync();
                            var tmp = TrainData.ActiveMode.Equals(ETCSModes.FS);
                            TrainData.TrainDataSemaphofe.Release();

                            if (!tmp)
                            {
                                panelPIM.Visible = false;
                                return;
                            }

                            await AuthorityData.AuthoritiyDataSemaphore.WaitAsync();

                            if (AuthorityData.MaxSpeedsDistances.Count > 0 
                            && AuthorityData.MaxSpeedsDistances[0] <= AuthorityData.NOTICE_DISTANCE
                            && AuthorityData.SpeedDistances.Count > 1
                            && AuthorityData.Speeds.Count > 1) {
                                if (AuthorityData.Speeds[0] > AuthorityData.MaxSpeeds[0])
                                {
                                    panelPIM.Visible = true;
                                    double distance = AuthorityData.MaxSpeedsDistancesPoints[0];
                                    SetDistanceLeft((int)distance);
                                }
                                else
                                {
                                    panelPIM.Visible = false;
                                    SetDistanceLeft(0);
                                }
                            }
                            else {
                                panelPIM.Visible = false;
                                SetDistanceLeft(0);
                            }
                            AuthorityData.AuthoritiyDataSemaphore.Release();
                        }
                    }));
                }
                catch { }
            }
        }

        private void clockPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (distanceLeft == 0)
                return;

            // Column
            Brush columnBrush = new SolidBrush(DMIColors.Grey);
            int x = (int)(panelPIM.Width * rectStartX);
            int y = (int)(panelPIM.Height * (rectStartY + rectHeight * (1f - columnPercentage))) ;
            int columnWidth = (int)(panelPIM.Width * rectWidth);
            int columnHeight = (int)(panelPIM.Height * rectHeight * columnPercentage) ;
            Rectangle rect = new Rectangle(x, y, columnWidth, columnHeight);

            g.FillRectangle(columnBrush, rect);

            // Top Text

            Brush brush = new SolidBrush(DMIColors.Grey);
            string text = ((int)distanceLeft / 10 * 10).ToString();
            SizeF textSize = e.Graphics.MeasureString(text, numbersFont);

            int xText = (int)(panelPIM.Width * rectStartX - textSize.Width / 2);
            int yText = (int)(panelPIM.Height * rectStartY - textSize.Height * 1.2f);
            g.DrawString(text, numbersFont, brush, xText, yText);

        }

        public void SetDistanceLeft(int newDistance) {
            if (newDistance <= 0)
                newDistance = 0;

            distanceLeft = newDistance;

            if(distanceLeft <= 0f) {
                columnPercentage = 0f;
            }
            if (distanceLeft > 1000f) {
                columnPercentage = 1f;
            }
            else if (distanceLeft > 500f) {
                columnPercentage = ((0.06f) * distanceLeft + 40f) / 100f;
            }
            else if ( distanceLeft >= 100f){
                columnPercentage = (int)(64.175f * Math.Log(distanceLeft) - 254.36f) / 143f * 0.7f;
            }
            else {
                columnPercentage = 0.02f * distanceLeft/10f;
            }

            panelPIM.Invalidate();
            panelPIM.Update();
        }

        public int GetDistanceLeft() { return distanceLeft; }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            SetDistanceLeft(GetDistanceLeft() - 10);
        }

        private void button1_Click(object sender, EventArgs e) {
            SetDistanceLeft(GetDistanceLeft() - 100);
        }

        private void PIMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ETCSEvents.DistancesCalculationsCompleted -= UpdateDistanceLeft;
        }
    }
}
