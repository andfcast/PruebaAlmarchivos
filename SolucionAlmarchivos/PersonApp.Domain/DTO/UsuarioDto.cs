using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Domain.DTO
{
    public class UsuarioDto : LoginDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La confirmación del password es obligatoria")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmaPass { get; set; } = string.Empty;
    }
}
