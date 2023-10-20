using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empresa : BaseEntity
    {
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string RepresentanteLegal { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}