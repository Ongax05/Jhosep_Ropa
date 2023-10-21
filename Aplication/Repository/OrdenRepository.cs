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

        public OrdenRepository(ApiDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<(int totalRegisters, IEnumerable<Orden> registers)> GetOrdenesByCliente(
            int pageIndex,
            int pageSize,
            string CodigoCliente
        )
        {
            var registers = await _context.Ordenes
                .Where(o => o.Cliente.CodigoCliente == CodigoCliente)
                .Skip((pageIndex -1) * pageSize).Take(pageSize)
                .Include(o => o.Cliente)
                .ThenInclude(o => o.Municipio)
                .Include(o => o.Estado)
                .ThenInclude(e => e.TipoEstado)
                .Include(o => o.DetallesOrdenes)
                .ThenInclude(d => d.Prenda)
                .ToListAsync();
            var total = registers.Count;
            return (total,registers);

        }

        public async Task<(
            int totalRegisters,
            IEnumerable<Orden> registers
        )> GetOrdenesByEstadoProceso(int pageIndex, int pageSize)
        {
            var ordenes = await _context.Ordenes
                .Where(o => o.Estado.Descripcion.ToLower() == "Proceso".ToLower())
                .Skip((pageIndex -1) * pageSize).Take(pageSize)
                .ToListAsync();
            var totalRegisters = ordenes.Count;
            return (totalRegisters, ordenes);
        }
    }
}
