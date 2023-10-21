using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistency;

namespace Aplication.Repository
{
    public class InsumoRepository : GenericRepository<Insumo>, IInsumo
    {
        private readonly ApiDbContext _context;
        public InsumoRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(int totalRegisters, IEnumerable<Insumo> registers)> GetInsumosByPrenda(int pageIndex, int pageSize, string PrendaCod)
        {
            var Prenda = await _context.Prendas.FirstOrDefaultAsync(p => p.CodigoPrenda == PrendaCod) ?? new Prenda {};
            var PrendasInsumos = await _context.InsumosPrendas.Where(p => p.PrendaId == Prenda.Id).ToListAsync();
            var InsumosIds = PrendasInsumos.Select(p=>p.InsumoId);
            var Insumos = await _context.Insumos.Where(p => InsumosIds.Contains(p.Id)).Skip((pageIndex -1) * pageSize).Take(pageSize).ToListAsync();
            var totalRegisters = Insumos.Count;
            return (totalRegisters, Insumos);
        }

        public async Task<(int totalRegisters, IEnumerable<Insumo> registers)> GetInsumosByProveedorJuridico(int pageIndex, int pageSize, string ProveedorNit)
        {
            var Proveedor = await _context.Proveedores.FirstOrDefaultAsync(p => p.NitProveedor == ProveedorNit && p.TipoPersona.Descripcion == "Juridica") ?? new Proveedor {};
            var ProveedoresInsumos = await _context.InsumosProveedores.Where(p => p.ProveedorId == Proveedor.Id).ToListAsync();
            var InsumosIds = ProveedoresInsumos.Select(p=>p.InsumoId);
            var Insumos = await _context.Insumos.Where(p => InsumosIds.Contains(p.Id)).Skip((pageIndex -1) * pageSize).Take(pageSize).ToListAsync();
            var totalRegisters = Insumos.Count;
            return (totalRegisters, Insumos);
        }
    }
}