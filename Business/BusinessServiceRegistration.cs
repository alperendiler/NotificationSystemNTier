using Business.Abstracts;
using Business.Concretes;
using Business.Dtos.Notification.Responses;
using Business.Rules;
using Core.CrossCuttingConcerns.SingalR;
using Core.Utilities.Security.Jwt;
using Entities.Concretes;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
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
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<ITokenHelper<Guid, int>, JwtHelper<Guid, int>>();
            services.AddSignalR();

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<NotificationBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<TokenOptions>(provider =>
            {
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
                return configuration.GetSection("TokenOptions").Get<TokenOptions>();
            });
            return services;
        }

     }
}
