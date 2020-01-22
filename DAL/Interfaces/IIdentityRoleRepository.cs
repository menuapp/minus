using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IIdentityRoleRepository : IRepository<IdentityRole>
    {
    }
}
