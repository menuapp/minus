using DAL.Context;
using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class TableRepository : RepositoryBase<Counter, int>, ITableRepository
    {
        public TableRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<Counter> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public Counter GetByIdEagerly(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Counter> GetManyEagerly(Expression<Func<Counter, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
