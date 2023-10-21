using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Entities
{
    public class Municipio : BaseEntity
    {
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Proveedor> Proveedores { get; set; }
    }
}