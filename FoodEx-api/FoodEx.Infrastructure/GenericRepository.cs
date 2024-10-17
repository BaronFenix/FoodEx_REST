using FoodEx.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Infrastructure
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<T> FindById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<T> Insert(T entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Delete(object id)
        {
            T entity = dbSet.Find(id);
            await Delete(entity);
        }

        public virtual async Task Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> FindAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            string includeProperties = ""
            )
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);
            return OrderBy != null
                ? await OrderBy(query).ToListAsync()
                : await query.ToListAsync();
        }
    }
}
