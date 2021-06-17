using System;

namespace Aspose.Cells.Translation.Api
{
    public class ApiException : Exception
    {
        public int ErrorCode { get; set; }

        public ApiException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}