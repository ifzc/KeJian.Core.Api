using KeJian.Core.Library.Filter;
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
        }
    }
}