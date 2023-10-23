using System;
using System.Collections.Generic;

namespace TallerMecanico.Modelos;

public partial class Desperfecto
{
    public long Id { get; set; }

    public long? IdPresupuesto { get; set; }

    public string? Descripcion { get; set; }

    public decimal? ManoDeObra { get; set; }

    public int? Tiempo { get; set; }

    public virtual Presupuesto? IdPresupuestoNavigation { get; set; }
}
