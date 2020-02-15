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
    public class UserRepository : RepositoryBase<ApplicationUser, string>, IUserRepository, IRepositoryEager<ApplicationUser, string>
    {
        public UserRepository(MinusContext context) : base(context)
        {
        }

        public IEnumerable<ApplicationUser> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetByIdEagerly(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetManyEagerly(Expression<Func<ApplicationUser, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
