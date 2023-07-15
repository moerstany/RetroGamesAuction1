using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RetroGamesAuction1.Models;
using RetroGamesAuction1.Models.ViewModel;
using System.Linq.Expressions;
using NuGet.Packaging.Signing;
using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RetroGamesAuction1.Controllers
{
    public class AuctionController : Controller
    {
        
        private readonly DataApplicationDbContext _context;
        public AuctionController(DataApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catalog1Controller
        public ActionResult Index(string searchBy, string searchValue)

        {
            var data = (from c in _context.Auction
                        join p in _context.Product
                        on c.IdProduct equals p.IdProduct
                        select new ListViewModel
                        {
                            IdAuction = c.IdAuction,
                            ProductName = p.ProductName,
                            Articul = p.Articul,
                            Prise = p.Prise,
                            Description = p.Description,
                            ProductPic = p.ProductPic,
                            Beginbid = c.Beginbid,
                            Begintime = c.Begintime,
                            Endtime = c.Endtime,
                            Date1 = c.Endtime - c.DateTime


                        }).ToList();

            if (string.IsNullOrEmpty(searchValue))
            {
                TempData["InfoMessage"] = "Введите значение для поиска";
                return View(data);
            }
            else
            {
                if (searchBy.ToLower() == "productname")
                {
                    var searchByProductName = data.Where(p => p.ProductName.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductName);
                }
                else if (searchBy.ToLower() == "articul")
                {
                    var searchByProductArticul = data.Where(p => p.Articul.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductArticul);
                }
                else if (searchBy.ToLower() == "beginbid")
                {
                    var searchByProductCost = data.Where(p => p.Beginbid == int.Parse(searchValue));
                    return View(searchByProductCost);
                }
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Auction catalog = new Auction();

            return View(catalog);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Auction catalog)
        {
            _context.Add(catalog);
            _context.SaveChanges();
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
    

