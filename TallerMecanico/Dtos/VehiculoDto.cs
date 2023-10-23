using TallerMecanico.Modelos;

namespace TallerMecanico.Dtos
{
    public class VehiculoDto
    {
        public long? IdVehiculo { get; set; }

        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public string? Patente { get; set; }

        public virtual ICollection<Automovil> Automovils { get; set; } = new List<Automovil>();

        public virtual ICollection<MotoDto> Motos { get; set; } = new List<MotoDto>();

        public virtual ICollection<PresupuestoDto> Presupuestos { get; set; } = new List<PresupuestoDto>();
    }
}
