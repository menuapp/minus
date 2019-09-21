using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class UserRepository : IRepository<User>
    {
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetMany()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
