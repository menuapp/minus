using DAL.Context;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Infrastructure
{
    class UnitOfWork : IUnitOfWork
    {
        private DBFactory dbFactory { get; set; }
        public UnitOfWork(IDBFactory dBFactory)
        {
            dbFactory = dbFactory;
        }
        public void Commit()
        {
            dbFactory._dbContext.Commit();
        }
    }
}
