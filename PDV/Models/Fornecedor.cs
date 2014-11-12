using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Fornecedor : Pessoa
    {
        public int FornecedorId { get; set; }
        public string InscricaoEstadual { get; set; }
        //Ultima vez que foi comprado do fornecedor
        public DateTime UltimaCompra { get; set; }
    }
}