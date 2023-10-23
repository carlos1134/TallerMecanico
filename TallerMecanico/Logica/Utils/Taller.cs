using TallerMecanico.Dtos;
using TallerMecanico.Logica.Utils;

namespace TallerMecanico.Modelos
{
    public class Taller
    {
        public VehiculoDto? vehiculo { get; set; }
        public AutomovilDto? automovil { get; set; }
        public MotoDto? moto { get; set; }
        public ClienteDto? cliente { get; set; }
        public DesperfectoDto? desperfecto { get; set; }
        public PresupuestoDto? presupuesto { get; set; }
        public List<RepuestoDto>? repuestos { get; set; }
        public decimal? CostoTotal { get; internal set; }
        public List<ComponenteCosto>? ComponentesCosto { get; set; }
        public enum TipoAutomovil
        {
            Compacto = 1,
            Sedan = 2,
            Monovolumen = 3,
            Utilitario = 4,
            Lujo = 5
        }
    }
    
}
