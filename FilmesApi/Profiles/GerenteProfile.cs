using AutoMapper;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(g => g.Cinemas, opts => opts
                 .MapFrom(g => g.Cinemas.Select(ci => new { ci.Id, ci.Nome, ci.Endereco, ci.EnderecoId })
                 )
                );
        }
    }
}
