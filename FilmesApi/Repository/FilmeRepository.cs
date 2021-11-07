using Contracts.Model;
using FilmesApi.Data;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Repository
{
    public class FilmeRepository : RepositoryBase<Filme>, IFilmeRepository
    {
        public FilmeRepository(FilmeContext filmeContext) : base(filmeContext)
        {
        }
    }
}
