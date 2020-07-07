using System;
using System.Collections.Generic;
using System.Text;

namespace KeJian.Core.Library.Exception
{
    public class StringResponseException : ResponseExceptionBase
    {
        public override string Message { get; }

        public StringResponseException(int errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.Message = errorMessage;
        }

        public StringResponseException(string errorMessage)
            : this(0, errorMessage)
        {
        }
    }
}
