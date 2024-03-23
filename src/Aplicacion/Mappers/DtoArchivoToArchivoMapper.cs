using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Mappers
{
    public class DtoArchivoToArchivoMapper: Profile
    {
        public DtoArchivoToArchivoMapper()
        {
            CreateMap<DtoArchivo, Archivo>();
            CreateMap<Archivo, DtoArchivo>();
        }

    }
}
