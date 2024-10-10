using System;
using System.Collections.Generic;

namespace PersonApp.Infrastructure.Entidades;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string NumIdentificacion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IdTipoIdentificacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual TiposIdentificacion IdTipoIdentificacionNavigation { get; set; } = null!;
}
