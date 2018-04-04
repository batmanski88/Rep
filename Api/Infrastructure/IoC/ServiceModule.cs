using Api.Services;
using Autofac;

namespace Api.Infrastructure.IoC
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<TeacherService>()
                   .As<ITeacherService>()
                   .InstancePerLifetimeScope();
        }
    }
}