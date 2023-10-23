using System;
using System.Collections.Generic;

namespace TallerMecanico.Modelos;

public partial class DesperfectoRepuesto
{
    public long? IdDesperfecto { get; set; }

    public long? IdRepuesto { get; set; }

    public virtual Desperfecto? IdDesperfectoNavigation { get; set; }

    public virtual Repuesto? IdRepuestoNavigation { get; set; }
}
