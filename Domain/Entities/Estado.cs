using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Estado : BaseEntity
    {
        public string Descripcion { get; set; }
        public int TipoEstadoId { get; set; }
        public TipoEstado TipoEstado { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
        public ICollection<DetalleOrden> DetallesOrdenes { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
    }
}