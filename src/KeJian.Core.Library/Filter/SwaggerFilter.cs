using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using KeJian.Core.Domain.Dto.Base;

namespace KeJian.Core.Library.Filter
{
    public class SwaggerFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context != null)
            {
                //context.ApiDescription.TryGetMethodInfo(out var methodInfo);
                //var attribute = methodInfo.GetCustomAttributes<ExtraSwaggerParameter>().FirstOrDefault();
                //AddExtraParameters(operation, attribute?.ParameterNames);

                var actualReturnType = context.MethodInfo.ReturnType.Name == "Task`1"
                    ? context.MethodInfo.ReturnType.GenericTypeArguments.FirstOrDefault()
                    : context.MethodInfo.ReturnType;
                if (actualReturnType != null &&
                    !(actualReturnType.Name == "ApiResult`1" || actualReturnType.Name == "ApiResult"))
                {
                    var wrapApiResultReturnType = actualReturnType == typeof(void) || actualReturnType == typeof(Task)
                        ? typeof(ApiResult)
                        : typeof(ApiResult<>).MakeGenericType(actualReturnType);

                    operation?.Responses?.Remove("200");
                    operation?.Responses?.Add("200",
                        new OpenApiResponse
                        {
                            Description = "Success",
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                {
                                    "application/json", new OpenApiMediaType
                                    {
                                        Schema = context.SchemaGenerator.GenerateSchema(wrapApiResultReturnType, context.SchemaRepository)
                                    }
                                }
                            }
                        });
                }
            }
        }
    }
}
