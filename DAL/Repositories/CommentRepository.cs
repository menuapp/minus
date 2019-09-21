using DAL.Context;
using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class CommentRepository: IRepository<Comment>
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

        public IEnumerable<Comment> GetAll()
        {
            return context.Comments.ToList();
        }

        public void Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetMany()
        {
            throw new NotImplementedException();
        }
    }
}
