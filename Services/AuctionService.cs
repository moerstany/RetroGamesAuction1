using RetroGamesAuction1.Models;
using RetroGamesAuction1.Models.ViewModel;

namespace RetroGamesAuction1.Services
{
    public class AuctionService
    {
        private readonly DataApplicationDbContext _context;
         
        public AuctionService(DataApplicationDbContext context)
        {
            _context = context;
            
        }

        public Auction GetAuctionByID(int id)
        {
           return _context.Auction.Find(id);
            

        }

        public void SaveAuction(Auction auction)
            {
            _context.Auction.Add(auction);
            _context.SaveChanges();
                
            }

        public void UpdateAuction(Auction auction)
        {
            _context.Update(auction);   
            _context.SaveChanges();

        }
        public IEnumerable<ListViewModel> SelectAuction()
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


                        }

                        ).ToList();
            return data;
        }


    }
}

