using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Domain.DTO
{
    public class PersonaDto
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombres es obbligatorio")]
        [MaxLength(50)]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Apellidos es obbligatorio")]
        [MaxLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Tipo de Identificacion es obbligatorio")]
        [Display(Name ="Tipo de Identificacion")]
        public string IdTipoIdentificacion { get; set; }
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "El campo Número de identificación es obligatorio")]
        [MaxLength(20)]
        [Display(Name ="Número de Identificacion")]
        public string NumIdentificacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Email es obbligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

    }
}
