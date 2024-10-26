using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class AckInfo : EventArgs
    {
        public Bitmap Bitmap { get; set; }
        public Bitmap FlashingBitmap { get; set; }

        public AckInfo(Bitmap bitmap, Bitmap flashingBitmap)
        {
            Bitmap = bitmap;
            FlashingBitmap = flashingBitmap;
        }
    }
}
