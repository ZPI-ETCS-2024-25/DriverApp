using DriverETCSApp.Data;
using DriverETCSApp.Logic.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Position
{
    public class DistancesCalculator
    {
        private Timer ClockTimer;
        private SpeedSegragation SpeedSegragation;
        public event EventHandler DistancesCalculationsCompleted;

        public DistancesCalculator()
        {
            ClockTimer = new Timer(Calculate, null, 0, 10);
            SpeedSegragation = new SpeedSegragation();
        }

        private void Calculate(object sender)
        {
            AuthorityData.AuthoritiyDataSemaphore.Wait();
            TrainData.TrainDataSemaphofe.Wait();
            try
            {
                var diffrence = TrainData.CalculatedDrivingDirection.Equals("N") ? TrainData.CalculatedPosition - TrainData.LastCalculated : TrainData.LastCalculated - TrainData.CalculatedPosition;
                //TrainData.LastCalculated = TrainData.CalculatedPosition;
                TrainData.TrainDataSemaphofe.Release();
                #region speeds and distances of speeds
                int lastIndex = -1;
                for (int i = 0; i < AuthorityData.SpeedDistances.Count; i++)
                {
                    AuthorityData.SpeedDistances[i] = AuthorityData.SpeedDistances[i] - diffrence;
                    if (AuthorityData.SpeedDistances[i] < 0)
                    {
                        lastIndex = i;
                    }
                }
                if (lastIndex != -1)
                {
                    AuthorityData.SpeedDistances.RemoveRange(0, lastIndex);
                    AuthorityData.Speeds.RemoveRange(0, lastIndex);
                    AuthorityData.SpeedDistances[0] = 0;
                }
                SpeedSegragation.CalculateSpeeds();
                #endregion
                #region gradients and distances of gradients
                lastIndex = -1;
                for (int i = 0; i < AuthorityData.GradientsDistances.Count; i++)
                {
                    AuthorityData.GradientsDistances[i] = AuthorityData.GradientsDistances[i] - diffrence;
                    if (AuthorityData.GradientsDistances[i] < 0)
                    {
                        lastIndex = i;
                    }
                }
                if (lastIndex != -1)
                {
                    AuthorityData.GradientsDistances.RemoveRange(0, lastIndex);
                    AuthorityData.Gradients.RemoveRange(0, lastIndex);
                    AuthorityData.GradientsDistances[0] = 0;
                }
                #endregion
                #region messages and distances of messages
                lastIndex = -1;
                for (int i = 0; i < AuthorityData.MessagesDistances.Count; i++)
                {
                    AuthorityData.MessagesDistances[i] = AuthorityData.MessagesDistances[i] - diffrence;
                    if (AuthorityData.MessagesDistances[i] < 0)
                    {
                        lastIndex = i;
                    }
                }
                if (lastIndex != -1)
                {
                    AuthorityData.MessagesDistances.RemoveRange(0, lastIndex);
                    AuthorityData.Messages.RemoveRange(0, lastIndex);
                    AuthorityData.MessagesDistances[0] = 0;
                }
                #endregion
            }
            finally
            {
                AuthorityData.AuthoritiyDataSemaphore.Release();
                DistancesCalculationsCompleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
