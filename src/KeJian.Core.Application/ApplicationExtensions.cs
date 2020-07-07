using System;
using System.Collections.Generic;
using System.Text;
using KeJian.Core.Application.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Application
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ILoginApplication, LoginApplication>();
            services.AddTransient<IUserApplication, UserApplication>();
        }
    }
}
