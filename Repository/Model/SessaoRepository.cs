using Contracts.Model;
using FilmesApi.Data;
using FilmesApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Repository
{
    public class SessaoRepository : RepositoryBase<Sessao>, ISessaoRepository
    {
        public SessaoRepository(FilmeContext filmeContext) : base(filmeContext)
        {
        }
    }
}
