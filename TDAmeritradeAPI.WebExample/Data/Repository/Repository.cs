using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using TDAmeritradeAPI.WebExample.Data.IRepository;

namespace TDAmeritradeAPI.WebExample.Data.Repository
{
    public class Repository<Type> : IRepository<Type> where Type: class
    {
        protected readonly DbContext Context;
        internal DbSet<Type> dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<Type>();
        }


        public Type Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<Type> GetAll(Expression<Func<Type, bool>> filter = null, Func<IQueryable<Type>, IOrderedQueryable<Type>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Type> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var x in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(x);
                }
            }

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }

        public Type GetFirstOrDefault(Expression<Func<Type, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<Type> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var x in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(x);
                }
            }

            return query.FirstOrDefault();
        }

        public void Add(Type entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(int id)
        {
            var entityToRemove = dbSet.Find(id);
            Remove(entityToRemove);
        }

        public void Remove(Type entity)
        {
            dbSet.Remove(entity);
        }
    }
}
