using KeJian.Core.Library.Filter;
using KeJian.Core.Library.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Library
{
    public static class LibraryExtensions
    {
        public static void AddLibrary(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ResultFilter>();
                options.Filters.Add<ExceptionFilter>();
            });

            services.AddLibrarySwagger();
        }
    }
}