using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IPartnerUserService : IService<PartnerUserDomain>
    {
        PartnerUserDomain GetById(string id);
    }
}
