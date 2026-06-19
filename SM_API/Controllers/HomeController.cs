using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SM_API.Models;

namespace SM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost("RegistroAPI")]
        public IActionResult RegistroAPI(UsuarioModel model)
        {
            using var context = new SqlConnection("Server=(localdb)\\TonyDB;Database=SM_BD;Integrated Security=True;  TrustServerCertificate=True;");
            

                var parameters = new DynamicParameters();
                parameters.Add("@identificacion", model.identificacion);
                parameters.Add("@nombre", model.nombre);
                parameters.Add("@correoElectronico", model.correoElectronico);
                parameters.Add("@Contrasenna", model.Contrasenna);

                var response = context.Execute("spRegistrarUsuario", parameters);
                return Ok();

        }

    }
}
