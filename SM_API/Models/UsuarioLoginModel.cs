using System.ComponentModel.DataAnnotations;

namespace SM_API.Models
{
    public class UsuarioLoginModel
    {

        [Required]
        public string correoElectronico { get; set; } = string.Empty;

        [Required]
        public string Contrasenna { get; set; } = string.Empty;



    }
}
