using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Email { get; set; }
        public string CPFCNPJ { get; set; }
        //F = Fisica; J = Juridica
        public char Tipo { get; set; }
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}