using Microsoft.AspNetCore.Mvc;
using RetroGamesAuction1.Models.ViewModel;
using RetroGamesAuction1.Models;
namespace RetroGamesAuction1.Controllers
{
    public class AuctionbidController : Controller
    {
        private readonly DataApplicationDbContext _context;
        public AuctionbidController(DataApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddtoCart(int id)
        {
           // Auction au = _context.Auction.Find(auction.IdProduct);
            return View();
        }
    }
}
