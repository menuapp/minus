using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AdminUI.Mapping;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using DAL.Context;
using DAL.Infrastructure;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Interfaces;
using Service.Mapping;
using Entity;
using AdminUI.Extensions;
using System.Net.WebSockets;
using System.Threading;

namespace AdminUI
{
    public class Startup
    {
        private readonly ApplicationDbInitializer _applicationDbInitializer = new ApplicationDbInitializer();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<HostingEnvironment>();

            services.AddDbContext<MinusContext>(ServiceLifetime.Singleton);
            //REGISTER REPOSITORY LAYER
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IPartnerRepository, PartnerRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IIdentityRoleRepository, IdentityRoleRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            //REGISTER SERVICE LAYER
            services.AddTransient<ITableService, TableService>();
            services.AddTransient<IPartnerService, PartnerService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IIdentityRoleService, IdentityRoleService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();
            }, typeof(ModelProfile), typeof(DomainProfile));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CreateAdminUserPolicy", policy => policy
                .RequireAssertion(context => context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin")));
                options.AddPolicy("CreateAdminUserPolicy", policy => policy.RequireClaim("Create User"));

                options.AddPolicy("PartnerOperationsPolicy", policy => policy
                .RequireAssertion(context => context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin")));

                //options.AddPolicy("PartnerProductOperationsPolicy", )
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddSingleton<IEmailSender, MinusEmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            using (var context = new MinusContext())
            {
                context.Database.EnsureCreated();
            }

            _applicationDbInitializer.SeedRoles(roleManager);
            _applicationDbInitializer.SeedUser(userManager);

            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120)
            };

            app.UseWebSockets(webSocketOptions);
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/getdelivery")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        var wSocket = await context.WebSockets.AcceptWebSocketAsync();
                        var socketFinishedTcs = new TaskCompletionSource<object>();

                        var socketWrapper = BackgroundSocketProcessor.AddSocket(wSocket, socketFinishedTcs);

                        await socketFinishedTcs.Task;

                        BackgroundSocketProcessor.RemoveSocket(socketWrapper);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else next();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }

    public static class BackgroundSocketProcessor
    {
        public static List<SocketWrapper> wSockets = new List<SocketWrapper>();
        public static SocketWrapper AddSocket(WebSocket wSocket, TaskCompletionSource<object> taskCompletionSource)
        {
            var newSocket = new SocketWrapper(wSocket, taskCompletionSource);
            wSockets.Add(newSocket);

            return newSocket;
        }

        public static void RemoveSocket(SocketWrapper wSocket)
        {
            wSocket.Dispose();
            wSockets.Remove(wSocket);
        }
    }

    public class SocketWrapper
    {
        public TaskCompletionSource<object> TaskCompletionSource { get; set; }
        public WebSocket WebSocket { get; set; }

        public SocketWrapper(WebSocket _wSocket, TaskCompletionSource<object> _taskCompletionSource)
        {
            TaskCompletionSource = _taskCompletionSource;
            WebSocket = _wSocket;
            IsConnectionAlive();
        }

        public async void IsConnectionAlive()
        {
            try
            {
                var buffer = new byte[1024 * 4];
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(10000);
                WebSocketReceiveResult result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationTokenSource.Token);

                while (!result.CloseStatus.HasValue)
                {
                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = new CancellationTokenSource(10000);
                    result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationTokenSource.Token);
                }

                CompleteTask();

            }
            catch (Exception)
            {
                CompleteTask();
            }
        }

        public void CompleteTask()
        {
            TaskCompletionSource.SetResult(new { result = "Task Completed" });
        }

        public void Dispose()
        {
            WebSocket.Dispose();
        }
    }

    public class MinusEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Credentials
            var credentials = new NetworkCredential("support@kivimenu.com", "ob37%K3i");
            // Mail message
            var mail = new MailMessage()
            {
                From = new MailAddress("support@kivimenu.com"),
                Subject = subject,
                Body = message
            };
            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(email));
            // Smtp client
            var client = new SmtpClient()
            {
                Port = 465,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                EnableSsl = true,
                Host = "mail.kivimenu.com",
                Credentials = credentials
            };
            client.Send(mail);

            return Task.CompletedTask;
        }
    }

    public class ApplicationDbInitializer
    {
        public void SeedUser(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("akifozkan_@hotmail.com").Result == null)
            {
                ApplicationUser identityUser = new ApplicationUser
                {
                    Email = "akifozkan_@hotmail.com",
                    UserName = "akifozkan_@hotmail.com"
                };

                var result = userManager.CreateAsync(identityUser, "6218549520;)Oam.enfesmenu").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(identityUser, "SuperAdmin").Wait();
                }
            }
        }

        public void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var roles = new List<string> { "SuperAdmin", "Admin", "Manager", "Worker", "Customer" };

            foreach (var role in roles)
            {
                if (roleManager.FindByNameAsync(role).Result == null)
                {
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = role
                    };

                    roleManager.CreateAsync(identityRole).Wait();

                    if (role == "SuperAdmin")
                    {
                        var claims = new AppClaims();

                        foreach (var claim in claims.Claims)
                        {
                            roleManager.AddClaimAsync(identityRole, claim).Wait();
                        }
                    }
                }
            }
        }
    }
}
