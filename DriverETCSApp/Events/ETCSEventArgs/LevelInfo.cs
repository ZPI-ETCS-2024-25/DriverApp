using System;
using System.Drawing;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class LevelInfo : EventArgs
    {
        public Bitmap Bitmap { get; set; }
        public bool WillBeActive { get; set; }

        public LevelInfo(Bitmap bitmap, bool willBeActive)
        {
            Bitmap = bitmap;
            WillBeActive = willBeActive;
        }
    }
}
