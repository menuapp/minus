using System;
using System.Collections.Generic;
using AdminUI.Models;
using DAL.Context;
using Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Domains;

[assembly: HostingStartup(typeof(AdminUI.Areas.Identity.IdentityHostingStartup))]
namespace AdminUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultUI()
                    .AddEntityFrameworkStores<MinusContext>()
                    .AddDefaultTokenProviders();
            });
        }
    }

    
}