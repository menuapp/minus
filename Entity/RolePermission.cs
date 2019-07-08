using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class RolePermission : IEntityBase
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}
