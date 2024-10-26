using System;
using System.Drawing;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class ModeInfo : EventArgs
    {
        public Bitmap Bitmap {  get; set; }
        public string Mode { get; set; }

        public ModeInfo(Bitmap bitmap, string mode) 
        {
            Bitmap = bitmap;
            Mode = mode;
        }
    }
}
