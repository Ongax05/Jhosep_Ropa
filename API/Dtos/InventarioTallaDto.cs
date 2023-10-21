using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InventarioTallaDto
    {
        public int InventarioId { get; set; }
        public InventarioDto Inventario { get; set; }
        public int TallaId { get; set; }
        public TallaDto Talla { get; set; }
        public int Cantidad { get; set; }
    }
}