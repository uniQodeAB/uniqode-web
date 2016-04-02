using System;

namespace UniQode.Common
{
    public class ErrorCodeException : Exception
    {
        public ErrorCodeException(ErrorCode errorCode) : base(ErrorCodeParser.GetMessage(errorCode))
        {
            ErrorCode = errorCode;
        }
        public ErrorCodeException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        public ErrorCodeException(ErrorCode errorCode, Exception innerException) : base(ErrorCodeParser.GetMessage(errorCode), innerException)
        {
            ErrorCode = errorCode;
        }
        public ErrorCodeException(ErrorCode errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        public ErrorCode ErrorCode { get; private set; }
    }
}