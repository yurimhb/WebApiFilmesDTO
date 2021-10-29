using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Services
{
    public class EnderecoService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperaFilmes()
        {
            var enderecos = _context.Enderecos;
            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }

        public ReadEnderecoDto RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(end => end.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto filmeDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return filmeDto;
            }
            return null;
        }

        internal Result AtualizaEndereco(UpdateEnderecoDto enderecoDto, int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(end => end.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não localizado");
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        internal Result DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não localizado");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
