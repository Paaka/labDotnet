using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication3.Models;

namespace WebApplication3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddTransient<IProductRepository, EEProductRepository>();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(routes => {
                    
                

                routes.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Product}/{action=List}/{id?}");

               

                routes.MapControllerRoute(
                    name: null,
                    pattern: "Product/{category}",
                    defaults: new
                    {
                        controller= "Product",
                        action = "List",
                    });

                routes.MapControllerRoute(
                    name: null,
                    pattern: "Admin/{action=Index}",
                    defaults: new
                    {
                        controller = "Admin",
                        action = "Index",
                    });
                    

            }) ;
            SeedData.EnsurePopulated(app);
        }
    }
}
