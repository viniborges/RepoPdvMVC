using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PDV.DAL;

namespace PDV.Filtros
{
    //Decora a classe com oum gerenciador de erros automatizado
    [HandleError]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple =  true)]
    public class AutorizacaoDeAcesso : ActionFilterAttribute
    {
        //Sobrescreve o método “OnActionExecuting” e personaliza o comportamento da requisição que chega ao controller
        public override void OnActionExecuting(ActionExecutingContext FiltroDeContexto)
        {
            var Controller = FiltroDeContexto.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = FiltroDeContexto.ActionDescriptor.ActionName;

            if (Controller != "Home" || Action != "Login")
            {
                if (RepositorioUsuarios.VerificaSeUsuarioEstaLogado() == null)
                {
                    FiltroDeContexto.RequestContext.HttpContext.Response.Redirect("/Home/Login?Url=" +
                                                                                  FiltroDeContexto.HttpContext.Request
                                                                                      .Url.LocalPath);
                }
            }
        }
    }
}