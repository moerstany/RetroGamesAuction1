using Microsoft.AspNetCore.Mvc;
using RetroGamesAuction1.Models.ViewModel;
using RetroGamesAuction1.Models;
using RetroGamesAuction1.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace RetroGamesAuction1.Controllers
{
    
    public class AuctionbidController : Controller
    {
        private readonly AuctionBidService _auctionBidService;
        public AuctionbidController(AuctionBidService auctionBidService)
        {

            _auctionBidService = auctionBidService;
        }
        [HttpGet]
        public IActionResult AddBid()
        {
            Auctionbid bid = new Auctionbid();

            return View(bid);
        }
        [HttpPost]
        public ActionResult AddBid(int id)
        {
            Auctionbid bid = new Auctionbid();
            
            if (User.Identity.IsAuthenticated)
            {
                
                bid.IdAuction = id;
                bid.IdClient = User.FindFirstValue(ClaimTypes.NameIdentifier);
                bid.Datatime = DateTime.Now;
                bid.Bid = 10;
                var bidResult = _auctionBidService.AddBids(bid);
                return View(bidResult);
            }
            else
            {
                return RedirectToAction("Register.cshtml");  
            }

            
        }

        public IActionResult AddtoCart(int id)
        {
           // Auction au = _context.Auction.Find(auction.IdProduct);
            return View();
        }
    }
}
