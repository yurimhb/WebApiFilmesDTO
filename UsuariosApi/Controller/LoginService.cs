using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using UsuariosApi.Data.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controller
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> signManager;
        private TokenService tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signManager, TokenService tokenService)
        {
            this.signManager = signManager;
            this.tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest request) 
        {
            var resultado = signManager.PasswordSignInAsync(request.UserName, request.Password,false,false);
            if (resultado.Result.Succeeded)
            {
                var identityUser = signManager
                    .UserManager
                    .Users
                    .FirstOrDefault(u => u.NormalizedUserName.Equals(request.UserName.ToUpper()));

                var token = tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Falhou");
        }
    }
}