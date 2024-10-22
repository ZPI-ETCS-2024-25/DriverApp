﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private List<Message> messages;
        private const int maxLinesShown = 5;

        public MessagesForm() {
            InitializeComponent();

            messages = new List<Message>();
            messages.Add(new Message("17:31", "Test"));
            messages.Add(new Message("16:21", "Test3"));
            messages.Add(new Message("15:21", "Uno Dos Tres Cuatro 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7"));
            messages.Add(new Message("15:21", "Uno Dos Tres Cuatro 12345678901234567890123456789012345"));
            messages.Add(new Message("13:21", "Test4"));
            messages.Add(new Message("13:21", "WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW"));
        }

        private string BiggestFittingText(RichTextBox richTextBox, string testString) {
            const int safeSpace = 2;
            string originalText = richTextBox.Text;
            int charsToFit = testString.Length;

            for (int i = 1; i <= testString.Length; i++) {
                richTextBox.Text = testString.Substring(0, i);

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
                    wholeString = emptyDateString + wholeString;
                    result.Add(part);
                }
            }

            return result;
        }

        private void buttonTest_Click(object sender, EventArgs e) {

            List<string> linesOfMessages = ConvertToLinesOfStrings(messages);
            string result = "";
            for (int i = 0; i < maxLinesShown; i++) {
                result += linesOfMessages[i] + "\n";
            }
            result = result.Remove(result.Length - 1);
            messagebox.Text = result;
        }
    }
}
