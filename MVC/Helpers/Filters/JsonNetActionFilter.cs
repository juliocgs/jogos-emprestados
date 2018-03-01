using System;
using System.Web.Mvc;

namespace MVC.Helpers.Filters
{
    /// <summary>
    /// This filter makes possible to use JSON.NET as the default response JSON serializer
    /// </summary>
    public class JsonNetActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result.GetType() == typeof(JsonResult))
            {
                JsonResult result = filterContext.Result as JsonResult;

                if (result == null)
                    throw new ArgumentException("JsonNetActionFilter ERROR: Esperado um JSON");

                filterContext.Result = new JsonNetResult
                {
                    ContentEncoding = result.ContentEncoding,
                    ContentType = result.ContentType,
                    Data = result.Data,
                    JsonRequestBehavior = result.JsonRequestBehavior
                };
            }

            base.OnActionExecuted(filterContext);
        }
    }
}