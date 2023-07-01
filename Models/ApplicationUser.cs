using Microsoft.AspNetCore.Identity;

namespace RetroGamesAuction1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name1 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public string PostAdress { get; set; }

    }
}
