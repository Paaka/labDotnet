using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repositry;

        public AdminController(IProductRepository repo)
        {
            repositry = repo;
        }

        public ViewResult Index() => View(repositry.Products);

        public ViewResult Edit(int productId) =>
            View(repositry.Products
                .FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
               
                repositry.SaveProduct(product);
                TempData["message"] = $"zapisano {product.Name }";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repositry.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"Usunięto {deletedProduct.Name}.";
            }
            return RedirectToAction("Index");
        }
    }
}
