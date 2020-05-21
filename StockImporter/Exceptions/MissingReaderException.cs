using System;

namespace StockImporter.Exceptions
{
    public class MissingReaderException : Exception
    {
        public MissingReaderException()
        {
        }

        public MissingReaderException(string message) : base(message)
        {
        }

        public MissingReaderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
