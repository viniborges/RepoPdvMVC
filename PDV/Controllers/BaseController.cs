using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PDV.Filtros;

namespace PDV.Controllers
{
    //Decora o controller com o filtro que verifica a requisição de usuario logado
    //Em cada controller que for restrito, herdar de BaseController
    [AutorizacaoDeAcesso]

    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext) { base.OnActionExecuting(filterContext); }
	}
}