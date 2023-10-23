namespace TallerMecanico.Dtos
{
    public class MotoDto
    {
        public long? IdVehiculo { get; set; }

        public string? Cilindrada { get; set; }

        public virtual VehiculoDto? IdVehiculoNavigation { get; set; }
    }
}
