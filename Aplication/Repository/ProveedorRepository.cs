using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
    {
        public ProveedorRepository(ApiDbContext context) : base(context)
        {
        }
    }
}