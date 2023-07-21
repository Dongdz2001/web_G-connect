using App.Business;
using App.Business.Services.QTHT;
using App.Business.Utils;
using App.Common.Base;
using App.Data;
using App.Data.Models.QTHT;
using Identity;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace App.Api
{
    public class Startup
    {
        //readonly string AllowOriginsConst = "MyAllowOrigin";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var migrationsAssembly = AppConst.ASSEMBLY_DATA;
            //kết nối cơ sở dữ liệu
            var connection_UseNpgsql = this.Configuration.GetConnectionString("default");
            var connection_UseSqlServer = this.Configuration.GetConnectionString("sqlServer");
            // cấu hình cho DB
            services.AddDbContext<APPContext>
                (builder =>
                //options.UseNpgsql(connection)
                builder.UseSqlServer(connection_UseSqlServer,
                sql => sql.MigrationsAssembly(migrationsAssembly))
                );
            services.AddHttpContextAccessor();
            services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
            );
            // cấu hình Identity server
            ConfigureIdentityServerServices(services, connection_UseSqlServer, migrationsAssembly);
            //add các service lớp busssiness
            services.AddAppLibrary();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();



            string notifyCronExpression = this.Configuration.GetSection("CronExpression")["NotifySchedule"];

            //cấu hình sercurity cho api

            //add cấu hình cho document api
            services.AddOpenApiDocument();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider().AddRazorRuntimeCompilation();
            services.AddSession();
            //services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // add cau hinh Configuration cho static class AppSettingsProvider
            AppSettingsProvider.Configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            // this will do the initial DB population
            InitializeDatabase(app);
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add(
                    "Content-Security-Policy",
                    "script-src 'self' 'unsafe-inline' https://code.iconify.design https://api.iconify.design/; " +
                    "style-src 'self' 'unsafe-inline'; " +
                    "img-src 'self'  data:;");

                await next();
            });
            app.UseStaticFiles();
            app.UseRouting();
            // Sử dụng cho https
            // app.UseHttpsRedirection();

            //cấu hình cors
            ConfigureCors(app);
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            AppHelpers.SetHttpContextAccessor(accessor);
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }


        private void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var PersistedContext = serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
            var ConfigContext = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            var AppContext = serviceScope.ServiceProvider.GetRequiredService<APPContext>();
            var nguoiDungService = serviceScope.ServiceProvider.GetRequiredService<INguoiDungService>();
            PersistedContext.Database.Migrate();
            ConfigContext.Database.Migrate();
            AppContext.Database.Migrate();


            if (!ConfigContext.Clients.Any())
            {
                foreach (var client in Config.Clients)
                {
                    ConfigContext.Clients.Add(client.ToEntity());
                }
                ConfigContext.SaveChanges();
            }

            if (!ConfigContext.IdentityResources.Any())
            {
                foreach (var resource in Config.Ids)
                {
                    ConfigContext.IdentityResources.Add(resource.ToEntity());
                }
                ConfigContext.SaveChanges();
            }

            if (!ConfigContext.ApiResources.Any())
            {
                foreach (var resource in Config.Apis)
                {
                    ConfigContext.ApiResources.Add(resource.ToEntity());
                }
                ConfigContext.SaveChanges();
            }

            if (!AppContext.nguoi_dung.Any())
            {
                nguoiDungService.InitialDataQTHT(AppContext);
            }
        }

        private void ConfigureIdentityServerServices(IServiceCollection services, string connectionStr, string migrationsAssembly)
        {
            var Authority = this.Configuration.GetSection("ApplicationSettings:Authority").Get<string>();
            var certificate = new X509Certificate2(Path.Combine(Directory.GetCurrentDirectory(), "identityServer.pfx"), "Ab@123456");
            X509SecurityKey privateKey = new X509SecurityKey(certificate);
            
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
              //.AddTestUsers(TestUsers.Users)
              // this adds the config data from DB (clients, resources, CORS)
              .AddConfigurationStore(options =>
              {
                  options.ConfigureDbContext = builder => builder.UseSqlServer(connectionStr,
                      sql => sql.MigrationsAssembly(migrationsAssembly));
              })
              // this adds the operational data from DB (codes, tokens, consents)
              .AddOperationalStore(options =>
              {
                  options.ConfigureDbContext = builder => builder.UseSqlServer(connectionStr,
                      sql => sql.MigrationsAssembly(migrationsAssembly));

                  // this enables automatic token cleanup. this is optional.
                  options.EnableTokenCleanup = true;
              })
              .AddCustomUserStore();

            // not recommended for production - you need to store your key material somewhere secure
            // builder.AddDeveloperSigningCredential(); 
            builder.AddSigningCredential(certificate);
            services.AddAuthentication
            (options =>
            {
                options.DefaultScheme = "oidc";
                options.DefaultAuthenticateScheme = "oidc";
                options.DefaultChallengeScheme = "oidc";
            })
             .AddCookie("oidc", options =>
             {
                 options.CookieManager = new ChunkingCookieManager();
             })
             .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
             {
                 //options.Authority = Authority;
                 options.RequireHttpsMetadata = false;
                 options.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };

                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = false,
                     ValidateIssuer = false,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = privateKey,
                 };

                 options.SaveToken = true;
                 options.Events = new JwtBearerEvents
                 {
                     OnChallenge = context =>
                     {
                         // Skip the default logic.
                         context.HandleResponse();

                         var payload = new JObject
                         {
                             ["error"] = context.Error,
                             ["error_description"] = context.ErrorDescription,
                             ["error_uri"] = context.ErrorUri
                         };

                         context.Response.ContentType = "application/json";
                         context.Response.StatusCode = 401;

                         return context.Response.WriteAsync(payload.ToString());
                     }
                 };
             });
             
            /*
            .AddGoogle(options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                // register your IdentityServer with Google at https://console.developers.google.com
                // enable the Google+ API
                // set the redirect URI to http://localhost:6000/signin-google
                options.ClientId = "copy client ID from Google here";
                options.ClientSecret = "copy client secret from Google here";
            })
            .AddFacebook(options => {
                options.AppId = "copy AppId from Facebook here";
                options.AppSecret= "copy AppSecret from Facebook here";
            })
            .AddTwitter(options => {
                   options.ConsumerKey= "copy ConsumerKey from Twitter here";
                   options.ConsumerSecret = "copy ConsumerSecret from Twitter here";
               })
            .AddWsFederation(options => {
                // MetadataAddress represents the Active Directory instance used to authenticate users.
                options.MetadataAddress = "https://login.microsoftonline.com/.../federationmetadata.xml";

                // Wtrealm is the app's identifier in the Active Directory instance.
                // For ADFS, use the relying party's identifier, its WS-Federation Passive protocol URL.
                // For AAD, use the App ID URI from the app registration's Properties blade.
                // Read more: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/ws-federation
                options.Wtrealm = Configuration["WtRealm"];
            })*/


        }

        private void ConfigureCors(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var ConfigContext = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            var AllowOrigins = ConfigContext.ClientCorsOrigins.Select(x => x.Origin).ToArray();
            app.UseCors(builder =>
            {
                builder
                .WithOrigins(AllowOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });
        }
    }
}
