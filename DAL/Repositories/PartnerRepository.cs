using DAL.Context;
using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class PartnerRepository : RepositoryBase<Partner>, IPartnerRepository
    {
        public PartnerRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<Partner> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public Partner GetByIdEagerly(int id)
        {
            throw new NotImplementedException();
        }

        public Partner GetByIdEagerly(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Partner> GetManyEagerly(Expression<Func<Partner, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
