﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
       // public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    }
}