using Microsoft.AspNetCore.Builder;

namespace KeJian.Core.Library.Swagger
{
    public static class ApplicationBuilderSwaggerExtensions
    {
        public static IApplicationBuilder UseLibrarySwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}