using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Domain.Entities
{
    public class Departamento : BaseEntity
    {
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public string Nombre { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
    }
}