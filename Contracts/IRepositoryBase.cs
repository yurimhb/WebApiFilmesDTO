using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> FindAll(); 
        List<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        void Add(T entity); 
        void Update(T entity); 
        void Remove(T entity);
        void SaveChanges();
    }
}
