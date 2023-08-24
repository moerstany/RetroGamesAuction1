using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetroGamesAuction1.Data;
using RetroGamesAuction1.Models;
using RetroGamesAuction1.Models.ViewModel;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace RetroGamesAuction1.Services
{
    public class AuctionBidService
    {
        private readonly DataApplicationDbContext _context;
        //private readonly ApplicationDbContext _context1;
        public AuctionBidService(DataApplicationDbContext context,ApplicationDbContext context1)
        {
            _context = context;
            //_context1= context1;
        }

        public bool AddBids(Auctionbid bid)
        {
            _context.Auctionbid.Add(bid);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<ListViewModel> SelectAuctionbid()
        {
            
            var data = (from a in _context.Auctionbid
                        join b in _context.Auction
                        on a.IdAuction equals b.IdAuction
                        join p in _context.Product
                        on b.IdProduct equals p.IdProduct
                        
                        select new ListViewModel
                        {
                            IdAuction = b.IdAuction,
                            ProductName = p.ProductName,
                            Articul = p.Articul,
                            Prise = p.Prise,
                            Description = p.Description,
                            ProductPic = p.ProductPic,
                            Beginbid = b.Beginbid,
                            Datatime = a.Datatime,
                            Endtime = b.Endtime,
                            IdClient = a.IdClient,
                            LastBid = a.LastBid,
                            ClientName = a.ClientName,
                            Status = a.Status,
                            BidSum = b.Beginbid + a.LastBid

                        }

                        ).ToList();
            return data;
        }

        public IEnumerable<ListViewModel> SelectAuctionbidById(int id)
        {
           /* var dataId1 = (from a in _context.Auctionbid.Where(c => c.IdAuction == id)
                          group a by a.Bid into grouped
                           select new ListViewModel
                           {
                               BidSum = grouped.Sum(a => a.Bid)
                           }

                        ).ToList();

            int BidSum = dataId1.Select(a => a.Bid).ToArray()[0];*/

            var dataId = (from a in _context.Auctionbid.Where(c => c.IdAuction == id)
                          
                          join b in _context.Auction
                          on a.IdAuction equals b.IdAuction
                          join p in _context.Product
                          on b.IdProduct equals p.IdProduct
                          
                          select new ListViewModel
                          {   IdAuctionbid=a.IdAuctionbid,
                              IdAuction = b.IdAuction,
                              ProductName = p.ProductName,
                              Articul = p.Articul,
                              Prise = p.Prise,
                              Description = p.Description,
                              ProductPic = p.ProductPic,
                              Beginbid = b.Beginbid,
                              Datatime = a.Datatime,
                              Endtime = b.Endtime,
                              IdClient = a.IdClient,
                              Bid=a.Bid,
                              
                              LastBid = a.LastBid,
                              BidSum= b.Beginbid+ a.LastBid,
                              ClientName =a.ClientName,
                              Status = a.Status,
                              Info=a.Info
                          }

                        ).ToList();
           
           
            
            return dataId;
        }

        public IEnumerable<ListViewModel> SelectAuctionbidByUserId(string id)
        {
             

            var dataId = (from a in _context.Auctionbid.Where(c => c.IdClient == id)

                          join b in _context.Auction
                          on a.IdAuction equals b.IdAuction
                          join p in _context.Product
                          on b.IdProduct equals p.IdProduct
                          orderby a.Datatime
                          select new ListViewModel
                          {
                              IdAuctionbid = a.IdAuctionbid,
                              IdAuction = b.IdAuction,
                              ProductName = p.ProductName,
                              Articul = p.Articul,
                              Prise = p.Prise,
                              Description = p.Description,
                              ProductPic = p.ProductPic,
                              Beginbid = b.Beginbid,
                              Datatime = a.Datatime,
                              Endtime = b.Endtime,
                              IdClient = a.IdClient,
                              Bid = a.Bid,
                              //Bid= b.Beginbid + BidSum,
                              LastBid =a.LastBid,
                              ClientName = a.ClientName,
                              Status = a.Status,
                              Info = a.Info,
                              BidSum = b.Beginbid + a.LastBid
                          }

                        ).ToList();



            return dataId;
        }
    }
}
