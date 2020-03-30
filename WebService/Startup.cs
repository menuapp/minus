using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using DAL.Context;
using DAL.Infrastructure;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service;
using Service.Interfaces;
using Service.Mapping;
using WebService.BackgroundServices;
using WebService.Mapping;

namespace WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

            });

            services.AddDbContext<MinusContext>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IIdentityRoleRepository, IdentityRoleRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            //REGISTER SERVICE LAYER
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IIdentityRoleService, IdentityRoleService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();
            }, typeof(DtoProfile), typeof(DomainProfile));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kivimenu, all rights reserved")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            //services.AddHostedService<OrdersBackgroundService>();
            //services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120)
            };

            app.UseAuthentication();
            app.UseSession();
            app.UseWebSockets(webSocketOptions);
            app.Use(async (ctx, nextMsg) =>
            {
                if (ctx.Request.Path == "/getorder")
                {
                    if (ctx.WebSockets.IsWebSocketRequest)
                    {
                        var wSocket = await ctx.WebSockets.AcceptWebSocketAsync();
                        var socketFinishedTcs = new TaskCompletionSource<object>();

                        var socketWrapper = BackgroundSocketProcessor.AddSocket(wSocket, socketFinishedTcs);

                        await socketFinishedTcs.Task;

                        BackgroundSocketProcessor.RemoveSocket(socketWrapper);
                    }
                    else
                    {
                        ctx.Response.StatusCode = 400;
                    }
                }
                else if (ctx.Request.Path == "/orderstatus")
                {
                    if (ctx.WebSockets.IsWebSocketRequest)
                    {
                        var wSocket = await ctx.WebSockets.AcceptWebSocketAsync();
                        var socketFinishedTcs = new TaskCompletionSource<object>();

                        var sessionId = ctx.Request.Query["token"].ToString();
                        var socketWrapper = BackgroundSocketProcessor.AddClientSocket(wSocket, sessionId, socketFinishedTcs);

                        await socketFinishedTcs.Task;

                        BackgroundSocketProcessor.RemoveCientSocket(socketWrapper);
                    }
                    else
                    {
                        ctx.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await nextMsg();
                }
            });

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseMvc();

        }

        public static class BackgroundSocketProcessor
        {
            public static List<SocketWrapper> wSockets = new List<SocketWrapper>();
            public static List<SocketWrapper> clientSockets = new List<SocketWrapper>();
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

            public static SocketWrapper AddClientSocket(WebSocket wSocket, string SessionId, TaskCompletionSource<object> taskCompletionSource)
            {
                var newSocket = new SocketWrapper(wSocket, SessionId, taskCompletionSource);
                clientSockets.Add(newSocket);

                return newSocket;
            }

            public static void RemoveCientSocket(SocketWrapper wSocket)
            {
                wSocket.Dispose();
                clientSockets.Remove(wSocket);
            }
        }

        public class SocketWrapper
        {
            public TaskCompletionSource<object> TaskCompletionSource { get; set; }
            public WebSocket WebSocket { get; set; }
            public string SessionId { get; set; }

            public SocketWrapper(WebSocket _wSocket, TaskCompletionSource<object> _taskCompletionSource)
            {
                TaskCompletionSource = _taskCompletionSource;
                WebSocket = _wSocket;
                IsConnectionAlive();
            }

            public SocketWrapper(WebSocket _wSocket, string _sessionId, TaskCompletionSource<object> _taskCompletionSource)
            {
                TaskCompletionSource = _taskCompletionSource;
                SessionId = _sessionId;
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
    }
}
