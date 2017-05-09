using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSuporte.Security
{
    public class PermissoesFiltro : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //Caso o usuario não seja autorizado ele será enviado a página de erro
            if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.HttpContext.Response.Redirect("/Default/Negado");

        }
    }
}