using DAL.Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class CommentRepository
    {
        public MinusContext context { get; set; }
        public CommentRepository(MinusContext context)
        {
            this.context = context;
        }

        public Comment GetById(int id)
        {
            return context.Comments.Find(id);
        }

        public ICollection<Comment> GetAll()
        {
            return context.Comments.ToList();
        }
    }
}
