using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        bool Delete(T entity);

        T GetById(int id);
        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany();
    }
}
