using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProveedorDto
    {
        public int Id { get; set; }
        public string NitProveedor { get; set; }
        public string Nombre { get; set; }
        public int TipoPersonaId { get; set; }
        public int MunicipioId { get; set; }
    }
}