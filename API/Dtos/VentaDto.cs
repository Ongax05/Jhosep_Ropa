using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VentaDto
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public int FormaPagoId { get; set; }
        public DateTime Fecha { get; set; }
    }
}