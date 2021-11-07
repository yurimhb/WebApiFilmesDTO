using AutoMapper;
using Contracts.Model;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class EnderecoService
    {
        private readonly IEnderecoRepository enderecoRepository;
        private IMapper _mapper;

        public EnderecoService(IMapper mapper, IEnderecoRepository enderecoRepository)
        {
            _mapper = mapper;
            this.enderecoRepository = enderecoRepository;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            enderecoRepository.Add(endereco);
            enderecoRepository.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperaFilmes()
        {
            var enderecos = enderecoRepository;
            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }

        public ReadEnderecoDto RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = enderecoRepository.FirstOrDefault(end => end.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto filmeDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return filmeDto;
            }
            return null;
        }

        public Result AtualizaEndereco(UpdateEnderecoDto enderecoDto, int id)
        {
            Endereco endereco = enderecoRepository.FirstOrDefault(end => end.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não localizado");
            }
            _mapper.Map(enderecoDto, endereco);
            enderecoRepository.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            Endereco endereco = enderecoRepository.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não localizado");
            }
            enderecoRepository.Remove(endereco);
            enderecoRepository.SaveChanges();
            return Result.Ok();
        }
    }
}
