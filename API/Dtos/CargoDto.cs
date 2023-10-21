using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CargoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double SueldoBase { get; set; }
    }
}