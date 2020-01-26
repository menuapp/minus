using DAL.Context;
using DAL.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class PartnerUserRepository : RepositoryBase<PartnerUser>, IPartnerUserRepository
    {
        public PartnerUserRepository(MinusContext context) : base(context)
        {

        }
        public IEnumerable<PartnerUser> GetAllEagerly()
        {
            return dbSet.Include(src => src.Partner).ToList();
        }

        public PartnerUser GetByIdEagerly(string id)
        {
            return dbSet.Include(a => a.Partner).Single(a => a.Id == id);
        }

        public PartnerUser GetByIdEagerly(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PartnerUser> GetManyEagerly(Expression<Func<PartnerUser, bool>> where)
        {
            return dbSet.Include(a => a.Partner).Where(where).ToList();
        }
    }
}
