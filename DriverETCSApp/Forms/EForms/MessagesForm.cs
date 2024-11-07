using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DriverETCSApp.Forms.EForms
{
    public struct Message
    {
        public string date;
        public string message;
        public int timeToDie;
        private DateTime timeCreated;

        public Message(string date, string message, int timeToDie = 30) : this()
        {
            this.date = date;
            this.message = message;
            this.timeToDie = timeToDie;
            this.timeCreated = DateTime.Now;
        }

        public bool IsExpired() {
            return (DateTime.Now - timeCreated).TotalSeconds >= timeToDie;
        }
    }

    public partial class MessagesForm : BorderLessForm
    {
        private int messageIndex = 0;

        private List<Message> messages;
        private const int maxLinesShown = 5;

        public MessagesForm()
        {
            InitializeComponent();

            messages = new List<Message>();

            RefreshMessages();

            LoadConnection();
            ETCSEvents.ConnectionChanged += ChangeConnection;
            ETCSEvents.NewSystemMessage += NewSystemMessage;

            Task.Run(() => DeleteExpiredMessages());
        }

        private async Task DeleteExpiredMessages() {
            bool updateNecessary = false;
            while(true) {
                for(int i = 0; i < messages.Count; i++) {
                    if (messages[i].IsExpired()) {
                        messages.Remove(messages[i]);
                        i--;
                        updateNecessary = true;
                    }
                }

                if(updateNecessary) {
                    this.Invoke((MethodInvoker)(() => RefreshMessages()));
                    updateNecessary = false;
                }
                await Task.Delay(1000);
            }
        }

        private string BiggestFittingText(RichTextBox richTextBox, string testString)
        {
            const int safeSpace = 2;
            string originalText = richTextBox.Text;
            int charsToFit = testString.Length;

            for (int i = 1; i <= testString.Length; i++)
            {
                richTextBox.Text = testString.Substring(0, i);

                if (testString[i - 1] == '\n')
                {
                    charsToFit = i - 1;
                    break;
                }

                if (richTextBox.GetLineFromCharIndex(richTextBox.TextLength - 1) > 0)
                {
                    charsToFit = i - 1 - safeSpace;
                    break;
                }
            }

            richTextBox.Text = originalText;
            return testString.Substring(0, charsToFit);
        }

        private List<string> ConvertToLinesOfStrings(List<Message> listOfMessages)
        {
            List<string> result = new List<string>();
            const string emptyDateString = "           ";

            foreach (Message msg in listOfMessages)
            {
                string wholeString = msg.date + " " + msg.message;

                while (wholeString != emptyDateString)
                {
                    string part = BiggestFittingText(messagebox, wholeString);
                    wholeString = wholeString.Remove(0, part.Length);
                    if (wholeString.Count() > 0 && wholeString[0] == '\n')
                        wholeString = wholeString.Remove(0, 1);
                    wholeString = emptyDateString + wholeString;
                    result.Add(part);
                }
            }

            return result;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            string[] messages = { "You've Got new message!!!", "test", "Drived over balise", ":)", "test test test test test test test" };
            Random random = new Random();

            string randomString = messages[random.Next(messages.Length)];

            AddMessage(DateTime.Now, randomString);
        }

        private void buttonTest2_Click(object sender, EventArgs e)
        {
            PopOldestMessage();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (messageIndex < messages.Count - 1 && messages.Count > maxLinesShown)
                messageIndex++;
            RefreshMessages();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (messageIndex > 0 && messages.Count > maxLinesShown)
                messageIndex--;
            RefreshMessages();
        }

        public void RefreshMessages()
        {
            // Buttons
            if (messageIndex == 0 || messages.Count <= maxLinesShown)
                buttonUP.Image = Resources.UPDarkGray;
            else
                buttonUP.Image = Resources.UPGray;

            if (messageIndex >= messages.Count - 1 || messages.Count <= maxLinesShown)
                buttonDOWN.Image = Resources.DOWNDarkGray;
            else
                buttonDOWN.Image = Resources.DOWNGray;
            // Messages
            if (messages.Count == 0) {
                messagebox.Text = "";
                return;
            }
            
            List<string> linesOfMessages = ConvertToLinesOfStrings(messages.AsEnumerable().Reverse().Skip(messageIndex).ToList());
            string result = "";
            for (int i = 0; i < maxLinesShown && i < linesOfMessages.Count; i++) {
                result += linesOfMessages[i] + "\n";
            }
            result = result.Remove(result.Length - 1);
            messagebox.Text = result;
        }

        public void AddMessage(DateTime time, string contents)
        {
            messages.Add(new Message(time.ToString("hh:mm"), contents));

            messageIndex = 0;
            RefreshMessages();
        }

        public void PopOldestMessage()
        {
            if (messages.Count == 0)
                return;
            messages.RemoveAt(0);
            
            messageIndex = 0;
            RefreshMessages();
        }

        private void ChangeConnection(object sender, ConnectionInfo e)
        {
            RBCConnectionPicture.Image = e.Bitmap;
        }

        private async void LoadConnection()
        {
            await TrainData.TrainDataSemaphofe.WaitAsync();
            if (!TrainData.IsTrainRegisterOnServer)
            {
                RBCConnectionPicture.Image = null;
            }
            else if(TrainData.IsTrainRegisterOnServer && TrainData.IsConnectionWorking)
            {
                RBCConnectionPicture.Image = Resources.ConnectionSet;
            }
            else
            {
                RBCConnectionPicture.Image = Resources.NoConnection;
            }
            TrainData.TrainDataSemaphofe.Release();
        }

        private void NewSystemMessage(object sender, MessageInfo e)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    if (!IsDisposed && !Disposing)
                    {
                        messages.Add(new Message(e.Time, e.Message));
                        RefreshMessages();
                    }
                }));
            }
        }

        private void MessagesForm_FormClosing(object sender, FormClosingEventArgs e) {
            ETCSEvents.ConnectionChanged -= ChangeConnection;
            ETCSEvents.NewSystemMessage -= NewSystemMessage;
        }
    }
}
