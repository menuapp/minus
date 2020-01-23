using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepositoryEager<T>
    {
        IEnumerable<T> GetAllEagerly();
        IEnumerable<T> GetManyEagerly(Expression<Func<T, bool>> where);
        T GetByIdEagerly(int id);
    }
}
