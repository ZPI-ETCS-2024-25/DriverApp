using System;
using System.Drawing;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class ModeInfo : EventArgs
    {
        public Bitmap Bitmap {  get; set; }

        public ModeInfo(Bitmap bitmap) 
        {
            Bitmap = bitmap;
        }
    }
}
