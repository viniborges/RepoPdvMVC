using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Cliente : Pessoa
    {
        public int ClienteId { get; set; }
        public string Contato { get; set; }
        //Ultima vez que o cliente comprou
        public DateTime UltimaVenda { get; set; }

    }
}