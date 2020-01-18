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
    public class UserRepository : RepositoryBase<User>, IUserRepository, IRepositoryEager<User>
    {
        private MinusContext minusContext;
        public UserRepository(MinusContext context) : base(context)
        {
            this.minusContext = context;
        }

        public IEnumerable<User> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public User GetByIdEagerly(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetManyEagerly(Expression<Func<User, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
