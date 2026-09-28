using Microsoft.AspNetCore.Mvc;
using aspnet_auth.Data;
using aspnet_auth.Models;

namespace aspnet_auth.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Shows the list of products
        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        // Shows the Add Product form
        public IActionResult Create()
        {
            return View();
        }

        // Saves the new product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}