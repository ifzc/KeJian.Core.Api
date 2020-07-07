using System;
using System.Collections.Generic;
using System.Text;

namespace KeJian.Core.Library.Exception
{
    public abstract class ResponseExceptionBase : System.Exception
    {
        public int ErrorCode { get; protected set; }

        public ResponseExceptionBase()
        {
        }

        public ResponseExceptionBase(int errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
