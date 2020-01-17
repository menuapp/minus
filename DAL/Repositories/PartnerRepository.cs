using DAL.Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class PartnerRepository : RepositoryBase<Partner>
    {
        public PartnerRepository(MinusContext context) : base(context)
        {

        }
    }
}
