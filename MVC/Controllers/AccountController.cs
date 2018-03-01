using Application.Models;
using FluentValidation.Mvc;
using Infra.Resources;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.ValidateLogin(user);

                if (result.IsValid)
                {

                    FormsAuthentication.SignOut();
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    user.Password = null;
                    Session[Constants.USER_LOGIN_KEY] = user;

                    return RedirectToAction("Index", "Home");
                }

                result.AddToModelState(ModelState, null);
                return View();
            }

            return View();
        }

        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();

                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        private void EnsureLogout()
        {
            if (Request.IsAuthenticated)
                Logout();
        }

    }
}