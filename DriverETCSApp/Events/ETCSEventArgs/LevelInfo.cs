using System;
using System.Drawing;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class LevelInfo : EventArgs
    {
        public Bitmap Bitmap { get; set; }

        public LevelInfo(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }
    }
}
