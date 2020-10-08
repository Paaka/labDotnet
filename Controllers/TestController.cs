using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace labDotnet.Controllers
{
    public class TestController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var today = "28 maja 2033";
            return View();
        }

        public IActionResult RedirectToFacebook()
        {
            return Redirect("https://www.facebook.com/");
        }

        public IActionResult GetJson()
        {
            return Json(new { firstName = "Mateusz", lastName = "Hartabus" });
        }
    }
}
