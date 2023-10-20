using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InsumoProveedor
    {
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }
    }
}