using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rooydaad.Web.Models;
using Rooydaad.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Rooydaad.Web
{
    public class Startup
    {


        public static string PageNotFound = "<h1 style='color:red' >Page Not found !</h1>";
        public static string version = "<h1 style='color:red' >Thats version 2!</h1>";
        public static bool IsWebSiteOpened = true;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(a =>
            {
                a.Filters.Add<Infrustructure.Filters.PoweredByFilters>();
            });
            var automapperconfig = new MapperConfiguration(a =>
              {
                  a.AddProfile<Infrustructure.AutoMapperProfile>();
              });
            var mapper= automapperconfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton(typeof(IDatabase), typeof(Database));
            services.AddScoped<ILocationManager,LocationManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.Map("/app-version", (context) =>
            {


                context.Run(async httpcontext => {  httpcontext.Response.Redirect("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1"); });
            });
            app.UseMiddleware<Infrustructure.Middleware.AppClosedMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Test",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{name}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Blog",
                    pattern: "Archive/{controller=Blog}/{action=Author}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async (httpcontext) => { await httpcontext.Response.WriteAsync(PageNotFound); });
        }
    }
}
