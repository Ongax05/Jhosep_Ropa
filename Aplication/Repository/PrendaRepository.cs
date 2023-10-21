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
    public class PrendaRepository : GenericRepository<Prenda>, IPrenda
    {
        private readonly ApiDbContext _context;
        public PrendaRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Prenda> GetPrendaByCod(string cod)
        {
            var Prenda = await _context.Prendas.FirstOrDefaultAsync(p => p.CodigoPrenda == cod);
            return Prenda;
        }
    }
}