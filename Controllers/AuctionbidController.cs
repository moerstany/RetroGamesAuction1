using Microsoft.AspNetCore.Mvc;

using RetroGamesAuction1.Models.ViewModel;
using RetroGamesAuction1.Models;
using RetroGamesAuction1.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Plugins;
using Newtonsoft.Json.Linq;

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
        public JsonResult AddBid(int id) 
        {
            JsonResult jsonResult= new JsonResult(id) ;
           
            if (User.Identity.IsAuthenticated)
            {
                Auctionbid bid = new Auctionbid();

                bid.IdAuction = id;
                bid.IdClient = User.FindFirstValue(ClaimTypes.NameIdentifier);
                bid.Datatime = DateTime.Now;
                bid.Bid = 50;
                var bidResult = _auctionBidService.AddBids(bid);
                if (bidResult) { jsonResult.Value = new { Success = true }; }
                else { jsonResult.Value = new { Success = false, Message = "невозможно сделать ставку!" }; }
            }
            else
            {
                jsonResult.Value = new { Success = false, Message = "нужно зарегистрироваться, чтобы сделать ставку!" };  
            }
            return jsonResult;
            
        }

       
    }
}
