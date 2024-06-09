using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Core.Utilities.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserInformationService, UserInformationManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<NotificationBusinessRules>();
            services.AddScoped<UserInformationBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

     }
}
