﻿using Dominio.Models;
using Dominio.Repositories;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositories
{
    public class ArchivoRepository: GenericRepository<Archivo>, IArchivoRepository
    {
        private readonly AutenticationContext dbContext;

        public ArchivoRepository(AutenticationContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
