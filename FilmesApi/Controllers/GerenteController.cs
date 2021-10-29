using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly FilmeContext filmeContext;
        private readonly IMapper mapper;

        public GerenteController(FilmeContext filmeContext, IMapper mapper)
        {
            this.filmeContext = filmeContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody]CreateGerenteDto createGerenteDto) 
        {
            var gerente = mapper.Map<Gerente>(createGerenteDto);
            filmeContext.Gerentes.Add(gerente);
            filmeContext.SaveChanges();

            return CreatedAtAction(nameof(RecuperarGerente), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IEnumerable<Gerente> ListarGerentes()
        {
            return filmeContext.Gerentes;

        }


        [HttpGet("{id}")]
        public IActionResult RecuperarGerente(int id)
        {
            var gerente = filmeContext.Gerentes.FirstOrDefault(x => x.Id == id);

            if (gerente==null)
                return NotFound();

            ReadGerenteDto dto = mapper.Map<ReadGerenteDto>(gerente);
            return Ok(dto);

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Gerente gerente = filmeContext.Gerentes.FirstOrDefault(filme => filme.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }

            filmeContext.Remove(gerente);
            filmeContext.SaveChanges();

            return NoContent();
        }
    }
}
