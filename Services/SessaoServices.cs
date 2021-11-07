using AutoMapper;
using Contracts.Model;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class SessaoServices
    {
        private readonly ISessaoRepository sessaoRepository;
        private readonly IMapper mapper;

        public SessaoServices(IMapper mapper, ISessaoRepository sessaoRepository)
        {
            this.mapper = mapper;
            this.sessaoRepository = sessaoRepository;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto createSessaoDto)
        {
            Sessao sessao = mapper.Map<Sessao>(createSessaoDto);
            sessaoRepository.Add(sessao);
            sessaoRepository.SaveChanges();
            return mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            var sessao = sessaoRepository.FirstOrDefault(x => x.Id == id);
            return mapper.Map<ReadSessaoDto>(sessao);

        }

        public Result AtualizaSessao(int id, UpdateSessaoDto sessaoDto)
        {
            var sessao = sessaoRepository.FirstOrDefault(x => x.Id == id);
            if (sessao == null)
                return Result.Fail("Sessão não localizado");

            mapper.Map(sessaoDto, sessao);
            sessaoRepository.SaveChanges();
            return Result.Ok();

        }
    }
}
