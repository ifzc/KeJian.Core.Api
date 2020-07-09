namespace KeJian.Core.Domain.Dto.Base
{
    public sealed class ApiResult<TResult> : ApiResult
    {
        public ApiResult(int errorCode, string message, TResult result)
            : base(errorCode, message)
        {
            Result = result;
        }

        public TResult Result { get; set; }

        public void SetSuccess(TResult data)
        {
            IsSuccess = true;
            Result = data;
        }

        public ApiResult<TResult> SetApiResult(TResult data)
        {
            Result = data;
            return this;
        }
    }

    public class ApiResult
    {
        public ApiResult(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public bool IsSuccess { get; set; }

        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public string OperationId { get; set; }

        public void SetSuccess()
        {
            IsSuccess = true;
        }

        public void SetFailed(int errorCode)
        {
            IsSuccess = false;
            ErrorCode = errorCode;
        }

        public void SetFailed(string msg)
        {
            IsSuccess = false;
            ErrorCode = -1;
            Message = msg;
        }

        public void SetFailed(int errorCode, string msg)
        {
            IsSuccess = false;
            ErrorCode = errorCode;
            Message = msg;
        }

        public override string ToString()
        {
            return $"{IsSuccess},ErrorCode:{ErrorCode},Message:{Message}";
        }
    }
}