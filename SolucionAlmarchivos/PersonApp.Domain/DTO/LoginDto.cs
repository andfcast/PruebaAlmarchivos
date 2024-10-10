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
        [Required(ErrorMessage = "El campo Usuario es obligatorio")]
        [Display(Name ="Nombre de Usuario")]
        public string NomUsuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string Password { get; set; }

    }
}
