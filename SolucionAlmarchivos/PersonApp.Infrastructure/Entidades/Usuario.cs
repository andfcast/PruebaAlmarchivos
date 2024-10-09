using System;
using System.Collections.Generic;

namespace PersonApp.Infrastructure.Entidades;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
}
