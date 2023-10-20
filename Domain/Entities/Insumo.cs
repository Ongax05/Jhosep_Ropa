using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Insumo : BaseEntity
    {
        public string Nombre { get; set; }
        public double ValorUnitario { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public ICollection<InsumoPrenda> InsumosPrendas { get; set; }
        public ICollection<InsumoProveedor> InsumosProveedores { get; set; }
    }
}