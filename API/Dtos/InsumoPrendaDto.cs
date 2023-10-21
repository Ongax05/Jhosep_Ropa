using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InsumoPrendaDto
    {
        public int InsumoId { get; set; }
        public int PrendaId { get; set; }
        public int Cantidad { get; set; }
    }
}