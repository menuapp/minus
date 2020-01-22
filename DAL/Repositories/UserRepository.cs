using DAL.Context;
using DAL.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : RepositoryBase<Customer>, IUserRepository, IRepositoryEager<Customer>
    {
        private MinusContext minusContext;
        public UserRepository(MinusContext context) : base(context)
        {
            this.minusContext = context;
        }

        public IEnumerable<Customer> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public Customer GetByIdEagerly(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetManyEagerly(Expression<Func<Customer, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
