using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Produto
    {
        public int ProdutoID {get; set; }
        public string Descricao {get; set; }
        public double PrecoCusto {get; set; }
        public int Qtde {get; set; }
        public double PrecoVenda {get; set; }
    }
}