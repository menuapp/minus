using DAL.Context;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class RepositoryBase<T,Tid> where T : class
    {
        internal DbSet<T> dbSet { get; set; }
        public RepositoryBase(MinusContext context)
        {
            this.dbSet = context.Set<T>();
        }
        public T GetById(Tid id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            var a = dbSet.ToList();
            return dbSet.ToList();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            EntityEntry result = dbSet.Attach(entity);
        }

        public bool Delete(T entity)
        {
            EntityEntry result = dbSet.Remove(entity);

            return result.State == EntityState.Deleted ? true : false;
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }
    }
}
