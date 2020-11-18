using Autofac;
using SharePostApp.INFRASTRUCTURE.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
