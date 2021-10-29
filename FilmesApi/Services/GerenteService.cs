using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Services
{
    public class GerenteService
    {
        private readonly FilmeContext filmeContext;
        private readonly IMapper mapper;

        public GerenteService(FilmeContext filmeContext, IMapper mapper)
        {
            this.filmeContext = filmeContext;
            this.mapper = mapper;
        }

        public ReadGerenteDto AdicionarGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = mapper.Map<Gerente>(createGerenteDto);
            filmeContext.Gerentes.Add(gerente);
            filmeContext.SaveChanges();
            return mapper.Map<ReadGerenteDto>(gerente);

        }

        public IEnumerable<Gerente> ListarGerente()
        {
            return filmeContext.Gerentes;
        }

        public ReadGerenteDto RecuperarGerente(int id)
        {
            var gerente = filmeContext.Gerentes.FirstOrDefault(x => x.Id == id);

            if (gerente != null)
                return mapper.Map<ReadGerenteDto>(gerente);
            return null;
        }

        internal Result DeletaGerente(int id)
        {
            Gerente gerente = filmeContext.Gerentes.FirstOrDefault(filme => filme.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Gerente nçao localizado");
            }

            filmeContext.Remove(gerente);
            filmeContext.SaveChanges();
            return Result.Ok();
        }
    }
}
