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
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly ApiDbContext _context;
        public EmpleadoRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(int totalRegisters, IEnumerable<Empleado> registers)> GetEmpleadosByCargo(int pageIndex, int pageSize, string Cargo)
        {
            var Empleados = await _context.Empleados.Where(x => x.Cargo.Descripcion.ToLower() == Cargo.ToLower()).ToListAsync();
            var Total = Empleados.Count;
            return (Total, Empleados);
        }
    }
}