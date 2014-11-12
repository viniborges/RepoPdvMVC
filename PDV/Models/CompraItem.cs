using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class CompraItem
    {
        public int EntradaItemID {get; set; }
        public int ProdutoID {get; set; }
        public double PrecoUnitarioCompra { get; set; }
        public int Qtde {get; set; }
        public double PrecoTotalItem {get; set; }
    }
}