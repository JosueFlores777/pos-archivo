using Aplicacion.Commands;
using Aplicacion.Services.Validaciones;
using Dominio.Models.Regla;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aplicacion.Validators
{
    public class CargarArchivoRegistroValidator : Validador<CargarArchivo>
    {
        public CargarArchivoRegistroValidator(IAutenticationHelper autenticationHelper, IExtensionesPermitidas extensiones) : base(autenticationHelper) {
            RuleFor(x => x.File).NotNull().Must(c => extensiones.ExtensionValida(c.FileName)).WithMessage("Archivo No permistido, Solamente, PDF e imagenes");
            RuleFor(c => c.File.Length).LessThan(5242880).WithMessage("Error. archivo supera el limite de tamanio de 5 MB");  
        }

        public override IList<string> Permisos => new List<string>();
    }
}
