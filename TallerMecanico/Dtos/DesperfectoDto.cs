namespace TallerMecanico.Dtos
{
    public class DesperfectoDto
    {
        public long? IdPresupuesto { get; set; }

        public string? Descripcion { get; set; }

        public decimal? ManoDeObra { get; set; }

        public int? Tiempo { get; set; }

        public virtual PresupuestoDto? IdPresupuestoNavigation { get; set; }
    }
}
