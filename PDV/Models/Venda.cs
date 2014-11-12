using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Venda
    {
         public int SaidaId {get; set; }
        public int ClienteID {get; set; }
        public DateTime DataMovimento {get; set; }
        public int VendedorId {get; set; }
        public double ValorTotalVenda {get; set; }
    }
}