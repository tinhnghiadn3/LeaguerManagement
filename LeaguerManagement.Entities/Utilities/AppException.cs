using System;

namespace LeaguerManagement.Entities.Utilities
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, Exception ex) : base(message, ex) { }
    }
}
