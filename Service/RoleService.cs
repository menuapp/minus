using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class RoleService
    {
        public RoleRepository roleRepository { get; set; }
        public RoleService(RoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IEnumerable<> GetAll()
        {

        }
    }
}
