using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InsumoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double ValorUnitario { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
    }
}