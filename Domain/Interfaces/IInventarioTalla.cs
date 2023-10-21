using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInventarioTalla
    {
        Task<IEnumerable<InventarioTalla>> GetAllAsync();
        Task<(int totalRegisters, IEnumerable<InventarioTalla> registers)> GetAllAsync (int pageIndex, int pageSize);
        void Add(InventarioTalla entity);
        void Remove(InventarioTalla entity);
        void Update(InventarioTalla entity);
    }
}