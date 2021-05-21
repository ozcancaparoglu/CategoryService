using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace CategoryService.Container.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(Mapper)).As(typeof(IMapper)).AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("CategoryService.Application"))
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("CategoryService.Application"))
               .Where(t => t.Name.EndsWith("Configuration"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
