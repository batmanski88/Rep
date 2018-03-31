using Api.Infrastructure.Mappers;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace Api.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public IContainer ApplicationContainer {get; private set;}

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.RegisterModule<RepositoryModule>();
        }
    }
}