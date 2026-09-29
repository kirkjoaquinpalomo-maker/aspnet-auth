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

        // EDIT - show the edit form
        public IActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);

            if (product == null)
                return RedirectToAction("Index");

            return View(product);
        }

        // EDIT - save the changes
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE - remove the product
        public IActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);

            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}