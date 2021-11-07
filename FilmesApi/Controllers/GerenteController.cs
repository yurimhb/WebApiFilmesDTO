using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Model;
using Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            this.gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto createGerenteDto)
        {
            ReadGerenteDto readGerenteDto = gerenteService.AdicionarGerente(createGerenteDto);
            return CreatedAtAction(nameof(RecuperarGerente), new { Id = readGerenteDto.Id }, readGerenteDto);
        }

        [HttpGet]
        public IEnumerable<Gerente> ListarGerentes()
        {
            return gerenteService.ListarGerente();
        }


        [HttpGet("{id}")]
        public IActionResult RecuperarGerente(int id)
        {
            ReadGerenteDto readGerenteDto = gerenteService.RecuperarGerente(id);

            if (readGerenteDto == null)
                return NotFound();
            return Ok(readGerenteDto);

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result result = gerenteService.DeletaGerente(id);

            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
