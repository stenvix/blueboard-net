using System;

namespace BlueBoard.Common.Exceptions
{
    public class BlueBoardException : Exception
    {
        public BlueBoardException(ResponseCode code)
        {
            this.Code = code;
        }

        public BlueBoardException(ResponseCode code, string message)
            : base(message)
        {
            this.Code = code;
        }

        public BlueBoardException(ResponseCode code, Exception innerException)
            : base(string.Empty, innerException)
        {
            this.Code = code;
        }

        public BlueBoardException(ResponseCode code, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Code = code;
        }

        public ResponseCode Code { get; set; }
    }
}
