using Infra.Resources;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers.Filters
{
    public class CheckAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session[Constants.USER_LOGIN_KEY] == null || !HttpContext.Current.Request.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    filterContext.Result = new RedirectResult(String.Format("{0}?ReturnUrl={1}",
                        System.Web.Security.FormsAuthentication.LoginUrl,
                        filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl))
                    );
                }
            }
        }
    }
}