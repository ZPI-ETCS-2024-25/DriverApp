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
            AuthorityData.LowerDistances.Clear();
            AuthorityData.HigherDistances.Clear();
            AuthorityData.LowerSpeed.Clear();
            AuthorityData.HigherSpeed.Clear();
            if(AuthorityData.Speeds.Count == 0)
            {
                return;
            }

            double actualSpeed = AuthorityData.Speeds[0];

            for (int i = 1; i < AuthorityData.Speeds.Count; i++)
            {
                if(actualSpeed < AuthorityData.Speeds[i])
                {
                    AuthorityData.HigherDistances.Add(AuthorityData.SpeedDistances[i]);
                    AuthorityData.HigherSpeed.Add(AuthorityData.Speeds[i]);
                }
                else
                {
                    AuthorityData.LowerDistances.Add(AuthorityData.SpeedDistances[i]);
                    AuthorityData.LowerSpeed.Add(AuthorityData.Speeds[i]);
                }
                actualSpeed = AuthorityData.Speeds[i];
            }
        }
    }
}
