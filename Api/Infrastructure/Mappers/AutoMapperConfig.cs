using Api.ViewModels;
using AutoMapper;
using Repository.Models;

namespace Api.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Teacher, TeacherViewModel>();
            })
            .CreateMapper();
    }
}