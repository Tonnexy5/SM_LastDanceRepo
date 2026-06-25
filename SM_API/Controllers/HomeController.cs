using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SM_API.Models;

namespace SM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(IConfiguration _databasekey) : ControllerBase
    {
        [HttpPost("RegistroAPI")]
        public IActionResult RegistroAPI(UsuarioModel model)
        {

            

                using var context = new SqlConnection(_databasekey["ConnectionStringsApi:DefaultConnection"]);


                var parameters = new DynamicParameters();
                parameters.Add("@identificacion", model.identificacion);
                parameters.Add("@nombre", model.nombre);
                parameters.Add("@correoElectronico", model.correoElectronico);
                //parameters.Add("@Contrasenna", model.Contrasenna);

                var response = context.Execute("spRegistrarUsuario", parameters);
                return Ok();
            
           
        }

    }
}
