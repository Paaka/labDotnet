using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class ApiProductController : Controller
    {
        private readonly IProductRepository repository;

        public ApiProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of all products</returns>
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Product>> Listc()
        {
            return Ok(repository.Products.Select(p => p));
        }

        /// <summary>
        /// Gets all products by category
        /// </summary>
        /// <param name="category">Product category</param>
        /// <returns>All products by category</returns>
        [HttpGet("GetAllByCategory")]
        public ActionResult<IEnumerable<Product>> List(string category)
        {
            return Ok(repository.Products.Where(p => p.Category == category));
        }

        /// <summary>
        /// Gets one product by product Id
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>One exact product</returns>
        [HttpGet("GetById")]
        public ActionResult<Product> GetById(int id)
        {
            var product = repository.Products.SingleOrDefault(product => product.ProductID == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        /// <summary>
        /// Adds product to database.
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns>Introduced Product </returns>
        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            repository.SaveProduct(product);
            return Ok(product);
        }


        /// <summary>
        /// Deletes product by ID.
        /// </summary>
        /// <param name="productID">Product Id</param>
        /// <returns>Nothing</returns>
        [HttpDelete]
        public ActionResult<Product> DeleteProduct(int productID)
        {
            repository.DeleteProduct(productID);
            return NoContent();
        }

        /// <summary>
        /// Updates product
        /// </summary>
        /// <param name="product">Updated product</param>
        /// <returns>Updated product</returns>
        [HttpPut]
        public ActionResult UpdateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!repository.Products.Any(p => p.ProductID == product.ProductID))
                return NotFound();

            repository.SaveProduct(product);

            return NoContent();

        }
    }
}
