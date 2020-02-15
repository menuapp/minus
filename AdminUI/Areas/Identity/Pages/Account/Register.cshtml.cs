using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AdminUI.Extensions;
using AdminUI.Models;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace AdminUI.Areas.Identity.Pages.Account
{
    //[Authorize(Policy = "AdminRolePolicy")]
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IPartnerService _partnerService;
        private readonly IIdentityRoleService _identityRoleService;
        private readonly IMapper _mapper;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IPartnerService partnerService,
            IIdentityRoleService identityRoleService,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _identityRoleService = identityRoleService;
            _mapper = mapper;
            _partnerService = partnerService;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public UserViewModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            Input = new UserViewModel();
            addRolesAndPartners(Input);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            addRolesAndPartners(Input);

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    var userRole = _roleManager.Roles.FirstOrDefault(role => role.Id == Input.RoleId);
                    var resultRole = await _userManager.AddToRoleAsync(user, userRole.Name);

                    if (resultRole.Succeeded)
                    {
                        if (Input.PartnerId != null)
                        {
                            Claim partnerClaim = new Claim("PartnerId", Input.PartnerId);

                            await _userManager.AddClaimAsync(user, partnerClaim);
                        }

                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { userId = user.Id, code = code },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public void addRolesAndPartners(UserViewModel model)
        {
            var roles = _roleManager.Roles.ToList();
            var partners = _partnerService.GetAll();
            var viewPartners = new List<SelectListItem> { };
            var viewRoles = new List<SelectListItem> { };

            if (HttpContext.User.IsInRole("Manager"))
            {
                roles = roles.Where(role => role.Name == "Worker").ToList();
            }

            foreach (var role in roles)
            {
                if (role.Name != "SuperAdmin")
                {
                    SelectListItem selectListItem = new SelectListItem
                    {
                        Text = role.Name,
                        Value = role.Id
                    };

                    viewRoles.Add(selectListItem);
                }
            }

            foreach (var partner in partners)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = partner.AssociateName,
                    Value = partner.Id.ToString()
                };

                viewPartners.Add(selectListItem);
            }

            model.Roles = viewRoles;
            model.Partners = viewPartners;
        }
    }
}
