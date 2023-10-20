using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class InsumoRepository : GenericRepository<Insumo>, IInsumo
    {
        public InsumoRepository(ApiDbContext context) : base(context)
        {
        }
    }
}