using DriverETCSApp.Data;
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
            List<int> lines = decodedMessage.Lines.ToObject<List<int>>();
            List<double> linesDistances = decodedMessage.LinesDistances.ToObject<List<double>>();

            int position = decodedMessage.ServerPosition * 1000;
            double diffrence = 0;
            if (lines[0] == TrainData.BaliseLinePosition)
            {
                diffrence = TrainData.CalculatedDrivingDirection.Equals("N") ? TrainData.CalculatedPosition - position : position - TrainData.CalculatedPosition;
            }
            else
            {
                int i = 0;
                for (; i < linesDistances.Count - 1; i++)
                {
                    if (lines[i] != TrainData.BaliseLinePosition)
                    {
                        diffrence += (linesDistances[i + 1] - linesDistances[i]);
                    }
                    else
                    {
                        break;
                    }
                }
                diffrence += TrainData.CalculatedDrivingDirection.Equals("N") ? TrainData.CalculatedPosition - TrainData.BalisePosition : TrainData.BalisePosition - TrainData.CalculatedPosition;
            }

            #region load speeds and distances of speeds
            int lastIndex = -1;
            for (int i = 0; i < speeddistances.Count; i++)
            {
                if (i == 0 && diffrence < 0)
                {

                }
                else
                {
                    speeddistances[i] = speeddistances[i] - diffrence;
                }
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
                if (i == 0 && diffrence < 0)
                {

                }
                else
                {
                    gradientsDistances[i] = gradientsDistances[i] - diffrence;
                }
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
                if (i == 0 && diffrence < 0 && messagesDistances.Count == 1)
                {

                }
                else
                {
                    messagesDistances[i] = messagesDistances[i] - diffrence;
                }
                if (messagesDistances[i] < 0)
                {
                    lastIndex = i;
                }
            }
            if (lastIndex != -1)
            {
                messagesDistances.RemoveRange(0, lastIndex + 1);
                messages.RemoveRange(0, lastIndex + 1);
            }
            #endregion

            await AuthorityData.AuthoritiyDataSemaphore.WaitAsync();
            try
            {
                AuthorityData.Speeds = speeds;
                AuthorityData.SpeedDistances = speeddistances;
                AuthorityData.Gradients = gradients;
                AuthorityData.GradientsDistances = gradientsDistances;
                AuthorityData.Messages = messages;
                AuthorityData.MessagesDistances = messagesDistances;
                AuthorityData.Lines = lines;
                AuthorityData.LinesDistances = linesDistances;
            }
            finally 
            { 
                AuthorityData.AuthoritiyDataSemaphore.Release(); 
            }
            TrainData.LastCalculated = TrainData.CalculatedPosition;
            SpeedSegragation.CalculateSpeeds();
        }
    }
}
