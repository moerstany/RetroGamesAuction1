using RetroGamesAuction1.Models;

namespace RetroGamesAuction1.Services
{
    public class AuctionBidService
    {
        private readonly DataApplicationDbContext _context;

        public AuctionBidService(DataApplicationDbContext context)
        {
            _context = context;

        }
        public bool AddBids(Auctionbid bid)
        {
            _context.Auctionbid.Add(bid);
            return _context.SaveChanges() > 0;
        }
    }
}
