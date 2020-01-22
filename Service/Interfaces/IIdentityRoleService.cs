using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IIdentityRoleService
    {
        IEnumerable<IdentityRoleDomain> ListRoles();
        bool AddRole(IdentityRoleDomain identityRoleDomain);
        IdentityRoleDomain GetRole(int id);
        bool Delete(IdentityRoleDomain identityRoleDomain);
        void Update(IdentityRoleDomain identityRoleDomain);
    }
}
