namespace TallerMecanico.Dtos
{
    public class AutomovilDto
    {
        public long? IdVehiculo { get; set; }

        public short? Tipo { get; set; }

        public short? CantidadPuertas { get; set; }

        public virtual VehiculoDto? IdVehiculoNavigation { get; set; }
    }
}
