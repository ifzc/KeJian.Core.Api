using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace KeJian.Core.Library.Swagger
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionAttrs = context.MethodInfo.GetCustomAttributes(true);
            var controllerAttrs = context.MethodInfo.DeclaringType.GetCustomAttributes(true);

            if (actionAttrs.OfType<AllowAnonymousAttribute>().Any() || controllerAttrs.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            var methodAuthorizeAttrs = actionAttrs.OfType<AuthorizeAttribute>();
            var controllerAuthorizeAttrs = controllerAttrs.OfType<AuthorizeAttribute>();

            if (!methodAuthorizeAttrs.Any() && !controllerAuthorizeAttrs.Any())
            {
                return;
            }

            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

            operation.Security.Add(new OpenApiSecurityRequirement
            {
                { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new List<string>() }
            });
        }
    }
}
