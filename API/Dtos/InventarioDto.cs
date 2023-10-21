using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InventarioDto
    {
        public int Id { get; set; }
        public string CodigoInventario { get; set; }
        public int PrendaId { get; set; }
    }
}