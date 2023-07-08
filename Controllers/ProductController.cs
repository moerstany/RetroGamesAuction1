using Microsoft.AspNetCore.Mvc;
using RetroGamesAuction1.Data;
using RetroGamesAuction1.Models;

namespace RetroGamesAuction1.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Product1Controller
        public ActionResult Index(string searchBy, string searchValue)
        {
            List<Product> products;
            products = _context.Product.ToList();
            if (string.IsNullOrEmpty(searchValue))
            {
                TempData["InfoMessage"] = "Введите значение для поиска";
                return View(products);
            }
            else
            {
                if (searchBy.ToLower() == "productname")
                {
                    var searchByProductName = products.Where(p => p.ProductName.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductName);
                }
                else if (searchBy.ToLower() == "articul")
                {
                    var searchByProductArticul = products.Where(p => p.Articul.ToLower().Contains(searchValue.ToLower()));
                    return View(searchByProductArticul);
                }
                else if (searchBy.ToLower() == "cost")
                {
                    var searchByProductCost = products.Where(p => p.Prise == int.Parse(searchValue));
                    return View(searchByProductCost);
                }
            }
            return View(products);
        }

        // GET: Product1Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();

            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            TempData["AlertMessage"] = "Продукт Создан!";
            return RedirectToAction("index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {

            Product product = _context.Product.Find(id);
            return View(product);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                Product pr = _context.Product.Find(product.IdProduct);
                pr.IdProduct = product.IdProduct;
                pr.ProductName = product.ProductName;
                pr.Articul = product.Articul;
                pr.Prise = product.Prise;
                pr.Description = product.Description;
                pr.ProductPic = product.ProductPic;
                
                _context.SaveChanges();
                TempData["AlertMessage"] = "Продукт изменен!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            _context.Product.Remove(_context.Product.Find(id));
            _context.SaveChanges();
            TempData["AlertMessage"] = "Продукт удален!";
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
    

