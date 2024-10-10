using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Domain.Enums
{
    public enum TiposDocumento {
        [Description("Cédula de Ciudadanía")]
        CedulaCiudadania = 1,
        [Description("Nit")]
        Nit,
        [Description("Cédula de Extranjería")]
        CedulaExtranjeria,
        [Description("Tarjeta de Identidad")]
        TarjetaIdentidad,
        [Description("Pasaporte")]
        Pasaporte,
        [Description("Registro Civil")]
        RegistroCivil
    }
}
