using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using PDV.Models;

namespace PDV.DAL
{
    public class RepositorioUsuarios
    {
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
            try
            {
                using (var data = new Contexto())
                {
                    var cons = data.Usuarios.SingleOrDefault(x => x.Email == Login && x.Senha == SenhaCriptografada);
                    if (cons == null)
                    {
                        return false;
                    }
                    else
                    {
                        RepositorioCookies.RegistraCookieAutenticacao(cons.Id);
                        return true;
                    }
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        //Metódos de apoio para verificar se o usuário já se encontra autenticado no sistema e, com base nesta resposta, decidir se rejeita ou permite o acesso
        public static Usuario RecuperaUsuarioPorId(long IDUser)
        {
            try
            {
                using (var data = new Contexto())
                {
                    var usuario = data.Usuarios.SingleOrDefault(u => u.Id == IDUser);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //verifica seousuário já se encontra autenticado no sistema
        public static Usuario VerificaSeUsuarioEstaLogado()
        {
            var user = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            if (user == null)
            {
                return null;
            }
            else
            {
                long IdUser = Convert.ToInt64(RepositorioCriptografia.Descriptografar((user.Values["IDUsuario"])));
                var UsuarioRetornado = RecuperaUsuarioPorId(IdUser);
                return UsuarioRetornado;
            }
        }


    }
}