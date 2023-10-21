using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrden : IGenericRepository<Orden>
    {
        Task<(int totalRegisters, IEnumerable<Orden> registers)> GetOrdenesByEstadoProceso (int pageIndex, int pageSize);
        Task<(int totalRegisters, IEnumerable<Orden> registers)> GetOrdenesByCliente (int pageIndex, int pageSize, string CodigoCliente);
    }
}