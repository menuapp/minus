using DAL.Context;
using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class RolePermissionRepository : RepositoryBase<RolePermission>
    {
        public RolePermissionRepository(MinusContext context) : base(context)
        {

        }
    }
}
