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

        float rectStartX = 0.6f; // Percentage 0-1
        float rectStartY = 0.2f;
        float rectWidth = 0.3f;
        float rectHeight = 0.8f;

        List<(float percentage, bool isBold)> listOfLines = new List<(float, bool)> {
            (1f, true),
            (0.5f, true),
            (0.25f, false),
            (0f, true)
        };

        int distanceLeft = 0;
        int columnHeight = 100; // percent 0-100

        public PIMForm()
        {
            InitializeComponent();
        }

        private void clockPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int x = (int)(panelPIM.Width * rectStartX);
            int y = (int)(panelPIM.Height * rectStartY);
            int width = (int)(panelPIM.Width * rectWidth);
            int height = (int)(panelPIM.Height * rectHeight);
            Rectangle rect = new Rectangle(x, y, width, height);

            g.FillRectangle(Brushes.White, rect);


            //using (Brush brush = Brushes.White) {
            //    string text = "100";
            //    int xText = 0;
            //    int yText = 0;
            //    g.DrawString(text, numbersFont, brush, xText, yText);
            //}

            foreach ((float percentage, bool isBold) in listOfLines)
            {
                int x1 = 1;
                int x2 = (int)(panelPIM.Width * rectStartX * 0.9f);
                int y1 = (int)(panelPIM.Height * rectStartY) + (int)(panelPIM.Height * rectHeight * percentage);
                Pen pen = new Pen(Color.White, isBold ? 5f : 2f);

                g.DrawLine(pen, x1, y1, x2, y1);
            }
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {

        }
    }
}
