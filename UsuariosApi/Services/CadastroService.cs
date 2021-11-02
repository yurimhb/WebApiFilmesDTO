using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UsuariosApi.Models;

namespace UsuariosApi.Controller
{
    public class CadastroService
    {
        private IMapper mapper;
        private UserManager<IdentityUser<int>> userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            Usuario usuario = mapper.Map<Usuario>(createUsuarioDto);
            IdentityUser<int> identityUser = mapper.Map<IdentityUser<int>>(usuario);

            System.Threading.Tasks.Task<IdentityResult> resultadoIdentity = userManager.CreateAsync(identityUser,createUsuarioDto.Password);

            if (resultadoIdentity.Result.Succeeded)
                return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");

        }
    }
}