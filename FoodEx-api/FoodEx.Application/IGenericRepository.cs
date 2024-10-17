using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            string includeProperties = "");

        Task<T> FindById(object id);
        
        Task<T> Insert(T entity);
        Task Delete(T entity);
        Task Delete(object id);
        Task Update(T entity);

        Task<List<T>> FindAll();
    }
}
