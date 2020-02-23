using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Partner")]
        public string PartnerId { get; set; }

        public List<SelectListItem> Partners { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }
        public RoleViewModel Role { get; set; }
        public List<SelectListItem> Roles { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
