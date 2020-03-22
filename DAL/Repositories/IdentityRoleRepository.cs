using DAL.Context;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class IdentityRoleRepository : RepositoryBase<IdentityRole, int>, IIdentityRoleRepository
    {
        public IdentityRoleRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<IdentityRole> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public IdentityRole GetByIdEagerly(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityRole GetByIdEagerly(string id)
        {
            throw new NotImplementedException();
        }

        public IdentityRole GetByProp(Expression<Func<IdentityRole, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentityRole> GetManyEagerly(Expression<Func<IdentityRole, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
