
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RetroGamesAuction1.Models;

namespace RetroGamesAuction1.Models;

public partial class DataApplicationDbContext : DbContext
{
    public DataApplicationDbContext(DbContextOptions<DataApplicationDbContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Auction> Auction { get; set; }

    public virtual DbSet<Auctionbid> Auctionbid { get; set; }

    public virtual DbSet<Product> Product { get; set; }
    public object AspNetUsers { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("ru_RU.utf8");

        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.IdAuction).HasName("auction_pkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Auction)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("auction_id_product_fkey");
        });

        modelBuilder.Entity<Auctionbid>(entity =>
        {
            entity.HasKey(e => e.IdAuctionbid).HasName("auctionbid_pkey");

            entity.Property(e => e.Datatime).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdAuctionNavigation).WithMany(p => p.Auctionbid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("idAuction");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("id_product");

            entity.Property(e => e.IdProduct).UseIdentityAlwaysColumn();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}