using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetroGamesAuction1.Models.ViewModel;
using RetroGamesAuction1.Data;

namespace RetroGamesAuction1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager,ApplicationDbContext context)
        {
            _context = context;
            _roleManager = roleManager;
        }
        //Создали лист ролей 
        public IActionResult  Index()
        {
            //var roles = _roleManager.Roles.ToList();
            var roles = (from ur in  _context.UserRoles
                         join r in _context.Roles
                         on ur.RoleId equals r.Id
                         join u in _context.Users
                         on ur.UserId equals u.Id
                         select new ListViewModel1
                         {
                             RoleId = r.Id,
                             RoleName = r.Name,
                             UserId = u.Id,
                             UserName = u.UserName


                         }).ToList();

            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(IdentityRole model) 
        {
            
                if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
                }
            
            return RedirectToAction("Index");
        }
    }
}
