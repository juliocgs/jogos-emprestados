using Application.Models;
using Infra.Resources;
using MVC.Helpers.Filters;
using MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class BaseAuthController : Controller
    {
        protected UserViewModel LoggedInUser
        {
            get
            {
                return Session[Constants.USER_LOGIN_KEY] as UserViewModel;
            }

            set { }
        }

        public JsonResult CreateDataTableResponse<T>(List<T> list, DataTableRequest request) where T : class
        {
            return Json(new DataTableResponse<T>()
            {
                draw = request.draw,
                data = list,
                recordsFiltered = list.Count,
                recordsTotal = list.Count
            });
        }
    }
}