using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IPartnerService : IService<PartnerDomain, int>, IServiceEager<PartnerDomain, int>
    {
    }
}
