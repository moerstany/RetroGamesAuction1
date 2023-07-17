using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RetroGamesAuction1.Models;

namespace RetroGamesAuction1.Models
{
    [Table("AspNetUserRoles")]
    public partial class AspNetUserRoles
    {
        
        [ForeignKey("UsrerId")]
        [StringLength(450)]
        public string UserId { get; set; }
       
        [ForeignKey("RoleId")]
        [StringLength(450)]
        public string RoleId { get; set; }

        
        [InverseProperty("AspNetUserRoles")]
        public virtual AspNetUsers UserIdNavigation { get; set; }
        public AspNetUsers AspNetUsers { get; set; }
        
        [InverseProperty("AspNetUserRoles")]
        public virtual AspNetRoles RoleIdNavigation { get; set; }
        public AspNetRoles AspNetRoles { get; set; }
    }
}

