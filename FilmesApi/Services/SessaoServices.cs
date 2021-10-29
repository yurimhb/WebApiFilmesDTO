using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Services
{
    public class SessaoServices
    {
        private readonly FilmeContext filmeContext;
        private readonly IMapper mapper;

        public SessaoServices(FilmeContext filmeContext, IMapper mapper)
        {
            this.filmeContext = filmeContext;
            this.mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto createSessaoDto)
        {
            Sessao sessao = mapper.Map<Sessao>(createSessaoDto);
            filmeContext.Sessoes.Add(sessao);
            filmeContext.SaveChanges();
            return mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            var sessao = filmeContext.Sessoes.FirstOrDefault(x => x.Id == id);
            return mapper.Map<ReadSessaoDto>(sessao);

        }

        internal Result AtualizaSessao(int id, UpdateSessaoDto sessaoDto)
        {
            var sessao = filmeContext.Sessoes.FirstOrDefault(x => x.Id == id);
            if (sessao == null)
                return Result.Fail("Sessão não localizado");

            mapper.Map(sessaoDto, sessao);
            filmeContext.SaveChanges();
            return Result.Ok();

        }
    }
}
