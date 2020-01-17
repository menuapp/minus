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
    public class RoleRepository : RepositoryBase<Role>, IRepositoryEager<Role>
    {
        public RoleRepository(MinusContext context) : base(context) { }

        public IEnumerable<Role> GetAllEagerly()
        {
            return dbSet.Include(role => role.RolePermissions).ToList();
        }

        public Role GetByIdEagerly(int id)
        {
            return dbSet.Include(role => role.RolePermissions).Single(role => role.Id == id);
        }

        public IEnumerable<Role> GetManyEagerly(Expression<Func<Role, bool>> where)
        {
            return dbSet.Include(role => role.RolePermissions.Select(rolePermission => rolePermission.Permission))
                .Where(where);
        }
    }
}
