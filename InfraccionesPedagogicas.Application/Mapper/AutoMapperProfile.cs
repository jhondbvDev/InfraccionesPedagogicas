using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Sala, CreateSalaDTO>().ReverseMap();
            CreateMap<Sala, UpdateSalaDTO>().ReverseMap();
            CreateMap<Sala, SalaDTO>().ReverseMap();

        }
    }
}
