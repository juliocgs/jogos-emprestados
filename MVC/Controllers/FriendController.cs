using Application.Models;
using FluentValidation.Mvc;
using MVC.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class FriendController : BaseAuthController
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        #region ACTION
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(FriendViewModel friend)
        {
            if (ModelState.IsValid)
            {
                var result = _friendService.Create(friend);

                if (result.IsValid)
                {
                    TempData["success"] = "Amigo cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                result.AddToModelState(ModelState, null);
                return View();
            }

            return View();
        }

        public ActionResult Edit(Guid id)
        {
            return View(_friendService.GetById(id));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(FriendViewModel friend)
        {
            if (ModelState.IsValid)
            {
                var result = _friendService.Update(friend);

                if (result.IsValid)
                {
                    TempData["success"] = "Amigo atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                result.AddToModelState(ModelState, null);
                return View(friend);
            }

            return View(friend);
        }

        public ActionResult Detail(Guid id)
        {
            return View(_friendService.GetById(id));
        }

        public ActionResult Delete(Guid id)
        {
            var result = _friendService.Delete(id);

            if (result.IsValid)
            {
                TempData["success"] = "Amigo excluido com sucesso!";
                return RedirectToAction("Index");
            }

            result.AddToModelState(ModelState, null);
            return View("Index");
        }

        #endregion

        #region AJAX

        public JsonResult GetAllFriends(DataTableRequest request)
        {
            return CreateDataTableResponse(_friendService.GetAll().ToList(), request);
        }

        public JsonResult GetAllBorrowing(DataTableRequest request, Guid id)
        {
            return CreateDataTableResponse(_friendService.GetBorrowedGamesByFriendId(id).ToList(), request);
        }

        #endregion
    }
}