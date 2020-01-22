using DAL.Context;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class IdentityRoleRepository : RepositoryBase<IdentityRole>, IIdentityRoleRepository
    {
        public IdentityRoleRepository(MinusContext context) : base(context)
        {

        }
    }
}
