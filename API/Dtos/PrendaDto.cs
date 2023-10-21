using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PrendaDto
    {
        public int Id { get; set; }
        public string CodigoPrenda { get; set; }
        public string Nombre { get; set; }
        public double ValorUnitarioCOP { get; set; }
        public double ValorUnitarioUSD { get; set; }
        public int EstadoId { get; set; }
        public int TipoProteccionId { get; set; }
        public int GeneroId { get; set; }
    }
}