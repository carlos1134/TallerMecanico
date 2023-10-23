using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMecanico.Modelos;

public partial class Automovil
{
    [Key]
    public long Id { get; set; }
    [Required]
    [ForeignKey("IdVehiculo")]
    public long IdVehiculo { get; set; }

    public short? Tipo { get; set; }

    public short? CantidadPuertas { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
