using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
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
    public class SessaoController : ControllerBase
    {
        private readonly FilmeContext filmeContext;
        private readonly IMapper mapper;

        public SessaoController(FilmeContext filmeContext, IMapper mapper)
        {
            this.filmeContext = filmeContext;
            this.mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto createSessaoDto) 
        {
            Sessao sessao = mapper.Map<Sessao>(createSessaoDto);
            filmeContext.Sessoes.Add(sessao);
            filmeContext.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            var sessao = filmeContext.Sessoes.FirstOrDefault(x => x.Id == id);
            var sessaodto = mapper.Map<ReadSessaoDto>(sessao);

            if (sessao == null)
                return NotFound();

            return Ok(sessaodto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, [FromBody]UpdateSessaoDto sessaoDto)
        {
            var sessao = filmeContext.Sessoes.FirstOrDefault(x => x.Id == id);
            if (sessao == null)
                return NotFound();

            mapper.Map(sessaoDto, sessao);
            filmeContext.SaveChanges();

            return NoContent();
        }
    }
}
