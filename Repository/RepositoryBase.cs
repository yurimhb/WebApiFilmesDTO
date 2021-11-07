using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmesApi.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FilmeContext filmeContext;
        private readonly DbSet<T> table;

        public RepositoryBase(FilmeContext filmeContext)
        {
            this.filmeContext = filmeContext;
            table = filmeContext.Set<T>();
        }

        public void Add(T entity)
        {
            filmeContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            filmeContext.Set<T>().Remove(entity);
        }

        public List<T> FindAll()
        {
            return table.ToList();
        }

        public List<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).ToList();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).FirstOrDefault();
        }

        public void Update(T entity)
        {
            filmeContext.Set<T>().Update(entity);
        }

        public void SaveChanges()
        {
            filmeContext.SaveChanges();
        }
    }
}
