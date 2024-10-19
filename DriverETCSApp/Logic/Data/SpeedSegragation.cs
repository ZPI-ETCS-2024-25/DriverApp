using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Data
{
    public class SpeedSegragation
    {
        public SpeedSegragation() { }

        public void CalculateSpeeds()
        {
            AuthorytiData.LowerDistances.Clear();
            AuthorytiData.HigherDistances.Clear();
            AuthorytiData.LowerSpeed.Clear();
            AuthorytiData.HigherSpeed.Clear();
            if(AuthorytiData.Speeds.Count == 0)
            {
                return;
            }

            double actualSpeed = AuthorytiData.Speeds[0];

            for (int i = 1; i < AuthorytiData.Speeds.Count; i++)
            {
                if(actualSpeed < AuthorytiData.Speeds[i])
                {
                    AuthorytiData.HigherDistances.Add(AuthorytiData.SpeedDistances[i]);
                    AuthorytiData.HigherSpeed.Add(AuthorytiData.Speeds[i]);
                }
                else
                {
                    AuthorytiData.LowerDistances.Add(AuthorytiData.SpeedDistances[i]);
                    AuthorytiData.LowerSpeed.Add(AuthorytiData.Speeds[i]);
                }
                actualSpeed = AuthorytiData.Speeds[i];
            }
        }
    }
}
