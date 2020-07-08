using KeJian.Core.Application.Interface;
using KeJian.Core.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace KeJian.Core.Application
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ILoginApplication, LoginApplication>();
            services.AddTransient<INewsApplication, NewsApplication>();
            services.AddTransient<IRecruitmentApplication, RecruitmentApplication>();
            services.AddTransient<IDataDictionaryApplication, DataDictionaryApplication>();

            services.AddTransient<IBaseApplication<User>, UserApplication>();
            services.AddTransient<IBaseApplication<Case>, CaseApplication>();
            services.AddTransient<IBaseApplication<Course>, CourseApplication>();
            services.AddTransient<IBaseApplication<Enterprise>, EnterpriseApplication>();
            services.AddTransient<IBaseApplication<Honor>, HonorApplication>();
            services.AddTransient<IBaseApplication<Message>, MessageApplication>();
            services.AddTransient<IBaseApplication<Study>, StudyApplication>();
            services.AddTransient<IBaseApplication<Team>, TeamApplication>();
        }
    }
}