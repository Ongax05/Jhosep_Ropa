using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DetalleVentaDto
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int InventarioId { get; set; }
        public int TallaId { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnitario { get; set; }
    }
}