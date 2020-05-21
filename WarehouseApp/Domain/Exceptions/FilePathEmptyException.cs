using System;

namespace WarehouseApp.Domain.Exceptions
{
    public class FilePathEmptyException : Exception
    {
        public FilePathEmptyException(string message) : base(message)
        {
        }

        public FilePathEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FilePathEmptyException()
        {
        }
    }
}
