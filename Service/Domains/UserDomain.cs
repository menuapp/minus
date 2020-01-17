using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domains
{
    public class UserDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; }
    }
}
