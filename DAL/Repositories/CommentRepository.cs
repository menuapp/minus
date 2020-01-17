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
    public class CommentRepository : RepositoryBase<Comment>, IRepositoryEager<Comment>
    {
        public CommentRepository(MinusContext context) : base(context)
        {

        }

        public IEnumerable<Comment> GetAllEagerly()
        {
            return dbSet.Include(commment => commment.User).ToList();
        }

        public Comment GetByIdEagerly(int id)
        {
            return dbSet.Include(comment => comment.User).FirstOrDefault(comment => comment.Id == id);
        }

        public IEnumerable<Comment> GetManyEagerly(Expression<Func<Comment, bool>> where)
        {
            return dbSet.Include(comment => comment.User).Where(where).ToList();
        }
    }
}
