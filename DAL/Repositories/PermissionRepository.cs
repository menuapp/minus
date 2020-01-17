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
    public class PermissionRepository : RepositoryBase<Permission>, IRepositoryEager<Permission>
    {
        public PermissionRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<Permission> GetAllEagerly()
        {
            return dbSet.Include(permission => permission.RolePermissions.Select(rolePermission => rolePermission.Role)).ToList();
        }

        public Permission GetByIdEagerly(int id)
        {
            return dbSet.Include(permission => permission.RolePermissions.Select(rolePermission => rolePermission.Role))
                .Single(permission => permission.Id == id);
        }

        public IEnumerable<Permission> GetManyEagerly(Expression<Func<Permission, bool>> where)
        {
            return dbSet.Include(permission => permission.RolePermissions.Select(rolePermission => rolePermission.Role)).Where(where).ToList();
        }
    }
}
