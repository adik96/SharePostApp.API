using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SharePostApp.Core.Exceptions
{
    public class ErrorCode
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorCode(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public static ErrorCode DomainValidationError => new ErrorCode(nameof(DomainValidationError), HttpStatusCode.UnprocessableEntity);
        public static ErrorCode NotFound => new ErrorCode(nameof(NotFound), HttpStatusCode.NotFound);
        public static ErrorCode InvalidPassword => new ErrorCode(nameof(InvalidPassword), HttpStatusCode.NotFound);
        public static ErrorCode NullException => new ErrorCode(nameof(NullException), HttpStatusCode.Conflict);
    }
}