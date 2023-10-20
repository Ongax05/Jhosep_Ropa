using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string CodigoCliente { get; set; }
        public int TipoPersonaId { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public ICollection<Venta> Ventas { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
    }
}