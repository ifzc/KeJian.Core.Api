using System;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using KeJian.Core.Domain.Dto.Base;
using KeJian.Core.Library.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace KeJian.Core.Library.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private static readonly JsonSerializerOptions JsonSerializerSettings = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        private readonly ILogger<ExceptionFilter> _logger;

        /// <summary>
        /// 异常处理过滤器
        /// </summary>
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            System.Exception ex;
            if (context.Exception is AggregateException)
            {
                ex = ((AggregateException)context.Exception).InnerExceptions.First();
            }
            else
            {
                ex = context.Exception;
            }

            if (ex is ResponseExceptionBase rEx)
            {
                ProcessBusinessException(rEx, context);
            }
        }

        /// <summary>
        /// 业务异常的处理
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="context"></param>
        private void ProcessBusinessException(ResponseExceptionBase ex, ExceptionContext context)
        {
            const HttpStatusCode statusCode = (HttpStatusCode)288;

            string exMessage;
            int errorCode;

            if (ex is StringResponseException)
            {
                errorCode = ex.ErrorCode == 0 ? int.MaxValue : ex.ErrorCode;
                exMessage = ex.Message;
            }
            else
            {
                errorCode = ex.ErrorCode;
                //var message = _enumDescriptionService.GetDescriptionValue(ex.ErrorCode);
                exMessage = string.Empty;
            }

            context.HttpContext.Response.StatusCode = (int)statusCode;
            _logger.LogInformation(errorCode, "发生业务异常 {0} {1}", errorCode.ToString(), exMessage);
            context.Result = new JsonResult(new ApiResult(errorCode, exMessage), JsonSerializerSettings);
        }
    }
}
