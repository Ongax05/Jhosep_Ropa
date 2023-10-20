using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class TipoEstadoRepository : GenericRepository<TipoEstado>, ITipoEstado
    {
        public TipoEstadoRepository(ApiDbContext context) : base(context)
        {
        }
    }
}