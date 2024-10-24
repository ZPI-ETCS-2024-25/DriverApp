using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Data
{
    public static class ETCSModes
    {
        public static string FS = "Full Supervision";
        public static string OS = "On Sight";
        public static string TR = "Trip";
        public static string PT = "Post Trip";
        public static string SB = "Stand By";
        public static string STM = "STM National";

        public static Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>(){
            { FS, Resources.FS },
            { OS, Resources.OS },
            { TR, Resources.Trip },
            { PT, Resources.PostTrip },
            { SB, Resources.SB },
            { STM, Resources.STM }
        };
    }

}
