using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class VendaItem
    {
         public int SaidaItemID {get; set; }
        public int SaidaID {get; set; }
        public int ProdutoID {get; set; }
        public double PrecoUnitarioVenda {get; set; }
        public int Qtde {get; set; }
        public double PrecoTotalItem {get; set; }
        public double ValorDesconto {get; set; }
    }
}