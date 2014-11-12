using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class VendaItem
    {
        public int VendaItemId { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public double PrecoUnitarioVenda { get; set; }
        public int Qtde { get; set; }
        public double PrecoTotalItem { get; set; }
        public double ValorDesconto { get; set; }

        public int VendaId { get; set; }
        public virtual Venda Venda { get; set; }
    }
}