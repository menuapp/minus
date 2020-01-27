using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPartnerRepository : IRepository<Partner>, IRepositoryEager<Partner>
    {
    }
}
