using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Model;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller
    {

        private EnderecoService enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            this.enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readEnderecoDto = enderecoService.AdicionaEndereco(enderecoDto);

            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readEnderecoDto.Id }, readEnderecoDto);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaFilmes()
        {
            return enderecoService.RecuperaFilmes();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDto readEnderecoDto = enderecoService.RecuperaEnderecosPorId(id);
            if(readEnderecoDto==null)
                return NotFound();
            return Ok(readEnderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result = enderecoService.AtualizaEndereco(enderecoDto, id);

            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result result = enderecoService.DeletaEndereco(id);

            if (result.IsFailed)
                return NotFound();
            return NoContent();
        }
    }
}
