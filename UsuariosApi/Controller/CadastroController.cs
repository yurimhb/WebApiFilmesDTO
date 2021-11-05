using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Request;

namespace UsuariosApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            this.cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CriarUsuario(CreateUsuarioDto createUsuarioDto) 
        {
            var usuario = cadastroService.CadastraUsuario(createUsuarioDto);

            if (usuario.IsFailed)
                return StatusCode(500);
            return Ok(usuario.Successes[0]);
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery]AtivaContaRequest ativaContaRequest) 
        {
            Result result = cadastroService.AtivaContaUsuario(ativaContaRequest);
            if (result.IsFailed)
                return StatusCode(500);
            return Ok(result);
        }

    }
}
