using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmpleado : IGenericRepository<Empleado>
    {
        Task<(int totalRegisters, IEnumerable<Empleado> registers)> GetEmpleadosByCargo (int pageIndex, int pageSize, string Cargo);
    }
}