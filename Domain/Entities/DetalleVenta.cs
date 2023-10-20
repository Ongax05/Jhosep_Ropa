using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleVenta : BaseEntity
    {
        public int VentaId { get; set; }
        public Venta Venta { get; set; }
        public int InventarioId { get; set; }
        public Inventario Inventario { get; set; }
        public int TallaId { get; set; }
        public Talla Talla { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnitario { get; set; }
    }
}