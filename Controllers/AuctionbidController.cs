using Microsoft.AspNetCore.Mvc;

using RetroGamesAuction1.Models.ViewModel;
using RetroGamesAuction1.Models;
using RetroGamesAuction1.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Plugins;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using NuGet.Versioning;

namespace RetroGamesAuction1.Controllers
{
    
    public class AuctionbidController : Controller
    {
        //private readonly AuctionService _auctionService;
        private readonly AuctionBidService _auctionBidService;
        public AuctionbidController(AuctionBidService auctionBidService/*, AuctionService auctionService*/)
        {

            _auctionBidService = auctionBidService;
           // _auctionService = auctionService;
        }

        public ActionResult Index(string searchBy, string searchValue)

        {

            if (string.IsNullOrEmpty(searchValue))
            {
                TempData["InfoMessage"] = "Введите значение для поиска";
                return View(_auctionBidService.SelectAuctionbid());
            }
            else
            {
                if (searchBy.ToLower() == "productname")
                {
                    var searchByProductName = _auctionBidService.SelectAuctionbid().Where(p => p.ProductName.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductName);
                }
                else if (searchBy.ToLower() == "clientname")
                {
                    var searchByClientName = _auctionBidService.SelectAuctionbid().Where(p => p.ClientName.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByClientName);
                }
                else if (searchBy.ToLower() == "status")
                {
                    var searchByStatus = _auctionBidService.SelectAuctionbid().Where(p => p.Status.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByStatus);
                }
                else if (searchBy.ToLower() == "idauction")
                {
                    var searchByIdAuction = _auctionBidService.SelectAuctionbid().Where(c => c.IdAuction == int.Parse(searchValue));
                    return View(searchByIdAuction);
                }
            }
            return View(_auctionBidService.SelectAuctionbid());
        }

        public ActionResult Details(int id)
        {
            _auctionBidService.SelectAuctionbidById(id);

            return View(_auctionBidService.SelectAuctionbidById(id));
        }

        public ActionResult DetailsID(string id)
        {
            _auctionBidService.SelectAuctionbidByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(_auctionBidService.SelectAuctionbidByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpGet]
        public IActionResult AddBid()
        {
            Auctionbid bid = new Auctionbid();

            return View(bid);
        }

        [HttpPost]
        public IActionResult AddBid(int id ) 
        {
            JsonResult jsonResult= new JsonResult(id) ;
           
            if (User.Identity.IsAuthenticated)
            {
               Auctionbid bid = new Auctionbid();
                int count = _auctionBidService.SelectAuctionbidById(id).Count();

                bid.IdAuction = id;
                //bid.ClientName = User.FindFirstValue(ClaimTypes.Name);//находит имя пользователя
                bid.IdClient = User.FindFirstValue(ClaimTypes.NameIdentifier);//находит id пользователя
                bid.ClientName= User.FindFirstValue(ClaimTypes.Name).ToString();
                bid.Datatime = DateTime.Now;
                bid.Bid = 50;
                bid.LastBid = (bid.Bid+(bid.Bid*count));
                var bidResult = _auctionBidService.AddBids(bid);
                if (bidResult) { 
                    TempData["AlertMessage"] = "Ставка сделана!";
                    //jsonResult.Value = new { Success = true };
                    }
                else {
                    TempData["AlertMessage"] = "невозможно сделать ставку!";
                    //jsonResult.Value = new { Success = false, Message = "невозможно сделать ставку!" };
                }
            }
            else
            {
                TempData["AlertMessage"] = "нужно зарегистрироваться, чтобы сделать ставку!";
                //jsonResult.Value = new { Success = false, Message = "нужно зарегистрироваться, чтобы сделать ставку!" };  
            }
            //return jsonResult;
           return RedirectToAction("Details", "Auction", new { id }); 
             
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            

            return View();
        }

    }
}
