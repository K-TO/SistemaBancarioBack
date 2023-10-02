namespace SatrackBank.Entities.Exceptions
{
    public class GeneralException : Exception
    {
        public GeneralException() { }

        public GeneralException(string message) : base(message) { }

        public GeneralException(string message, Exception innerException) : base(message, innerException) { }

        public GeneralException(string title, string detail) : base(title) => Details = detail;

        public string Details { get; set; }
    }
}
