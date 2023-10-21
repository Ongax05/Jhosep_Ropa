using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInsumo : IGenericRepository<Insumo>
    {
        Task<(int totalRegisters, IEnumerable<Insumo> registers)> GetInsumosByPrenda (int pageIndex, int pageSize, string PrendaCod);
    }
}