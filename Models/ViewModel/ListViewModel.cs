using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetroGamesAuction1.Models.ViewModel
{
    public class ListViewModel
    {
        public int IdAuction { get; set; }               
        public int? IdProduct { get; set; }
        public string ProductName { get; set; }
        public string Articul { get; set; }        
        public int Prise { get; set; }        
        public string Description { get; set; }   
        public int Beginbid { get; set; }
        
        public int LastBid { get; set; }
        public DateTime? Begintime { get; set; }       
        public DateTime? Endtime { get; set; }
        [NotMapped]
        public DateTime DateTime { get; set; } = DateTime.Now;
        [NotMapped]
        public TimeSpan? Date1 { get; set; }
        public string ClientName { get; set; }
        public string ProductPic { get; set; }        
        public string ProductPic1 { get; set; }        
        public string ProductPic2 { get; set; }
        public string IdClient { get; set; }
        public string UserName { get; set; }
        public int Bid { get; set; }
        public DateTime? Datatime { get; set; }
        public string? Status { get; set; }
        [NotMapped]
        public int BidSum { get; set; }
        public string Info { get; set; }
        public int IdAuctionbid { get; set; }
        public List<Auctionbid> Auctionbids { get; set; }
    }
}
