using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        public InventarioRepository(ApiDbContext context) : base(context)
        {
        }
    }
}