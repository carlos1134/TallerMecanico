using TallerMecanico.Modelos;

namespace TallerMecanico.Logica.Utils
{
    public class CalculadoraCosto
    {
        public static decimal CalcularCostoTotal(Taller taller)
        {
            decimal costoRepuestos = (decimal)taller.repuestos.Sum(r => r.Precio);
            decimal costoManoDeObra = (decimal)taller.desperfecto.ManoDeObra;
            decimal costoEstacionamiento = (decimal)(130 * taller.desperfecto.Tiempo);

            decimal descuento = 0; // Agrega lógica para calcular el descuento si es necesario
            decimal recargo = 0; // Agrega lógica para calcular el recargo si es necesario

            decimal gananciaTaller = (costoRepuestos + costoManoDeObra + costoEstacionamiento) * 0.10m;

            decimal costoTotal = costoRepuestos + costoManoDeObra + costoEstacionamiento + descuento + recargo + gananciaTaller;

            return costoTotal;
        }
    }
}
