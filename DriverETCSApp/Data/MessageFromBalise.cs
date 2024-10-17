namespace DriverETCSApp.Data
{
    internal class MessageFromBalise
    {
        public string Kilometer { get; set; }
        public int Number { get; set; }
        public int NumberOfBalises { get; set; }
        public string TrackNumber { get; set; }
        public int LineNumber { get; set; }
        public string MessageType { get; set; }

        public MessageFromBalise() { }

        public MessageFromBalise(string kilometer, int number, int numberOfBalises, string trackNumber, int lineNumber, string messageType)
        {
            Kilometer = kilometer;
            Number = number;
            NumberOfBalises = numberOfBalises;
            TrackNumber = trackNumber;
            LineNumber = lineNumber;
            MessageType = messageType;
        }
    }
}
