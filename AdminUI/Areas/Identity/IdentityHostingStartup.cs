using System;
using DAL.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AdminUI.Areas.Identity.IdentityHostingStartup))]
namespace AdminUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultUI()
                    .AddEntityFrameworkStores<MinusContext>()
                    .AddDefaultTokenProviders();
            });
        }
    }
}