
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITableRepository : IRepository<Counter, int>, IRepositoryEager<Counter, int>
    {
    }
}
