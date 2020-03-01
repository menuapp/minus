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
    public class PartnerRepository : RepositoryBase<Partner, int>, IPartnerRepository
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
            return dbSet.Include(p => p.ProductCategories).Include(p => p.Orders).Include(p => p.Counters).Include(p => p.Contents).FirstOrDefault(p => p.Id == id);
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
