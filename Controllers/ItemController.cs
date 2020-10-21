using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static labDotnet.Models.ShopItemModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace labDotnet.Controllers
{
    public class ItemController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Product> listOfItems = new List<Product>();
            listOfItems.Add(new Product() { Name = "Ghost of Tsushima", Description  = "Open world RPG", Price =250});
            listOfItems.Add(new Product() { Name = "World of Warcraft: Shadowlands", Description = "MMORPG", Price = 160 });

            return View(listOfItems);
        }
    }
}
