﻿using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Logic.Calculations;
using DriverETCSApp.Logic.Data;
using DriverETCSApp.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Position
{
    public class DistancesCalculator
    {
        private Timer ClockTimer;
        private SpeedSegragation SpeedSegragation;

        public DistancesCalculator()
        {
            ClockTimer = new Timer(Initcalculate, null, 0, 500);
            SpeedSegragation = new SpeedSegragation();
        }

        public async void Initcalculate(object sender)
        {
            await AuthorityData.AuthoritiyDataSemaphore.WaitAsync();
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                Calculate(null);
                if (AuthorityData.Speeds.Count > 0 && AuthorityData.SpeedDistances.Count > 0)
                {
                    MaxSpeedsCalculation.Calculate(AuthorityData.Speeds, AuthorityData.SpeedDistances);
                }
                EmergencyBrakeManager.CheckSpeed();
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
                AuthorityData.AuthoritiyDataSemaphore.Release();
                ETCSEvents.OnDistancesCalculationsCompleted();
            }
        }

        public void Calculate(object sender)
        {
            var diffrence = TrainData.CalculatedDrivingDirection.Equals("N") ? TrainData.CalculatedPosition - TrainData.LastCalculated : TrainData.LastCalculated - TrainData.CalculatedPosition;
            TrainData.LastCalculated = TrainData.CalculatedPosition;
            double distancePassed = TrainData.CalculatedDrivingDirection.Equals("N") ?  PositionApproximation.ApproximateMovedDistance() : PositionApproximation.ApproximateMovedDistance() * -1;
            TrainData.CalculatedPosition += distancePassed;
            //Console.WriteLine(string.Join(", ", AuthorityData.MaxSpeedsDistances) + "   " + AuthorityData.CalculatedSpeedLimit);

            #region distances of maxSpeeds
            int lastIndex = -1;
            for (int i = 0; i < AuthorityData.MaxSpeedsDistances.Count; i++) {
                AuthorityData.MaxSpeedsDistances[i] = AuthorityData.MaxSpeedsDistances[i] - diffrence;
                if (AuthorityData.MaxSpeedsDistances[i] < 0) {
                    lastIndex = i;
                }
            }
            if (lastIndex != -1) {
                //Console.WriteLine(AuthorityData.Speeds[0] +" > " + AuthorityData.MaxSpeeds[0]);
                if (AuthorityData.Speeds[0] > AuthorityData.MaxSpeeds[0]) {
                    AuthorityData.CalculatedSpeedLimit = AuthorityData.Speeds[0];
                    AuthorityData.FallTo = AuthorityData.MaxSpeeds[0];
                }

                AuthorityData.MaxSpeedsDistances.RemoveRange(0, lastIndex + 1);
                AuthorityData.MaxSpeeds.RemoveRange(0, lastIndex + 1);
            }
            if (AuthorityData.CalculatedSpeedLimit > 0) {
                MaxSpeedsCalculation.CountDownCalculatedMaxSpeed(Math.Abs(distancePassed));
            }
            #endregion
            #region speeds and distances of speeds
            lastIndex = -1;
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
                if(AuthorityData.Speeds[lastIndex] == AuthorityData.FallTo) {
                    AuthorityData.CalculatedSpeedLimit = 0;
                    AuthorityData.FallTo = 0;
                }
                AuthorityData.SpeedDistances.RemoveRange(0, lastIndex);
                AuthorityData.Speeds.RemoveRange(0, lastIndex);
            }

            if (AuthorityData.SpeedDistances.Count > 0)
            {
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
            if (lastIndex != -1 && AuthorityData.Gradients.Count > 0)
            {
                AuthorityData.GradientsDistances.RemoveRange(0, lastIndex);
                AuthorityData.Gradients.RemoveRange(0, lastIndex);
            }
            if (AuthorityData.SpeedDistances.Count > 0)
            {
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
                    ETCSEvents.OnNewSystemMessage(new Events.ETCSEventArgs.MessageInfo(DateTime.Now.ToString("HH:mm"), AuthorityData.Messages[i]));
                    lastIndex = i;
                }
            }
            if (lastIndex != -1)
            {
                AuthorityData.MessagesDistances.RemoveRange(0, lastIndex + 1);
                AuthorityData.Messages.RemoveRange(0, lastIndex + 1);
            }
            #endregion
            #region check for pass EoA
            CheckEoA();
            #endregion
        }

        public void TurnOffClock()
        {
            ClockTimer.Dispose();
        }

        private void CheckEoA()
        {
            if(TrainData.ActiveMode.Equals(ETCSModes.FS))
            {
                if (AuthorityData.Speeds.Count > 0)
                {
                    if (AuthorityData.Speeds[0] == 0)
                    {
                        ETCSEvents.OnModeChanged(new ModeInfo(Resources.Trip, ETCSModes.TR));
                        ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "Nieautoryzowane pominięcie EoA/LoA"));
                    }
                }
            }
        }
    }
}
