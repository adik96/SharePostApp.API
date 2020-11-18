using Autofac;
using System.Reflection;
using SharePostApp.DB.Repositories.Abstract;
using SharePostApp.DB.Repositories.Concrete;

namespace SharePostApp.DB.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IBaseRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}
