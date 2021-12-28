using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace StudentRegistration.WebPortal.Controllers.AuthorizeSession
{
    public class AuthorizeAction:Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var session = filterContext.HttpContext.Session.GetString("user");
            if (session == null)
            {
                RedirectToRouteResult rs = new RedirectToRouteResult(new RouteValueDictionary { {"Action","Login" },{"Controller","Home" } });
                filterContext.Result = rs;
            }
        }




    }
}
