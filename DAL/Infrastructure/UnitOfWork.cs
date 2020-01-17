using DAL.Context;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private MinusContext minusContext { get; set; }
        public UnitOfWork(MinusContext minusContext)
        {
            this.minusContext = minusContext;
        }
        public void Commit()
        {
            minusContext.SaveChanges();
        }
    }
}
