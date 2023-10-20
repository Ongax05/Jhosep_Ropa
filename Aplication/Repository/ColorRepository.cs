using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class ColorRepository : GenericRepository<Color>, IColor
    {
        public ColorRepository(ApiDbContext context) : base(context)
        {
        }
    }
}