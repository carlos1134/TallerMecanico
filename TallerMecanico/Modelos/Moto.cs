using System;
using System.Collections.Generic;

namespace TallerMecanico.Modelos;

public partial class Moto
{
    public long Id { get; set; }

    public long? IdVehiculo { get; set; }

    public string? Cilindrada { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
