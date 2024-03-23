using Aplicacion.Commands;
using Aplicacion.Dtos;
using AutoMapper;
using Dominio.Models;
using Dominio.Repositories;
using Dominio.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aplicacion.CommandHandlers
{
    public class CargarArchivoRegistroHandler : AbstractHandler<CargarArchivo>
    {
        private readonly IArchivoRepository archivoRepository;
        private readonly IGuardarArchivoAlmacenamiento guardarArchivo;
        private readonly IUnitOfWork unitOfWork;

        public CargarArchivoRegistroHandler( IArchivoRepository archivoRepository, 
            IGuardarArchivoAlmacenamiento guardarArchivo, IUnitOfWork unitOfWork) {
           
            this.archivoRepository = archivoRepository;
            this.guardarArchivo = guardarArchivo;
            this.unitOfWork = unitOfWork;
        }

        public override IResponse Handle(CargarArchivo message)
        {
            Guid identificador = Guid.NewGuid();
            string rutaAlmacenamiento = guardarArchivo.GuardarArchivoRegistro(message.File, identificador.ToString());
            Archivo archivo = new Archivo
            {
                Nombre = message.File.FileName,
                ContentType = message.File.ContentType,
                Indentificador = identificador.ToString(),
                PathFisico = rutaAlmacenamiento,
                Activo = true,
                FechaRegistro = DateTime.Now,
              };
            var resultado =archivoRepository.Create(archivo);
            unitOfWork.Save();
            return new OkResponse(resultado.Id);
        }
    }

}
