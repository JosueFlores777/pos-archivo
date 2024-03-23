using Dominio.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Commands
{
    public class CargarArchivo: IMessage
    {
        public IFormFile File { get; set; }
    }
}
