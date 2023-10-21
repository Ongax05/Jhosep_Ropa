using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteCTDto
    {
        public int Id { get; set; }
        public string CodigoCliente { get; set; }
        public int TipoPersonaId { get; set; }
        public int MunicipioId { get; set; }
        public MunicipioDto Municipio { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}