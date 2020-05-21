using System;

namespace StockImporter.Exceptions
{
    public class MissingParserException : Exception
    {
        public MissingParserException()
        {
        }

        public MissingParserException(string message) : base(message)
        {
        }

        public MissingParserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
