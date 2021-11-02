using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult CriarUsuario(CreateUsuarioDto createUsuarioDto) 
        {
            var usuario = cadastroService.CadastraUsuario(createUsuarioDto);

            if (usuario.IsFailed)
                return NoContent();
            return Ok();
        }
    }
}
