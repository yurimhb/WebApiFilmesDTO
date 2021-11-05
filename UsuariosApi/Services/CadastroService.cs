using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Web;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Controller
{
    public class CadastroService
    {
        private IMapper mapper;
        private UserManager<IdentityUser<int>> userManager;
        private readonly EmailService emailservice;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailservice)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.emailservice = emailservice;
        }

        public Result CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            Usuario usuario = mapper.Map<Usuario>(createUsuarioDto);
            IdentityUser<int> identityUser = mapper.Map<IdentityUser<int>>(usuario);

            System.Threading.Tasks.Task<IdentityResult> resultadoIdentity = userManager.CreateAsync(identityUser, createUsuarioDto.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                var code = userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                var encodeCode = HttpUtility.UrlEncode(code.Result);
                emailservice.EnviarEmail(new[] { identityUser.Email }, "Link de Ativação", identityUser.Id, encodeCode);

                return Result.Ok().WithSuccess(code.Result);
            }
            return Result.Fail("Falha ao cadastrar usuário");

        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = userManager.Users.FirstOrDefault(x => x.Id == request.Id);
            var identityResult = userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao);

            if (identityResult.IsCompleted)
                return Result.Ok();
            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}