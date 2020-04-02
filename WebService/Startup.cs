using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
            services.AddTransient<IOrderProductRepository, OrderProductRepository>();
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

            app.Map("/getorder", (IApplicationBuilder builder) =>
            {
                builder.Use(async (context, next) =>
                {
                    if (!context.WebSockets.IsWebSocketRequest)
                    {
                        return;
                    }

                    var wSocket = await context.WebSockets.AcceptWebSocketAsync();
                    Sockets.wSockets.TryAdd(Guid.NewGuid().ToString(), wSocket);

                    await Receive(wSocket, async (result, message) =>
                    {
                        //if (result.MessageType == WebSocketMessageType.Text)
                        //{

                        //}
                        /*else*/
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            Sockets.wSockets.TryRemove(Sockets.wSockets.FirstOrDefault(p => p.Value == wSocket).Key, out wSocket);
                            await wSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "closed by client", CancellationToken.None);
                        }

                        return;
                    });
                });
            });

            app.Map("/orderstatus", (IApplicationBuilder builder) =>
            {
                builder.Use(async (context, next) =>
                {
                    if (!context.WebSockets.IsWebSocketRequest)
                    {
                        return;
                    }

                    var wSocket = await context.WebSockets.AcceptWebSocketAsync();
                    Sockets.clientSockets.TryAdd(context.Request.Query["token"].ToString(), wSocket);

                    await Receive(wSocket, async (result, message) =>
                    {
                        //if (result.MessageType == WebSocketMessageType.Text)
                        //{

                        //}
                        /*else*/
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            Sockets.clientSockets.TryRemove(Sockets.clientSockets.FirstOrDefault(p => p.Value == wSocket).Key, out wSocket);
                            await wSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "closed by client", CancellationToken.None);
                        }

                        return;
                    });
                });
            });

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMesssage)
        {
            var buffer = new byte[1024 * 4];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer), cancellationToken: CancellationToken.None);

                handleMesssage(result, buffer);
            }
        }

        public static class Sockets
        {
            public static ConcurrentDictionary<string, WebSocket> wSockets = new ConcurrentDictionary<string, WebSocket>();
            public static ConcurrentDictionary<string, WebSocket> clientSockets = new ConcurrentDictionary<string, WebSocket>();
        }
    }
}
