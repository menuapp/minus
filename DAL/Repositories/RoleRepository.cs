using DAL.Context;
using DAL.Infrastructure;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class RoleRepository
    {
        public MinusContext context { get; set; }
        public RoleRepository(MinusContext context)
        {
            this.context = context;
        }
        public Role GetById(int id)
        {
            return context.Roles.FirstOrDefault(role => role.Id == id);
        }

        public ICollection<Role> GetAll()
        {
            return context.Roles.ToList();
        }

        public int Add(Role newRoles)
        {
            context.Roles.Add(newRoles);

            return newRoles.Id;
        }
    }
}
