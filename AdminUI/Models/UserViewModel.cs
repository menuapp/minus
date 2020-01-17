using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; }
    }
}
