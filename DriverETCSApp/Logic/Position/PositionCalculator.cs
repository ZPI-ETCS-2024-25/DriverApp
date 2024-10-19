using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Position
{
    public class PositionCalculator
    {
        private Timer ClockTimer;

        public PositionCalculator() 
        {
            ClockTimer = new Timer(Calculate, null, 0, 250);
        }

        private void Calculate(object sender)
        {
            
        }
    }
}
