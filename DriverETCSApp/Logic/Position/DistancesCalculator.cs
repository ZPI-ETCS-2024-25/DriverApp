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
            ClockTimer = new Timer(Calculate, null, 0, 500);
            SpeedSegragation = new SpeedSegragation();
        }

        private async void Calculate(object sender)
        {
            await AuthoritiyData.AuthoritiyDataSemaphore.WaitAsync();
            try
            {
                await TrainData.TrainDataSemaphofe.WaitAsync();
                var diffrence = TrainData.CalculatedDrivingDirection.Equals("N") ? TrainData.CalculatedPosition - TrainData.LastCalculated : TrainData.LastCalculated - TrainData.CalculatedPosition;
                //TrainData.LastCalculated = TrainData.CalculatedPosition;
                TrainData.TrainDataSemaphofe.Release();

                #region speeds and distances of speeds
                int lastIndex = -1;
                for (int i = 0; i < AuthoritiyData.SpeedDistances.Count; i++)
                {
                    AuthoritiyData.SpeedDistances[i] = AuthoritiyData.SpeedDistances[i] - diffrence;
                    if (AuthoritiyData.SpeedDistances[i] < 0)
                    {
                        lastIndex = i;
                    }
                }
                if (lastIndex != -1)
                {
                    AuthoritiyData.SpeedDistances.RemoveRange(0, lastIndex);
                    AuthoritiyData.Speeds.RemoveRange(0, lastIndex);
                    AuthoritiyData.SpeedDistances[0] = 0;
                }
                SpeedSegragation.CalculateSpeeds();
                #endregion
                #region gradients and distances of gradients
                lastIndex = -1;
                for (int i = 0; i < AuthoritiyData.GradientsDistances.Count; i++)
                {
                    AuthoritiyData.GradientsDistances[i] = AuthoritiyData.GradientsDistances[i] - diffrence;
                    if (AuthoritiyData.GradientsDistances[i] < 0)
                    {
                        lastIndex = i;
                    }
                }
                if (lastIndex != -1)
                {
                    AuthoritiyData.GradientsDistances.RemoveRange(0, lastIndex);
                    AuthoritiyData.Gradients.RemoveRange(0, lastIndex);
                    AuthoritiyData.GradientsDistances[0] = 0;
                }
                #endregion
                #region messages and distances of messages
                lastIndex = -1;
                for (int i = 0; i < AuthoritiyData.MessagesDistances.Count; i++)
                {
                    AuthoritiyData.MessagesDistances[i] = AuthoritiyData.MessagesDistances[i] - diffrence;
                    if (AuthoritiyData.MessagesDistances[i] < 0)
                    {
                        lastIndex = i;
                    }
                }
                if (lastIndex != -1)
                {
                    AuthoritiyData.MessagesDistances.RemoveRange(0, lastIndex);
                    AuthoritiyData.Messages.RemoveRange(0, lastIndex);
                    AuthoritiyData.MessagesDistances[0] = 0;
                }
                #endregion
            }
            finally
            {
                AuthoritiyData.AuthoritiyDataSemaphore.Release();
                DistancesCalculationsCompleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
