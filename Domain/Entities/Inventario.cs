using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventario : BaseEntity
    {
        public string CodigoInventario { get; set; }
        public int PrendaId { get; set; }
        public Prenda Prenda { get; set; }
        public ICollection<InventarioTalla> InventariosTallas { get; set; }
        public ICollection<DetalleVenta> DetallesVentas { get; set; }
    }
}