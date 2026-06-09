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

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult RecuperarAcceso()
        {
            return View();
        }


    }
}
