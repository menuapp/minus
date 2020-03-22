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
    public class CommentRepository : RepositoryBase<Comment, int>, IRepositoryEager<Comment, int>
    {
        public CommentRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<Comment> GetAllEagerly()
        {
            return dbSet.Include(commment => commment.Customer).ToList();
        }

        public Comment GetByIdEagerly(int id)
        {
            return dbSet.Include(comment => comment.Customer).FirstOrDefault(comment => comment.Id == id);
        }

        public Comment GetByIdEagerly(string id)
        {
            throw new NotImplementedException();
        }

        public Comment GetByProp(Expression<Func<Comment, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetManyEagerly(Expression<Func<Comment, bool>> where)
        {
            return dbSet.Include(comment => comment.Customer).Where(where).ToList();
        }
    }
}
