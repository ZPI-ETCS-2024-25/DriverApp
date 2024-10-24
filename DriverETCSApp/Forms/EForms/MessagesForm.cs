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

namespace DriverETCSApp.Forms.EForms {

    public struct Message {
        public string date;
        public string message;

        public Message(string date, string message) : this() {
            this.date = date;
            this.message = message;
        }
    }

    public partial class MessagesForm : BorderLessForm {

        private int messageIndex = 0; 

        private List<Message> messages;
        private const int maxLinesShown = 6;

        public MessagesForm() {
            InitializeComponent();

            messages = new List<Message>();

            messages.Add(new Message("13:11", "Test 3"));
            messages.Add(new Message("13:20", "☺"));
            messages.Add(new Message("15:21", "Test 2"));
            messages.Add(new Message("17:31", "Test "));
            messages.Add(new Message("15:24", "Najechano na balisę! \nWysłano informację do serwera"));
            messages.Add(new Message("16:01", "123456789012345678901234567890123456789012345678901234567890"));

            RefreshMessages();
        }

        private string BiggestFittingText(RichTextBox richTextBox, string testString) {
            const int safeSpace = 2;
            string originalText = richTextBox.Text;
            int charsToFit = testString.Length;

            for (int i = 1; i <= testString.Length; i++) {
                richTextBox.Text = testString.Substring(0, i);

                if (testString[i - 1] == '\n') {
                    charsToFit = i - 1;
                    break;
                }

                if (richTextBox.GetLineFromCharIndex(richTextBox.TextLength - 1) > 0) {
                    charsToFit = i - 1 - safeSpace;
                    break;
                }
            }

            richTextBox.Text = originalText;
            return testString.Substring(0, charsToFit) ;
        }

        private List<string> ConvertToLinesOfStrings(List<Message> listOfMessages) {
            List<string> result = new List<string>();
            const string emptyDateString = "           ";
            
            foreach (Message msg in listOfMessages) {
                string wholeString = msg.date + " " + msg.message;
                
                while(wholeString != emptyDateString) {
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

        private void buttonTest_Click(object sender, EventArgs e) {
            AddMessage("19:10", "You've got new Message!!!");
        }

        private void buttonTest2_Click(object sender, EventArgs e) {
            PopOldestMessage();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e) {
            if (messageIndex < messages.Count - 1)
                messageIndex++;
            RefreshMessages();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            if (messageIndex > 0)
                messageIndex--;
            RefreshMessages();
        }

        public void RefreshMessages() {
            if(messages.Count == 0) {
                messagebox.Text = "";
                return;
            }

            List<string> linesOfMessages = ConvertToLinesOfStrings(messages.Skip(messageIndex).ToList());
            string result = "";
            for (int i = 0; i < maxLinesShown && i < linesOfMessages.Count; i++) {
                result += linesOfMessages[i] + "\n";
            }
            result = result.Remove(result.Length - 1);
            messagebox.Text = result;
        }

        public void AddMessage(string time, string contents) {
            messages.Add(new Message(time, contents));
            RefreshMessages();
        }

        public void PopOldestMessage() {
            if (messages.Count == 0)
                return;
            messages.RemoveAt(0);
            RefreshMessages();
        }


    }
}
