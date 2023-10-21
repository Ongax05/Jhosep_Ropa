using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace Aplication.Repository
{
    public class OrdenRepository : GenericRepository<Orden>, IOrden
    {
        private readonly ApiDbContext _context;
        public OrdenRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(int totalRegisters, IEnumerable<Orden> registers)> GetOrdenesByEstadoProceso(int pageIndex, int pageSize)
        {
            var ordenes = await _context.Ordenes.Where(o => o.Estado.Descripcion.ToLower() == "Proceso".ToLower()).ToListAsync();
            var totalRegisters = ordenes.Count;
            return (totalRegisters, ordenes);
        }
    }
}