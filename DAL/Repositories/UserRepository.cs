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
    public class UserRepository : IUserRepository, IRepositoryEager<User>
    {
        private MinusContext minusContext;
        public UserRepository(MinusContext context)
        {
            this.minusContext = context;
        }

        public void Add(User entity)
        {
            minusContext.Users.Add(entity);
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return minusContext.Users.ToList();
        }

        public IEnumerable<User> GetAllEagerly()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByIdEagerly(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetMany(Expression<Func<User, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetManyEagerly(Expression<Func<User, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
