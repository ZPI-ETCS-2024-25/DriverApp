using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private List<Message> messages;

        public MessagesForm() {
            InitializeComponent();

            messages = new List<Message>();
            messages.Add(new Message("17:31", "Test"));
            messages.Add(new Message("16:21", "Test23"));
            messages.Add(new Message("15:21", "Uno Dos Tres Cuatro taatatatataata"));
            messages.Add(new Message("13:21", "Test4"));
        }

        private int GetMaxCharsPerLine(RichTextBox richTextBox) {
            string testString = new string('W', 200);

            int charsToFit = 0;

            string originalText = richTextBox.Text;

            for (int i = 1; i <= testString.Length; i++) {
                richTextBox.Text = testString.Substring(0, i);

                if (richTextBox.GetLineFromCharIndex(richTextBox.TextLength - 1) > 0) {
                    charsToFit = i - 1;
                    break;
                }
            }

            richTextBox.Text = originalText;

            return charsToFit;
        }
        private List<string> SplitStringIntoChunks(string input, int chunkSize) {
            List<string> result = new List<string>();

            for (int i = 0; i < input.Length; i += chunkSize) {
                string chunk = input.Substring(i, Math.Min(chunkSize, input.Length - i));
                result.Add(chunk);
            }

            return result;
        }

        private List<string> ConvertToLinesOfStrings(List<Message> listOfMessages) {
            List<string> result = new List<string>();
            const int dateLength = 6;
            int maxCharsPerLine = GetMaxCharsPerLine(messagebox);
            
            foreach (Message msg in listOfMessages) {
                string date = msg.date;
                List<string> lineMessage = SplitStringIntoChunks(msg.message, maxCharsPerLine - dateLength);

                result.Add(date + " " + lineMessage[0]);
                
                for(int i = 1; i < lineMessage.Count; i++) {
                    result.Add("           " + lineMessage[i]);
                }
            }

            return result;
        }

        private void buttonTest_Click(object sender, EventArgs e) {
            const int maxLines = 5;

            List<string> linesOfMessages = ConvertToLinesOfStrings(messages);
            string result = "";
            foreach (string msg in linesOfMessages) {
                result += msg + "\n";
            }

            messagebox.Text = result;
        }
    }
}
