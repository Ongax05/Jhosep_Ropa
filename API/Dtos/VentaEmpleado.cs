using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VentaEmpleadoDto
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public EmpleadoDto Empleado { get; set; }
        public int ClienteId { get; set; }
        public int FormaPagoId { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<DetalleVentaDto> DetallesVentas { get; set; }
        public double TotalVenta { get; set; }
    }
}