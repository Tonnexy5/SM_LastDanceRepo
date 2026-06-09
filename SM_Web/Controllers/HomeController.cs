using Microsoft.AspNetCore.Mvc;
using SM_Web.Models;
using System.Diagnostics;

namespace SM_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        #region RegistrarUsuarios
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(UsuarioModel model)
        {
            return View();
        }
        #endregion

        public IActionResult RecuperarAcceso()
        {
            return View();
        }

        public IActionResult Principal()
        {
            return View();
        }

    }
}
