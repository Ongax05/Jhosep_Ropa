using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        public ClienteRepository(ApiDbContext context) : base(context)
        {
        }
    }
}