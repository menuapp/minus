using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T, Tid>
    {
        void Add(T entity);
        void Update(T entity);
        bool Delete(T entity);

        T GetById(Tid id);
        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
