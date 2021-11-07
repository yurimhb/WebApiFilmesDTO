using AutoMapper;
using Contracts.Model;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class FilmeService
    {
        private readonly IFilmeRepository filmeRepository;
        private IMapper _mapper;

        public FilmeService(IMapper mapper, IFilmeRepository filmeRepository)
        {
            _mapper = mapper;
            this.filmeRepository = filmeRepository;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            filmeRepository.Add(filme);
            filmeRepository.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilme(int? classficacao)
        {
            List<Filme> filmes;

            if (classficacao == null)
                filmes = filmeRepository.FindAll();
            else
                filmes = filmeRepository.FindByCondition(x => x.ClassificacaoEtaria <= classficacao).ToList();

            if (filmes != null)
            {
                List<ReadFilmeDto> filmeDtos = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return filmeDtos;
            }

            return null;
        }

        public ReadFilmeDto RecuperaFilmePorId(int id)
        {
            Filme filme = filmeRepository.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return filmeDto;
            }
            return null;
        }

        public Result AtualizaFilme(UpdateFilmeDto filmeDto, int id)
        {
            Filme filme = filmeRepository.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _mapper.Map(filmeDto, filme);
            filmeRepository.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            Filme filme = filmeRepository.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Erro ao deletar filme");
            }
            filmeRepository.Remove(filme);
            filmeRepository.SaveChanges();
            return Result.Ok();
        }
    }
}
