using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            (1f, true),
            (0.04f, false),
            (0.09f, false),
            (0.14f, false),
            (0.19f, false),
            (0.25f, true),
            (0.37f, false),
            (0.46f, false),
            (0.59f, false),
            (0.8f, false),
            (0f, true)
        };

        const int maxShownDistance = 1000;
        int distanceLeft = 1010;
        float columnPercentage = 1f; // Percentage 0-1

        public PIMForm()
        {
            InitializeComponent();
            numbersFont = new Font(this.Font.FontFamily, 17f, this.Font.Style, this.Font.Unit);
        }

        private void clockPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Column
            Brush columnBrush = Brushes.White;
            int x = (int)(panelPIM.Width * rectStartX);
            int y = (int)(panelPIM.Height * (rectStartY + rectHeight * (1f - columnPercentage))) ;
            int columnWidth = (int)(panelPIM.Width * rectWidth);
            int columnHeight = (int)(panelPIM.Height * rectHeight * columnPercentage) ;
            Rectangle rect = new Rectangle(x, y, columnWidth, columnHeight);

            g.FillRectangle(columnBrush, rect);

            // Top Text
            Brush brush = Brushes.White;
            string text = distanceLeft.ToString();
            SizeF textSize = e.Graphics.MeasureString(text, numbersFont);

            int xText = (int)(panelPIM.Width * rectStartX - textSize.Width/2 + columnWidth/2) ;
            int yText = (int)(panelPIM.Height * rectStartY - textSize.Height * 1.2f);
            g.DrawString(text, numbersFont, brush, xText, yText);
           
            // Lines

            foreach ((float percentage, bool isBold) in listOfLines)
            {
                int x1 = panelPIM.Width / 4 + (!isBold ? panelPIM.Width / 8 : 0);
                int x2 = (int)(panelPIM.Width * rectStartX * 0.9f);
                int y1 = (int)(panelPIM.Height * rectStartY) + (int)(panelPIM.Height * rectHeight * percentage);
                Pen pen = new Pen(Color.White, isBold ? 5f : 2f);

                g.DrawLine(pen, x1, y1, x2, y1);
            }
        }
        
        public void SetDistanceLeft(int newDistance) {
            if (newDistance < 0f || newDistance > maxShownDistance)
                return;

            distanceLeft = newDistance;
            if (distanceLeft >= 500f) {
                columnPercentage = ((25f / 500f) * distanceLeft + 50f) / 100f;
            }
            else if ( distanceLeft >= 60f){
                columnPercentage = (int)(64.175f * Math.Log(distanceLeft) - 254.36f) / 143f * 0.7f;
            }
            else {
                columnPercentage = 0.005f * distanceLeft/10f;
            }

            lbltest.Text = columnPercentage.ToString();

            panelPIM.Invalidate();
        }

        public int GetDistanceLeft() { return distanceLeft; }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            SetDistanceLeft(GetDistanceLeft() - 10);
        }
    }
}
