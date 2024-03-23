using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Dominio.Models.Regla
{
    public interface IExtensionesPermitidas: IRegla
    {
        bool ExtensionValida(string filename);
    }

    public class ExtensionesPermitidas : IExtensionesPermitidas {

        private readonly IConfiguration configuration;
        public ExtensionesPermitidas(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool ExtensionValida(string filename)
        {
            var extension = Path.GetExtension(filename);
            
            string[] extensiones = configuration.GetSection("AppSettings:ExtensionesValidas").Get<string[]>();
            foreach (string permitido in extensiones)
            {
                if (permitido.ToUpper().Equals(extension.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
