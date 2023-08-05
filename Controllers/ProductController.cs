using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroGamesAuction1.Data;
using RetroGamesAuction1.Models;
using System.Data;

namespace RetroGamesAuction1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        
        private readonly DataApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public ProductController(DataApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(Product product)
        {
            if(product.Photo1 != null)
            {
                string folder = "lib/product/";
                //создали уникальное имя файла
                folder +=Guid.NewGuid().ToString() + product.Photo1.FileName;
                product.ProductPic = folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath,folder);
                await product.Photo1.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                
                string folder1 = "lib/product/";
                //создали уникальное имя файла
                folder1 += Guid.NewGuid().ToString() + product.Photo2.FileName;
                product.ProductPic1 = folder1;
                string serverFolder1 = Path.Combine(_webHostEnvironment.WebRootPath, folder1);
                await product.Photo2.CopyToAsync(new FileStream(serverFolder1, FileMode.Create));
                
                string folder2 = "lib/product/";
                //создали уникальное имя файла
                folder2 += Guid.NewGuid().ToString() + product.Photo3.FileName;
                product.ProductPic2 = folder2;
                string serverFolder2 = Path.Combine(_webHostEnvironment.WebRootPath, folder2);
                await product.Photo3.CopyToAsync(new FileStream(serverFolder2, FileMode.Create));
            }
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
        public async Task<ActionResult> Edit(Product product)
        {
            try
            {
                Product pr = _context.Product.Find(product.IdProduct);
                pr.IdProduct = product.IdProduct;
                pr.ProductName = product.ProductName;
                pr.Articul = product.Articul;
                pr.Prise = product.Prise;
                pr.Description = product.Description;
                string folder = "lib/product/";
                //создали уникальное имя файла
                folder += Guid.NewGuid().ToString() + product.Photo1.FileName;
                product.ProductPic = folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await product.Photo1.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                string folder1 = "lib/product/";
                //создали уникальное имя файла
                folder1 += Guid.NewGuid().ToString() + product.Photo2.FileName;
                product.ProductPic1 = folder1;
                string serverFolder1 = Path.Combine(_webHostEnvironment.WebRootPath, folder1);
                await product.Photo2.CopyToAsync(new FileStream(serverFolder1, FileMode.Create));

                string folder2 = "lib/product/";
                //создали уникальное имя файла
                folder2 += Guid.NewGuid().ToString() + product.Photo3.FileName;
                product.ProductPic2 = folder2;
                string serverFolder2 = Path.Combine(_webHostEnvironment.WebRootPath, folder2);
                pr.ProductPic1 = product.ProductPic1;
                pr.ProductPic2 = product.ProductPic2;
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
    

