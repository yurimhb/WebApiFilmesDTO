using FilmesApi.Data.Dtos.Sessao;
using Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {

        private SessaoServices sessaoServices;

        public SessaoController(SessaoServices sessaoServices)
        {
            this.sessaoServices = sessaoServices;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto createSessaoDto)
        {
            ReadSessaoDto readSessaoDto = sessaoServices.AdicionaSessao(createSessaoDto);

            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readSessaoDto.Id }, readSessaoDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto readSessaoDto = sessaoServices.RecuperaSessaoPorId(id);

            if (readSessaoDto == null)
                return NotFound();

            return Ok(readSessaoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Result result = sessaoServices.AtualizaSessao(id, sessaoDto);

            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
