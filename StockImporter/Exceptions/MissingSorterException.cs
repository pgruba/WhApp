using System;

namespace StockImporter.Exceptions
{
    public class MissingSorterException : Exception
    {
        public MissingSorterException()
        {
        }

        public MissingSorterException(string message) : base(message)
        {
        }

        public MissingSorterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
