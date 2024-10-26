using System;
using System.Drawing;

namespace DriverETCSApp.Events.ETCSEventArgs
{
    public class ChangeLevelIcon : EventArgs
    {
        public Bitmap Icon { get; set; }
        public ChangeLevelIcon(Bitmap icon) 
        {
            Icon = icon;
        }
    }
}
