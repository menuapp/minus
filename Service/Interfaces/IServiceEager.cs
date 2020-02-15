using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Interfaces
{
    public interface IServiceEager<T, Tid>
    {
        IEnumerable<T> GetAllEagerly();
        IEnumerable<T> GetManyEagerly(Expression<Func<T, bool>> where);
        T GetByIdEagerly(Tid id);
    }
}
