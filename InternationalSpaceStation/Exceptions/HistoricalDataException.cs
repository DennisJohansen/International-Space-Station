namespace InternationalSpaceStation.Exceptions
{
    public class HistoricalDataException : Exception
    {
        public HistoricalDataException(string message) : base(message) { }
        public HistoricalDataException(string message, Exception ex) : base(message, ex) { }
    }
}
