using AutoMapper;
using Contracts;
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
    public class CinemaService
    {
        private readonly ICinemaRepository cinemaRepository;
        private IMapper _mapper;

        public CinemaService(IMapper mapper, ICinemaRepository cinemaRepository)
        {
            _mapper = mapper;
            this.cinemaRepository = cinemaRepository;
        }

        public ReadCinemaDto AdicionarCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            cinemaRepository.Add(cinema);
            cinemaRepository.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas;

            if (!String.IsNullOrEmpty(nomeDoFilme))
                cinemas = cinemaRepository.FindByCondition(x => x.Sessoes.Where(z => z.Filme.Titulo.Contains(nomeDoFilme)).ToList().Count > 0);
            else
                cinemas = cinemaRepository.FindAll();

            if(cinemas.Count>0)
                return _mapper.Map<List<ReadCinemaDto>>(cinemas);
            return null;
        }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            Cinema cinema = cinemaRepository.FindAll().FirstOrDefault(cinema => cinema.Id == id);
            
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }
            return null;
        }

        public Result AtualizarCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = cinemaRepository.FindAll().FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema nao enconrtado");
            }
            _mapper.Map(cinemaDto, cinema);
            cinemaRepository.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            Cinema cinema = cinemaRepository.FindAll().FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado") ;
            }
            cinemaRepository.Remove(cinema);
            cinemaRepository.SaveChanges();
            return Result.Ok();
        }
    }
}
