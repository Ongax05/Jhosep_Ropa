using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPrenda : IGenericRepository<Prenda>
    {
        Task<Prenda> GetPrendaByCod (string cod);
    }
}