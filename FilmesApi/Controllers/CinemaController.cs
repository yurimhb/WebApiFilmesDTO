using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readCinemaDto = cinemaService.AdicionarCinema(cinemaDto);

            if (readCinemaDto == null)
                NotFound();
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readCinemaDtos = cinemaService.RecuperaCinemas(nomeDoFilme);

            if (readCinemaDtos == null)
                return NotFound();
            return Ok(readCinemaDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readCinemaDto = cinemaService.RecuperaCinemasPorId(id);

            if (readCinemaDto == null)
                return NotFound();
            return Ok(readCinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = cinemaService.AtualizarCinema(id,cinemaDto);

            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result result = cinemaService.DeletaCinema(id);

            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

    }
}
