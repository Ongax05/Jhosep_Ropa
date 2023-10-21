using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVenta : IGenericRepository<Venta>
    {
        Task<(int totalRegisters, IEnumerable<Venta> registers, List<double> TotalVenta)> GetVentasByEmpleado (int pageIndex, int pageSize, string CodigoEmpleado);
    }
}