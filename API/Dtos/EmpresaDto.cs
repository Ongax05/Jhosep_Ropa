using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpresaDto
    {
        public int Id { get; set; }
        public int MunicipioId { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string RepresentanteLegal { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}