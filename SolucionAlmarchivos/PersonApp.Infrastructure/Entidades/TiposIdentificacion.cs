using System;
using System.Collections.Generic;

namespace PersonApp.Infrastructure.Entidades;

public partial class TiposIdentificacion
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
