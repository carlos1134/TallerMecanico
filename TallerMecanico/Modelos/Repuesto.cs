using System;
using System.Collections.Generic;

namespace TallerMecanico.Modelos;

public partial class Repuesto
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }
}
