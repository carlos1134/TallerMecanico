using System;
using System.Collections.Generic;

namespace TallerMecanico.Modelos;

public partial class Presupuesto
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public decimal? Total { get; set; }

    public long? IdVehiculo { get; set; }

    public virtual ICollection<Desperfecto> Desperfectos { get; set; } = new List<Desperfecto>();

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
