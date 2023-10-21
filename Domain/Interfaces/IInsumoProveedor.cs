using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInsumoProveedor
    {
        Task<IEnumerable<InsumoProveedor>> GetAllAsync();
        Task<(int totalRegisters, IEnumerable<InsumoProveedor> registers)> GetAllAsync (int pageIndex, int pageSize);
        void Add(InsumoProveedor entity);
        void Remove(InsumoProveedor entity);
        void Update(InsumoProveedor entity);
    }
}