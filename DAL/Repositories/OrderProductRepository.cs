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
    public class OrderProductRepository : RepositoryBase<OrderProduct>
    {
        public OrderProductRepository(MinusContext context) : base(context)
        {

        }
    }
}
