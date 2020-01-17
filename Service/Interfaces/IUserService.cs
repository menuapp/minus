using Service.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDomain> ListUsers();
        bool CreateUser(UserDomain userDomain);
    }
}
