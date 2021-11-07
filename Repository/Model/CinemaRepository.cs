using Contracts;
using FilmesApi.Data;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmesApi.Repository
{
    public class CinemaRepository : RepositoryBase<Cinema>, ICinemaRepository
    {
        public CinemaRepository(FilmeContext filmeContext) : base(filmeContext)
        {

        }
    }
}
