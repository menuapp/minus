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
                Product newProduct = new Product()
                {
                    Name = "asd",
                    Rating = 3.4,

                };
                ctx.Products.Add(newProduct);
                ctx.SaveChanges();
            }
        }
    }
}
