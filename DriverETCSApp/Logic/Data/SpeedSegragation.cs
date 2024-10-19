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
            AuthoritiyData.LowerDistances.Clear();
            AuthoritiyData.HigherDistances.Clear();
            AuthoritiyData.LowerSpeed.Clear();
            AuthoritiyData.HigherSpeed.Clear();
            if(AuthoritiyData.Speeds.Count == 0)
            {
                return;
            }

            double actualSpeed = AuthoritiyData.Speeds[0];

            for (int i = 1; i < AuthoritiyData.Speeds.Count; i++)
            {
                if(actualSpeed < AuthoritiyData.Speeds[i])
                {
                    AuthoritiyData.HigherDistances.Add(AuthoritiyData.SpeedDistances[i]);
                    AuthoritiyData.HigherSpeed.Add(AuthoritiyData.Speeds[i]);
                }
                else
                {
                    AuthoritiyData.LowerDistances.Add(AuthoritiyData.SpeedDistances[i]);
                    AuthoritiyData.LowerSpeed.Add(AuthoritiyData.Speeds[i]);
                }
                actualSpeed = AuthoritiyData.Speeds[i];
            }
        }
    }
}
