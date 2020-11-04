using SharePostApp.Core.Exceptions;
using System;

namespace SharePostApp.Core.Exceptions
{
    public class MainException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public MainException(ErrorCode errorCode)
            : this(errorCode, string.Empty)
        { }

        public MainException(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        { }

        public MainException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}