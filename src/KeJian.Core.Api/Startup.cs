using System.Text;
using KeJian.Core.Application;
using KeJian.Core.Domain.Configs;
using KeJian.Core.EntityFramework;
using KeJian.Core.Library;
using KeJian.Core.Library.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace KeJian.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<DefaultDbContext>(
                options => { options.UseMySql(Configuration.GetConnectionString("DefaultConnection")); }, 20);

            services.AddOptions();
            services.Configure<JwtSecurityOption>(Configuration.GetSection("JwtSecurityOption"));

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.Unicode.GetBytes(Configuration.GetSection("JwtSecurityOption:SigningKey").Value)),
                    ValidIssuer = Configuration.GetSection("JwtSecurityOption:Issuer").Value,
                    ValidAudience = Configuration.GetSection("JwtSecurityOption:Audience").Value
                };
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            services.AddApplication();
            services.AddLibrary();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseLibrarySwagger();
        }
    }
}