namespace KeJian.Core.Domain.Dto.Base
{
    public class ApiResult<TResult> : ApiResult
    {
        protected ApiResult()
        {
        }

        public ApiResult(int errorCode, string message, TResult result)
            : base(errorCode, message)
        {
            this.Result = result;
        }

        public TResult Result { get; set; }

        public virtual void SetSuccess(TResult data)
        {
            this.IsSuccess = true;
            this.Result = data;
        }

        public virtual ApiResult<TResult> SetApiResult(TResult data)
        {
            this.Result = data;
            return this;
        }
    }

    public class ApiResult
    {
        protected ApiResult()
        {
        }

        public ApiResult(int errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }

        public bool IsSuccess { get; set; }

        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public string OperationId { get; set; }

        public virtual void SetSuccess()
        {
            this.IsSuccess = true;
        }

        public virtual void SetFailed(int errorCode)
        {
            this.IsSuccess = false;
            this.ErrorCode = errorCode;
        }

        public virtual void SetFailed(string msg)
        {
            this.IsSuccess = false;
            this.ErrorCode = -1;
            this.Message = msg;
        }

        public virtual void SetFailed(int errorCode, string msg)
        {
            this.IsSuccess = false;
            this.ErrorCode = errorCode;
            this.Message = msg;
        }

        public override string ToString()
        {
            return string.Format("{0},ErrorCode:{1},Message:{2}", (object) this.IsSuccess, (object) this.ErrorCode, (object) this.Message);
        }
    }
}
