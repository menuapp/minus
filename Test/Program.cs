using System;
using Entity;
using DAL.Context;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MinusContext())
            {
                ctx.Database.EnsureCreated();
                ctx.SaveChanges();
            }
        }
    }
}
