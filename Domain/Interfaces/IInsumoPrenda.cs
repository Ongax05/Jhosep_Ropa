using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInsumoPrenda
    {
        Task<IEnumerable<InsumoPrenda>> GetAllAsync();
        Task<(int totalRegisters, IEnumerable<InsumoPrenda> registers)> GetAllAsync (int pageIndex, int pageSize);
        void Add(InsumoPrenda entity);
        void Remove(InsumoPrenda entity);
        void Update(InsumoPrenda entity);
    }
}