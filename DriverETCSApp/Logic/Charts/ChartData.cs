using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace DriverETCSApp.Data
{
    public static class ChartData
    {
        public static double Scale = 30.3;
        public static double[] Distanses = new double[] { 0, 200, 400, 600, 800, 1000, 2000, 4000, 8000 };
        public static double[] Positions = new double[] { 0, 33, 77, 102, 120, 134, 177, 220, 263 };
        public static double[] Lines = new double[] { 0.5, 33, 77, 102, 120, 134, 177, 220, 263 };
        public static double[] LinesLabels = new double[] { 1, 0.5, 0.5, 0.5, 0.5, 1, 0.5, 0.5, 0.5 };
        public static int[] LinesThin = new int[] { 2, 1, 1, 1, 1, 2, 1, 1, 2 };
    }
}
