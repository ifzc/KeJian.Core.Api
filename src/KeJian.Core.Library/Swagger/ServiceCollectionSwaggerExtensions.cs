using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace KeJian.Core.Library.Swagger
{
    public static class ServiceCollectionSwaggerExtensions
    {
        public static IServiceCollection AddLibrarySwagger(this IServiceCollection services)
        {
            // 配置SwaggerGen
            services.Configure<SwaggerGenOptions>(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT模式授权，🔑 请输入 Bearer [Token] 进行身份验证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.OperationFilter<AdditionOperationFilter>();

                var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
                if (assemblyName == null)
                    return;

                options.SwaggerDoc(assemblyName, new OpenApiInfo
                {
                    Version = "v1",
                    Title = assemblyName
                });
                options.CustomSchemaIds(t => t.FullName);

                // foreach (var xmlFile in Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "KeJian.*.xml"))
                foreach (var xmlFile in Directory.EnumerateFiles(AppContext.BaseDirectory, "KeJian.*.xml"))
                    options.IncludeXmlComments(xmlFile, true);
            });

            // 配置 SwaggerOptions
            services.Configure<SwaggerOptions>(options =>
            {
                options.RouteTemplate = "swagger/{documentName}/{Version}";
            });

            // 配置 SwaggerUIOptions
            services.Configure<SwaggerUIOptions>(options =>
            {
                options.EnableDeepLinking();
                options.DocExpansion(DocExpansion.None);
                options.DisplayRequestDuration();

                var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;

                if (assemblyName != null) options.SwaggerEndpoint($"{assemblyName}/v1", "V1");
            });

            services.AddSwaggerGen();

            return services;
        }
    }
}