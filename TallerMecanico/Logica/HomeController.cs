using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TallerMecanico.Modelos;
using TallerMecanico.Persistencia;
using System.Linq;
using System.Collections.Generic;
using TallerMecanico.Logica.Utils;
using TallerMecanico.Dtos;

namespace TallerMecanico.Logica
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TallerMecanicoContext _dbContext;
        private readonly ITallerPersistencia _tallerPersistencia;

        public HomeController(ILogger<HomeController> logger, TallerMecanicoContext dbContext, ITallerPersistencia tallerPersistencia)
        {
            _logger = logger;
            _dbContext = dbContext;
            _tallerPersistencia = tallerPersistencia;
        }

        public IActionResult Index()
        {
            var taller = new Taller
            {
                repuestos = new List<RepuestoDto>()
            };

            return View(taller);
        }

        public IActionResult Presupuesto(Taller taller)
        {
            return View(taller);
        }

        [HttpPost]
        public IActionResult Finalizar(Taller taller)
        {
            decimal costoTotal = CalculadoraCosto.CalcularCostoTotal(taller);

            var componentesCosto = new List<ComponenteCosto>
            {
                new ComponenteCosto { Nombre = "Costo de Repuestos", Valor = (decimal)taller.repuestos.Sum(r => r.Precio) },
                new ComponenteCosto { Nombre = "Costo de Mano de Obra", Valor = (decimal)taller.desperfecto.ManoDeObra },
                new ComponenteCosto { Nombre = "Costo de Estacionamiento", Valor = ((decimal)(130 * taller.desperfecto.Tiempo)) },
                new ComponenteCosto { Nombre = "Descuento", Valor = 0 },
                new ComponenteCosto { Nombre = "Recargo", Valor = 0 },
                new ComponenteCosto { Nombre = "Ganancia del Taller", Valor = costoTotal * 0.10m },
            };

            taller.CostoTotal = costoTotal;

            taller.ComponentesCosto = componentesCosto;

            // Guardar los datos en la base de datos
            _tallerPersistencia.GuardarTaller(taller);

            return View("Presupuesto", taller);
        }
    }
}
