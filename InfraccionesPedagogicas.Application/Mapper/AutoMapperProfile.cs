using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Sala, CreateSalaDTO>().ReverseMap();
            CreateMap<Sala, UpdateSalaDTO>().ReverseMap();
            CreateMap<Sala, SalaDTO>()
                .ForMember(dto => dto.NombreUsuario,
                e => e.MapFrom(u => (u.Usuario != null)? u.Usuario.Nombre:string.Empty))
                .ReverseMap();

            CreateMap<DatosInfractor, CreateDatosInfractorDTO>().ReverseMap();
            CreateMap<DatosInfractor, UpdateDatosInfractorDTO>().ReverseMap();
            CreateMap<DatosInfractor, DatosInfractorDTO>().ReverseMap();

            CreateMap<Infraccion, InfraccionDTO>().ReverseMap();

            CreateMap<Asistencia, CreateAsistenciaDTO>().ReverseMap();
            CreateMap<Asistencia, UpdateAsistenciaDTO>().ReverseMap();
            CreateMap<Asistencia, AsistenciaDTO>().ReverseMap();

            CreateMap<Infractor, InfractorDTO>().ReverseMap();
        }
    }
}
