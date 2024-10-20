namespace DriverETCSApp.Data
{
    internal class MessageFromBalise
    {
        public string Kilometer { get; set; }
        public int Number { get; set; }
        public int GroupSize { get; set; }
        public string Track { get; set; }
        public int Line { get; set; }
        public string MessageType { get; set; }

        public MessageFromBalise() { }

        public MessageFromBalise(string kilometer, int number, int groupSize, string trackNumber, int lineNumber, string messageType)
        {
            Kilometer = kilometer;
            Number = number;
            GroupSize = groupSize;
            Track = trackNumber;
            Line = lineNumber;
            MessageType = messageType;
        }
    }
}
