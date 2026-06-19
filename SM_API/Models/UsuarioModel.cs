using System.ComponentModel.DataAnnotations;

namespace SM_API.Models
{
    public class UsuarioModel
    {

        [Required]
        public string identificacion { get; set; } = string.Empty;

        [Required]
        public string nombre { get; set; } = string.Empty;

        [Required]
        public string correoElectronico { get; set; } = string.Empty;

        [Required]
        public string Contrasenna { get; set; } = string.Empty;



    }
}
