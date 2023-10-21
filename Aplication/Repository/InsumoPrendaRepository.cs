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
    public class InsumoPrendaRepository : IInsumoPrenda
    {
        private readonly ApiDbContext _context;

        public InsumoPrendaRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void Add(InsumoPrenda entity)
        {
            _context.Set<InsumoPrenda>().Add(entity);
        }

        public async Task<IEnumerable<InsumoPrenda>> GetAllAsync()
        {
            return await _context.Set<InsumoPrenda>().ToListAsync();
        }

        public void Remove(InsumoPrenda entity)
        {
            _context.Set<InsumoPrenda>().Remove(entity);
        }

        public void Update(InsumoPrenda entity)
        {
            _context.Set<InsumoPrenda>().Update(entity);
        }

        public async Task<(int totalRegisters, IEnumerable<InsumoPrenda> registers)> GetAllAsync(
            int pageIndex,
            int pageSize
        )
        {
            var totalRegisters = await _context.Set<InsumoPrenda>().CountAsync();
            var registers = await _context
                .Set<InsumoPrenda>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegisters, registers);
        }
    }
}
