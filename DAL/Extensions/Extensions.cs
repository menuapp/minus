using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Extensions
{
    public static class Extensions
    {
        public static void SeedEnumValues<T, TEnum>(this DbSet<T> dbSet, Func<TEnum, T> converter)
        where T : class
        {
            Enum.GetValues(typeof(TEnum))
                 .Cast<object>()
                 .Select(value => converter((TEnum)value))
                 .ToList()
                 .ForEach(instance => dbSet.Add(instance));
        }
    }
}
