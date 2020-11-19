using Autofac;
using System.Reflection;
//using AutoMapper.Configuration;
using SharePostApp.Core.Settings;
using SharePostApp.INFRASTRUCTURE.Services.Abstract;
using SharePostApp.INFRASTRUCTURE.Services.Concrete;
using Microsoft.Extensions.Configuration;

namespace SharePostApp.INFRASTRUCTURE.Modules
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServicesModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
