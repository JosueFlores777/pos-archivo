using Aplicacion.CommandHandlers;
using Aplicacion.Mappers;
using AutoMapper;
using Dominio.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DependencyInjection
{
    public static class MapperExtension
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddTransient(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoArchivoToArchivoMapper>();
            }).CreateMapper());
        }
    }

}
