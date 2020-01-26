using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>, IRepositoryEager<Comment>
    {
    }
}
