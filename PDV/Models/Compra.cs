using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Compra
    {
        public int EntradaId {get; set; }
        public int FornecedorId {get; set; }
        public DateTime DataMovimento {get; set; }
        public int UsuarioId {get; set; }
        public double ValorTotalCompra {get; set; }
    }
}