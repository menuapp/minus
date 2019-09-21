using DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Infrastructure
{
    class DBFactory : IDisposable
    {
        public MinusContext _dbContext;

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public MinusContext Init()
        {
            return _dbContext ?? (_dbContext = new MinusContext());
        }
    }
}
