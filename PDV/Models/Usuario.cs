using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDV.Models
{
    public class Usuario
    {
        
        //Executar no banco na primeira vez que rodar o sistema:
        //Insert Into Usuario (Email, Senha, UltimoLogin) Values ('admin@admin.com', '40BD001563085FC35165329EA1FF5C5ECBDBBEEF', GETDATE())
        //OBS: senha criptografada = 123
        //Após logar com esse user, cadastrar um novo direto pelo sistema e deletar o admin@admin.com
        //Dev L. Vinicius
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string UltimoLogin { get; set; }
        public string Nome { get; set; }
        public bool Admin { get; set; }
    }
}