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
    public class InsumoProveedorRepository : IInsumoProveedor
    {
        private readonly ApiDbContext _context;

        public InsumoProveedorRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void Add(InsumoProveedor entity)
        {
            _context.Set<InsumoProveedor>().Add(entity);
        }

        public async Task<IEnumerable<InsumoProveedor>> GetAllAsync()
        {
            return await _context.Set<InsumoProveedor>().ToListAsync();
        }

        public void Remove(InsumoProveedor entity)
        {
            _context.Set<InsumoProveedor>().Remove(entity);
        }

        public void Update(InsumoProveedor entity)
        {
            _context.Set<InsumoProveedor>().Update(entity);
        }

        public async Task<(int totalRegisters, IEnumerable<InsumoProveedor> registers)> GetAllAsync(
            int pageIndex,
            int pageSize
        )
        {
            var totalRegisters = await _context.Set<InsumoProveedor>().CountAsync();
            var registers = await _context
                .Set<InsumoProveedor>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegisters, registers);
        }
    }
}