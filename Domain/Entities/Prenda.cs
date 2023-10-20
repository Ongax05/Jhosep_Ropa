using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Prenda : BaseEntity
    {
        public string CodigoPrenda { get; set; }
        public string Nombre { get; set; }
        public double ValorUnitarioCOP { get; set; }
        public double ValorUnitarioUSD { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public int TipoProteccionId { get; set; }
        public TipoProteccion TipoProteccion { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public ICollection<InsumoPrenda> InsumosPrendas { get; set; }
        public ICollection<Inventario> Inventarios { get; set; }
        public ICollection<DetalleOrden> DetallesOrdenes { get; set; }
    }
}