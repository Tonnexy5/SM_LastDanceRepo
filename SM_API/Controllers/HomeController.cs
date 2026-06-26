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
        public IActionResult RegistroAPI(UsuarioRegistroModel model)
        {

            using var context = new SqlConnection(_databasekey["ConnectionStringsApi:DefaultConnection"]);


            var parameters = new DynamicParameters();
            parameters.Add("@identificacion", model.identificacion);
            parameters.Add("@nombre", model.nombre);
            parameters.Add("@correoElectronico", model.correoElectronico);
            parameters.Add("@Contrasenna", model.Contrasenna);

            var response = context.Execute("spRegistrarUsuario", parameters);
            return Ok();


        }


        [HttpPost("IniciarSesionAPI")]
        public IActionResult IniciarSesionAPI(UsuarioLoginModel model)
        {

            using var context = new SqlConnection(_databasekey["ConnectionStringsApi:DefaultConnection"]);


            var parameters = new DynamicParameters();
            
            parameters.Add("@correoElectronico", model.correoElectronico);
            parameters.Add("@Contrasenna", model.Contrasenna);

            var response = context.QueryFirstOrDefault<DatoUsuarioResponseModel>("spIniciarSesionUsuario", parameters);


            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Usuario no encontrado o credenciales incorrectas.");
            }



        }

    }
}
