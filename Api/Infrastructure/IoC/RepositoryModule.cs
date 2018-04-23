using Autofac;
using Repository;
using Repository.Repo;

namespace Api.Infrastructure.IoC
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RepDbContext>()
                   .As<IRepDbContext>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<TeacherRepo>()
                   .As<ITeacherRepo>()
                   .InstancePerLifetimeScope();
            
            builder.RegisterType<UserRepo>()
                   .As<IUserRepo>()
                   .InstancePerLifetimeScope();
            
            builder.RegisterType<SchoolRepo>()
                   .As<ISchoolRepo>()
                   .InstancePerLifetimeScope();
           
        }
    }
}