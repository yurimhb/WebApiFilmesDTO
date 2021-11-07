using Contracts.Model;
using FilmesApi.Data;
using FilmesApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Repository
{
    public class GerenteRepository : RepositoryBase<Gerente>, IGerenteRepository
    {
        public GerenteRepository(FilmeContext filmeContext) : base(filmeContext)
        {
        }
    }
}
