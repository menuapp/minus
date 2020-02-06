using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPartnerUserRepository : IRepository<PartnerUser>, IRepositoryEager<PartnerUser>
    {
    }
}
