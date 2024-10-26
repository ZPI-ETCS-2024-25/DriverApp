using System;
using System.Drawing;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class ConnectionInfo : EventArgs
    {
        public Bitmap Bitmap { get; set; }

        public ConnectionInfo(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }
    }
}
