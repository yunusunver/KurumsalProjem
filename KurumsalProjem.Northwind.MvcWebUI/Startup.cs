using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KurumsalProjem.Northwind.Business.Abstract;
using KurumsalProjem.Northwind.Business.ConCrete;
using KurumsalProjem.Northwind.DataAccess.Abstract;
using KurumsalProjem.Northwind.DataAccess.Concrete.EntityFramework;
using KurumsalProjem.Northwind.MvcWebUI.Entities;
using KurumsalProjem.Northwind.MvcWebUI.Middlewares;
using KurumsalProjem.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KurumsalProjem.Northwind.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService,ProductManager>();
            services.AddScoped<IProductDal,EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICartSessionService,CartSessionService>();
            services.AddSingleton<ICartService,CartService>();
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>
                (options => options.UseSqlServer("Server=Server=DESKTOP-9P1JTP9\\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=true"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseIdentity();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
}
