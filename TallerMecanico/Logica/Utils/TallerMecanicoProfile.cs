using AutoMapper;
using TallerMecanico.Dtos;
using TallerMecanico.Modelos;

namespace TallerMecanico.Logica.Utils
{
    // Crea un perfil de AutoMapper (si no lo tienes)
    public class TallerMecanicoProfile : Profile
    {
        public TallerMecanicoProfile()
        {
            CreateMap<AutomovilDto, Automovil>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.IdVehiculo, opt => opt.MapFrom(src => src.IdVehiculo)) // Mapea la propiedad IdVehiculo
                 .ForMember(dest => dest.CantidadPuertas, opt => opt.MapFrom(src => src.CantidadPuertas)) // Mapea la propiedad CantidadPuertas
                 .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo)); // Mapea la propiedad Tipo

            // Agrega más mapeos según tus necesidades
            CreateMap<VehiculoDto, Vehiculo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());// Ignora la propiedad Id

            //CreateMap<ClienteDto, Cliente>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora la propiedad Id

            CreateMap<DesperfectoDto, Desperfecto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora la propiedad Id

            CreateMap<MotoDto, Moto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora la propiedad Id
                .ForMember(dest => dest.IdVehiculo, opt => opt.Ignore()); // Ignora la propiedad IdVehiculo

            CreateMap<PresupuestoDto, Presupuesto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.IdVehiculo, opt => opt.MapFrom(src => src.IdVehiculo));


            CreateMap<RepuestoDto, Repuesto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora la propiedad Id

        }
    }

}
