using Microsoft.AspNetCore.Mvc;
using SM_Web.Models;
using System.Diagnostics;
using System.Net;

namespace SM_Web.Controllers
{
    public class HomeController(IHttpClientFactory _http, IConfiguration _config) : Controller
    {

        #region Iniciar Sesion

        [HttpGet]
        public IActionResult Index()
        {

            var cero = 0;
            var resultado = 10 / cero;

            return View();
        }

        [HttpPost]
        public IActionResult Index(UsuarioModel model)
        {

            using (var client = _http.CreateClient())
            {



                var urlApi = _config["ConnectionStringsWeb:urlApi"] + "/api/Home/IniciarSesionAPI";
                
                var response = client.PostAsJsonAsync(urlApi, model).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    HttpContext.Session.SetString("Autenticado", "1");

                    return RedirectToAction("Principal", "Home");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {


                    ViewBag.Mensaje = response.Content.ReadAsStringAsync().Result;
                    return View();

                }
                else
                {

                    throw new Exception("Ocurrió un error al intentar iniciar sesión.");
                }



            }


            return View();
        }
        #endregion

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


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {


                    ViewBag.Mensaje = response.Content.ReadAsStringAsync().Result;
                    return View();

                }
                else
                {

                    throw new Exception("Ocurrió un error al intentar registrar el usuario.");
                }


            }

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
