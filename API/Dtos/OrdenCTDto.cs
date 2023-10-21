using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrdenCTDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public ClienteCTDto Cliente { get; set; }
        public int EstadoId { get; set; }
        public EstadoCTDto Estado { get; set; }
        public ICollection<DetalleOrdenPrendaDto> DetallesOrdenes { get; set; }
    }
}