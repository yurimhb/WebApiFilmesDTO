using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<UpdateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(s => s.HorarioDeInicio, opt => opt
                 .MapFrom(s => s.HorarioDeEncerramento.AddMinutes(s.Filme.Duracao * (-1)))
                );
        }
    }
}
