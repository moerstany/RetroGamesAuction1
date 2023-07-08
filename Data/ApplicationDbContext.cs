using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RetroGamesAuction1.Models;

namespace RetroGamesAuction1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }

        public DbSet<Auction> Auction { get; set; }
        public DbSet<Auctionbid> Auctionbid { get; set; }
        
    }
}