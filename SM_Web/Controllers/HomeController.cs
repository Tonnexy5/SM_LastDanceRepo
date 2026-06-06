using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace SM_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
