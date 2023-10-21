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
    public class InventarioTallaRepository : IInventarioTalla
    {
        private readonly ApiDbContext _context;

        public InventarioTallaRepository(ApiDbContext context) 
        {
            _context = context;
        }

        public void Add(InventarioTalla entity)
        {
            _context.Set<InventarioTalla>().Add(entity);
        }

        public async Task<IEnumerable<InventarioTalla>> GetAllAsync()
        {
            return await _context.Set<InventarioTalla>().ToListAsync();
        }

        public void Remove(InventarioTalla entity)
        {
            _context.Set<InventarioTalla>().Remove(entity);
        }

        public void Update(InventarioTalla entity)
        {
            _context.Set<InventarioTalla>().Update(entity);
        }
        public async Task<(int totalRegisters, IEnumerable<InventarioTalla> registers)> GetAllAsync(
            int pageIndex,
            int pageSize
        )
        {
            var totalRegisters = await _context.Set<InventarioTalla>().CountAsync();
            var registers = await _context
                .Set<InventarioTalla>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Include(s=>s.Talla)
                .Include(s=>s.Inventario)
                .ToListAsync();
            return (totalRegisters, registers);
        }
    }
}