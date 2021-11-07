using AutoMapper;
using Contracts.Model;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class GerenteService
    {
        private readonly IGerenteRepository gerenteRepository;
        private readonly IMapper mapper;

        public GerenteService(IMapper mapper, IGerenteRepository gerenteRepository)
        {
            this.mapper = mapper;
            this.gerenteRepository = gerenteRepository;
        }

        public ReadGerenteDto AdicionarGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = mapper.Map<Gerente>(createGerenteDto);
            gerenteRepository.Add(gerente);
            gerenteRepository.SaveChanges();
            return mapper.Map<ReadGerenteDto>(gerente);

        }

        public IEnumerable<Gerente> ListarGerente()
        {
            return gerenteRepository.FindAll();
        }

        public ReadGerenteDto RecuperarGerente(int id)
        {
            var gerente = gerenteRepository.FirstOrDefault(x => x.Id == id);

            if (gerente != null)
                return mapper.Map<ReadGerenteDto>(gerente);
            return null;
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = gerenteRepository.FirstOrDefault(filme => filme.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Gerente nçao localizado");
            }

            gerenteRepository.Remove(gerente);
            gerenteRepository.SaveChanges();
            return Result.Ok();
        }
    }
}
