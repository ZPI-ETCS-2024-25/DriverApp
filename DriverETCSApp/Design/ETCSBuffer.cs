using DriverETCSApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Design
{
    public static class ETCSBuffer
    {
        public static BufferedGraphicsContext BufferedGraphicsContext;
        public static BufferedGraphics BufferedGraphics;
        public static Graphics Graphics;
        public static MainForm MainForm;
        
        public static void DrawBuffer()
        {
            MainForm.Refresh();
        }
    }
}
