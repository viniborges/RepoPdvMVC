using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class CompraItem
    {
        public int CompraItemId { get; set; }
        public int ProdutoID { get; set; }
        public virtual Produto Produto { get; set; }
        public double PrecoUnitarioCompra { get; set; }
        public int Qtde { get; set; }
        public double PrecoTotalItem { get; set; }

        public int CompraId { get; set; }
        public virtual Compra Compra { get; set; }
    }
}