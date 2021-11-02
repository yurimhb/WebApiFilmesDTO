using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService logoutService;

        public LogoutController(LogoutService logoutService)
        {
            this.logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario() 
        {
            Result result = logoutService.DeslogarUsuario();
            if (result.IsFailed)
                return Unauthorized();
            return Ok();
        }
    }
}
