using Application.Models;
using MVC.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BorrowingController : BaseAuthController
    {
        private readonly IBorrowingService _borrowingService;
        private readonly IGameService _gameService;
        private readonly IFriendService _friendService;

        public BorrowingController(IBorrowingService borrowingService, IGameService gameService, IFriendService friendService)
        {
            _borrowingService = borrowingService;
            _gameService = gameService;
            _friendService = friendService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewData["borrowing.friends"] = _friendService.GetAll();
            ViewData["borrowing.games"] = _gameService.GetAllAvailable();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(BorrowingViewModel borrowing)
        {
            borrowing.BorrowedDate = DateTime.Now;
            _borrowingService.Create(borrowing);

            TempData["success"] = "Jogo emprestado com sucesso!";
            return RedirectToAction("Index");
        }

        public ActionResult ReturnGame(Guid id)
        {
            _borrowingService.ReturnGameByBorrowingId(id);
            TempData["success"] = "Jogo devolvido com sucesso!";
            return RedirectToAction("Index");
        }

        #region AJAX

        public JsonResult GetAllBorrowing(DataTableRequest request)
        {
            return CreateDataTableResponse(_borrowingService.GetAll().ToList(), request);
        }

        #endregion
    }
}