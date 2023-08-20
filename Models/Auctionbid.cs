﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RetroGamesAuction1.Models;


    [Table("auctionbid")]
    public partial class Auctionbid
    {
        [Key]
        [Column("id_auctionbid")]
        public int IdAuctionbid { get; set; }

        [Column("id_auction")]
        public int? IdAuction { get; set; }

        [Column("id_client")]
        [StringLength(450)]
        public string IdClient { get; set; }

        [Column("bid")]
        public int Bid { get; set; }

        [Column("datatime", TypeName = "timestamp without time zone")]
        public DateTime? Datatime { get; set; }

        [ForeignKey("IdAuction")]
        [InverseProperty("Auctionbid")]
        public virtual Auction IdAuctionNavigation { get; set; }

        [ForeignKey("IdClient")]
        [InverseProperty("Auctionbid")]
        public virtual AspNetUsers IdClientNavigation { get; set; }
    }

   
