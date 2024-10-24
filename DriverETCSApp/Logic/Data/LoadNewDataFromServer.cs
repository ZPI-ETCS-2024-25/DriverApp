﻿using DriverETCSApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Data
{
    public class LoadNewDataFromServer
    {
        private SpeedSegragation SpeedSegragation;

        public LoadNewDataFromServer() 
        {
            SpeedSegragation = new SpeedSegragation();
        }

        public async void LoadNewData(dynamic decodedMessage)
        {
            List<double> speeds = decodedMessage.Speeds.ToObject<List<double>>();
            List<double> speeddistances = decodedMessage.SpeedDistances.ToObject<List<double>>();
            List<int> gradients = decodedMessage.Gradients.ToObject<List<int>>();
            List<double> gradientsDistances = decodedMessage.GradientsDistances.ToObject<List<double>>();
            List<string> messages = decodedMessage.Messages.ToObject<List<string>>();
            List<double> messagesDistances = decodedMessage.MessagesDistances.ToObject<List<double>>();

            int position = decodedMessage.Position * 1000;
            double diffrence;
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                diffrence = TrainData.CalculatedDrivingDirection.Equals("N") ? TrainData.CalculatedPosition - position : TrainData.CalculatedPosition + position;
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }

            #region load speeds and distances of speeds
            int lastIndex = -1;
            for (int i = 0; i < speeddistances.Count; i++)
            {
                speeddistances[i] = speeddistances[i] - diffrence;
                if (speeddistances[i] < 0)
                {
                    lastIndex = i;
                }
            }
            if (lastIndex != -1)
            {
                speeddistances.RemoveRange(0, lastIndex);
                speeds.RemoveRange(0, lastIndex);
                speeddistances[0] = 0;
            }
            #endregion
            #region load gradients and distances of gradients
            lastIndex = -1;
            for (int i = 0; i < gradientsDistances.Count; i++)
            {
                gradientsDistances[i] = gradientsDistances[i] - diffrence;
                if (gradientsDistances[i] < 0)
                {
                    lastIndex = i;
                }
            }
            if (lastIndex != -1)
            {
                gradientsDistances.RemoveRange(0, lastIndex);
                gradients.RemoveRange(0, lastIndex);
                gradientsDistances[0] = 0;
            }
            #endregion
            #region load messages and distances of messages
            lastIndex = -1;
            for (int i = 0; i < messagesDistances.Count; i++)
            {
                messagesDistances[i] = messagesDistances[i] - diffrence;
                if (messagesDistances[i] < 0)
                {
                    lastIndex = i;
                }
            }
            if (lastIndex != -1)
            {
                messagesDistances.RemoveRange(0, lastIndex);
                messages.RemoveRange(0, lastIndex);
                messagesDistances[0] = 0;
            }
            #endregion

            AuthorityData.Speeds = speeds;
            AuthorityData.SpeedDistances = speeddistances;
            AuthorityData.Gradients = gradients;
            AuthorityData.GradientsDistances = gradientsDistances;
            AuthorityData.Messages = messages;
            AuthorityData.MessagesDistances = messagesDistances;
            SpeedSegragation.CalculateSpeeds();
        }
    }
}