using Microsoft.AspNetCore.Mvc;
using SM_Web.Models;
using System.Diagnostics;

namespace SM_Web.Controllers
{
    public class HomeController(IHttpClientFactory _http, IConfiguration _config) : Controller
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

            using (var client = _http.CreateClient())
            {

               

                var urlApi = _config["ConnectionStringsWeb:urlApi"] + "/api/Home/RegistroAPI";
                   ;
                var response = client.PostAsJsonAsync(urlApi, model).Result;

            }

            
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
