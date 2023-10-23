using AutoMapper;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using TallerMecanico.Dtos;
using TallerMecanico.Modelos;

namespace TallerMecanico.Persistencia
{
    public class TallerPersistencia : ITallerPersistencia
    {
        private readonly TallerMecanicoContext _dbContext;
        private readonly IMapper _mapper;

        public TallerPersistencia(TallerMecanicoContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void GuardarTaller(Taller taller)
        {
            if (taller.vehiculo != null)
            {
                Vehiculo vehiculo = _mapper.Map<VehiculoDto, Vehiculo>(taller.vehiculo);
                _dbContext.Vehiculos.Add(vehiculo);
                _dbContext.SaveChanges();

                if (AutomovilDtoTieneDatos(taller.automovil))
                {
                    taller.automovil.IdVehiculo = vehiculo.Id;
                    Automovil automovil = _mapper.Map<AutomovilDto, Automovil>(taller.automovil);
                    _dbContext.Automovils.Add(automovil);
                }
                if (MotoDtoTieneDatos(taller.moto))
                {
                    taller.moto.IdVehiculo = vehiculo.Id;
                    Moto moto = _mapper.Map<MotoDto, Moto>(taller.moto);
                    _dbContext.Motos.Add(moto);
                }

                if (taller.presupuesto != null)
                {
                    taller.presupuesto.Total = taller.CostoTotal;
                    taller.presupuesto.IdVehiculo = vehiculo.Id;
                    Presupuesto presupuesto = _mapper.Map<PresupuestoDto, Presupuesto>(taller.presupuesto);
                    _dbContext.Presupuestos.Add(presupuesto);
                    _dbContext.SaveChanges();

                    if (taller.desperfecto != null)
                    {
                        taller.desperfecto.IdPresupuesto = presupuesto.Id;
                        Desperfecto desperfecto = _mapper.Map<DesperfectoDto, Desperfecto>(taller.desperfecto);
                        _dbContext.Desperfectos.Add(desperfecto);

                    }
                }
            }
            foreach (var irepuesto in taller.repuestos)
            {
                Repuesto repuesto = _mapper.Map<RepuestoDto, Repuesto>(irepuesto);
                _dbContext.Repuestos.Add(repuesto);
            }
            _dbContext.SaveChanges();
        }
        private bool MotoDtoTieneDatos(MotoDto moto)
        {
            return moto != null && !string.IsNullOrEmpty(moto.Cilindrada);
        }
        private bool AutomovilDtoTieneDatos(AutomovilDto automovilDto)
        {
            return automovilDto != null && automovilDto.Tipo.HasValue;
        }

    }
}
