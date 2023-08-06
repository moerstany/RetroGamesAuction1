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
        
        private readonly DataApplicationDbContext _context;
        private readonly AuctionService _auctionService;
        public AuctionController(DataApplicationDbContext context, AuctionService auctionService)
        {
            _context = context;
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
        public IActionResult Details (int id)
        {
           
            var data = (from c in _context.Auction
                        join p in _context.Product
                        on c.IdProduct equals p.IdProduct
                        select new ListViewModel
                        {
                            IdAuction = c.IdAuction,
                            IdProduct = p.IdProduct,
                            ProductName = p.ProductName,
                            Articul = p.Articul,
                            Prise = p.Prise,
                            Description = p.Description,
                            ProductPic = p.ProductPic,
                            ProductPic1 = p.ProductPic1,
                            ProductPic2 = p.ProductPic2,
                            Beginbid = c.Beginbid,
                            Begintime = c.Begintime,
                            Endtime = c.Endtime



                        }).ToList();

           
            return View(data);
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
            TempData["AlertMessage"] = "Товар Создан!";
            return RedirectToAction("index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {

            Auction catalog = _context.Auction.Find(id);
            return View(catalog);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Auction catalog)
        {
            try
            {
                Auction pr = _context.Auction.Find(catalog.IdAuction);
                pr.IdAuction = catalog.IdAuction;
                pr.Beginbid = catalog.Beginbid;
                pr.Begintime = catalog.Begintime;
                pr.Endtime = catalog.Endtime;
                _context.SaveChanges();
                TempData["AlertMessage"] = "Товар изменен!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            _context.Auction.Remove(_context.Auction.Find(id));
            _context.SaveChanges();
            TempData["AlertMessage"] = "Товар удален!";
            return RedirectToAction(nameof(Index));
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
    

