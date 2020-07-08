// ReSharper disable MemberCanBePrivate.Global
namespace KeJian.Core.Library.Exception
{
    public class StringResponseException : ResponseExceptionBase
    {
        public StringResponseException(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            Message = errorMessage;
        }

        public StringResponseException(string errorMessage)
            : this(0, errorMessage)
        {
        }

        public override string Message { get; }
    }
}