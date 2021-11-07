
using AutoMapper;
using FilmesApi.Data;
using Services;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService filmeService;

        public FilmeController(FilmeService filmeService = null)
        {
            this.filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = filmeService.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? Classficacao)
        {
            var lstFilme = filmeService.RecuperaFilme(Classficacao);

            if (lstFilme == null)
                return NotFound();
            return Ok(lstFilme);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto filme = filmeService.RecuperaFilmePorId(id);

            if (filme == null)
                return NotFound();
            return Ok(filme);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = filmeService.AtualizaFilme(filmeDto, id);

            if (resultado.IsFailed)
                return NoContent();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = filmeService.DeletaFilme(id);

            if (resultado.IsFailed)
                return NotFound();
            return NoContent();
        }

    }
}