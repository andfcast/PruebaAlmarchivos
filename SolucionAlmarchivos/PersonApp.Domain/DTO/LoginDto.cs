using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Domain.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El campo Usuario es obbligatorio")]
        public string NomUsuario { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Contraseña es obbligatorio")]
        public string Password { get; set; } = string.Empty;
    }
}
