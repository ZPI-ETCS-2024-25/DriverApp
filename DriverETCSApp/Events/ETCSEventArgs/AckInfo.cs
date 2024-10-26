using System;
using System.Collections.Generic;
using System.Drawing;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class AckInfo : EventArgs
    {
        public Bitmap Bitmap { get; set; }
        public Bitmap FlashingBitmap { get; set; }
        public Bitmap Level { get; set; }
        public bool WillBeActive { get; set; }

        public AckInfo(Bitmap bitmap, Bitmap flashingBitmap, Bitmap level, bool willBeActive)
        {
            Bitmap = bitmap;
            FlashingBitmap = flashingBitmap;
            Level = level;
            WillBeActive = willBeActive;
        }
    }
}
