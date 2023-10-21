using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DetalleOrdenDto
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int PrendaId { get; set; }
        public int EstadoId{ get; set; }
        public int ColorId { get; set; }
        public int CantidadProducida { get; set; }
    }
}