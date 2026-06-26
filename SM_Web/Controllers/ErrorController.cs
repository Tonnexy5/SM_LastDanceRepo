using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
namespace SM_Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult CapturarError()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return View("Error");
        }
    }
}
