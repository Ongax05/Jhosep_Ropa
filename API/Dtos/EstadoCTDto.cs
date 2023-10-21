using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EstadoCTDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int TipoEstadoId { get; set; }
        public TipoEstadoDto TipoEstado { get; set; }
    }
}