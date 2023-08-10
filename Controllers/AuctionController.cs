using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RetroGamesAuction1.Models;
using RetroGamesAuction1.Models.ViewModel;
using System.Linq.Expressions;
using NuGet.Packaging.Signing;
using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using RetroGamesAuction1.Services;

namespace RetroGamesAuction1.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        
        
        private readonly AuctionService _auctionService;
        public AuctionController( AuctionService auctionService)
        {
           
            _auctionService = auctionService;
        }

        // GET: Catalog1Controller
        public ActionResult Index(string searchBy, string searchValue)

        {
           
            if (string.IsNullOrEmpty(searchValue))
            {
                TempData["InfoMessage"] = "Введите значение для поиска";
                return View(_auctionService.SelectAuction());
            }
            else
            {
                if (searchBy.ToLower() == "productname")
                {
                    var searchByProductName = _auctionService.SelectAuction().Where(p => p.ProductName.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductName);
                }
                else if (searchBy.ToLower() == "articul")
                {
                    var searchByProductArticul = _auctionService.SelectAuction().Where(p => p.Articul.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductArticul);
                }
                else if (searchBy.ToLower() == "beginbid")
                {
                    var searchByProductCost = _auctionService.SelectAuction().Where(c => c.Beginbid == int.Parse(searchValue));
                    return View(searchByProductCost);
                }
            }
            return View(_auctionService.SelectAuction());
        }
        public ActionResult AllIndex(string searchBy, string searchValue)

        {

            if (string.IsNullOrEmpty(searchValue))
            {
                TempData["InfoMessage"] = "Введите значение для поиска";
                return View(_auctionService.SelectAuction());
            }
            else
            {
                if (searchBy.ToLower() == "productname")
                {
                    var searchByProductName = _auctionService.SelectAuction().Where(p => p.ProductName.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductName);
                }
                else if (searchBy.ToLower() == "articul")
                {
                    var searchByProductArticul = _auctionService.SelectAuction().Where(p => p.Articul.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductArticul);
                }
                else if (searchBy.ToLower() == "beginbid")
                {
                    var searchByProductCost = _auctionService.SelectAuction().Where(c => c.Beginbid == int.Parse(searchValue));
                    return View(searchByProductCost);
                }
            }
            return View(_auctionService.SelectAuction());
        }

        public ActionResult Details(int id)
        {
            _auctionService.SelectAuctionById(id);
            
            return View(_auctionService.SelectAuctionById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            Auction auction = new Auction();

            return View(auction);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Auction auction)
        {
            _auctionService.SaveAuction(auction);
            TempData["AlertMessage"] = "Ayкцион Создан!";
            return RedirectToAction(nameof(AllIndex));
        }

        // GET: AuctionController/Edit/5
        public ActionResult Edit(int id)
        {
            var auction = _auctionService.GetAuctionByID(id);
            return View(auction);
        }
       
        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Auction auction)
        {
            _auctionService.UpdateAuction(auction);
            TempData["AlertMessage"] = "Аукцион изменен!";
            
            return RedirectToAction(nameof(AllIndex));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            _auctionService.RemoveAuction(id);
            TempData["AlertMessage"] = "Aукцион удален!";
            return RedirectToAction(nameof(AllIndex));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
    

