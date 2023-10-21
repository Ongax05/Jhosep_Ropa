using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace Aplication.Repository
{
    public class VentaRepository : GenericRepository<Venta>, IVenta
    {
        private readonly ApiDbContext _context;

        public VentaRepository(ApiDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<(
            int totalRegisters,
            IEnumerable<Venta> registers,
            List<double> TotalVenta
        )> GetVentasByEmpleado(int pageIndex, int pageSize, string CodigoEmpleado)
        {
            var Ventas = await _context.Ventas
                .Where(v => v.Empleado.CodigoEmpleado == CodigoEmpleado)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Include(v => v.Empleado)
                .Include(v => v.DetallesVentas)
                .ToListAsync();
            var total = Ventas.Count;
            List<double> TotalesVentas = Ventas
                .Select(o => o.DetallesVentas.Sum(dv => dv.Cantidad * dv.ValorUnitario))
                .ToList();

            return (total, Ventas, TotalesVentas);
        }
    }
}
