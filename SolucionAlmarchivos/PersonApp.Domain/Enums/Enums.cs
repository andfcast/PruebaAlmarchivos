using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Domain.Enums
{
    public enum TiposDocumento {
        [Display(Name ="Cédula de Ciudadanía")]
        CedulaCiudadania  =1,
        [Display(Name = "Nit")]
        Nit,
        [Display(Name = "Cédula de Extranjería")]
        CedulaExtranjeria,
        [Display(Name = "Tarjeta de Identidad")]
        TarjetaIdentidad,
        [Display(Name = "Pasaporte")]
        Pasaporte,
        [Display(Name = "Registro Civil")]
        RegistroCivil
    }
}
