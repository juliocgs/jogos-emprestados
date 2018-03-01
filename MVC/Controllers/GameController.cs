using Application.Models;
using MVC.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Mvc;

namespace MVC.Controllers
{
    public class GameController : BaseAuthController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
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
        public ActionResult Create(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                game.RegistrationDate = DateTime.Now;
                var result = _gameService.Create(game);

                if (result.IsValid)
                {
                    TempData["success"] = "Jogo Cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                result.AddToModelState(ModelState, null);
                return View();
            }

            return View();
        }

        public ActionResult Edit(Guid id)
        {
            return View(_gameService.GetById(id));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                var result = _gameService.Update(game);

                if (result.IsValid)
                {
                    TempData["success"] = "Jogo atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                result.AddToModelState(ModelState, null);
                return View(game);
            }

            return View(game);
        }

        public ActionResult Detail(Guid id)
        {
            return View(_gameService.GetById(id));
        }

        public ActionResult Delete(Guid id)
        {
            var result = _gameService.Delete(id);

            if (result.IsValid)
            {
                TempData["success"] = "Jogo excluido com sucesso!";
                return RedirectToAction("Index");
            }

            result.AddToModelState(ModelState, null);
            return View("Index");
        }

        #endregion

        #region AJAX

        public JsonResult GetAllGames(DataTableRequest request)
        {
            return CreateDataTableResponse(_gameService.GetAll().ToList(), request);
        }

        #endregion

    }
}