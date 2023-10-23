namespace TallerMecanico.Dtos
{
    public class PresupuestoDto
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Email { get; set; }

        public decimal? Total { get; set; }

        public long? IdVehiculo { get; set; }

        public virtual ICollection<DesperfectoDto> Desperfectos { get; set; } = new List<DesperfectoDto>();

        public virtual VehiculoDto? IdVehiculoNavigation { get; set; }
    }
}
