using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Dtos.Notification.Responses;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.SingalR;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.SignalR;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
