using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class VentaRepository : GenericRepository<Venta>, IVenta
    {
        public VentaRepository(ApiDbContext context) : base(context)
        {
        }
    }
}