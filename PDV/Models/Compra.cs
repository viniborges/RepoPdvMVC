using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Compra
    {

        public int CompraId { get; set; }

        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public DateTime DataMovimento { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public double ValorTotalCompra { get; set; }

        public virtual IList<CompraItem> CompraItem { get; set; }
    }
}
