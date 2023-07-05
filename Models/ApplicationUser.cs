using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RetroGamesAuction1.Models
{
    public class ApplicationUser:IdentityUser
    {
        [StringLength(50)]
        public string Name1 { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string PostCode { get; set; }

        [StringLength(200)]
        public string PostAdress { get; set; }

    }
}
