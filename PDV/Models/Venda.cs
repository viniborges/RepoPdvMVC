using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Venda
    {
        //public Venda()
        //{
        //    VendaItens = new List<VendaItem>();
        //}
        public int VendaId { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataMovimento { get; set; }
        public int VendedorId { get; set; }
        public double ValorTotalVenda { get; set; }
        public virtual IList<VendaItem> VendaItem { get; set; }
    }
}