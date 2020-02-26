using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Interfaces
{
    public interface IService<T,Tid>
    {
        IEnumerable<T> GetAll();
        bool Add(T domain);
        T GetById(Tid id);
        bool Delete(T domain);
        void Update(T domain);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

    }
}
