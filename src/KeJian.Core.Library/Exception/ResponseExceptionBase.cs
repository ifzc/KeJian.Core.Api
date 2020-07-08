namespace KeJian.Core.Library.Exception
{
    public abstract class ResponseExceptionBase : System.Exception
    {
        public int ErrorCode { get; protected set; }
    }
}