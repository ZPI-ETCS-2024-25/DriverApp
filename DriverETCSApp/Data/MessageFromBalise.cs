namespace DriverETCSApp.Data
{
    public class MessageFromBalise
    {
        public string kilometer { get; set; }
        public int number { get; set; }
        public int numberOfBalises { get; set; }
        public string trackNumber { get; set; }
        public int lineNumber { get; set; }
        public string messageType { get; set; }

        public MessageFromBalise() { }

        public MessageFromBalise(string kilometer, int number, int numberOfBalises, string trackNumber, int lineNumber, string messageType)
        {
            this.kilometer = kilometer;
            this.number = number;
            this.numberOfBalises = numberOfBalises;
            this.trackNumber = trackNumber;
            this.lineNumber = lineNumber;
            this.messageType = messageType;
        }
    }
}
