using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Data
{
    public static class EncryptionData
    {
        public static byte[] Key = Convert.FromBase64String("YD3rEBXKcb4rc67whX13gR81LAc7YQjXLZgQowkU3/Q=");
        public static byte[] IV = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw==");
    }
}
