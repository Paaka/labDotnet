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
using WebApplication3.Middlewares;
using Microsoft.AspNetCore.Identity;


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
            services.AddServerSideBlazor();
            services.AddTransient<IProductRepository, EEProductRepository>();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "api";
            });

            app.UseMiddleware<TimeMiddleware>();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            

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

                routes.MapBlazorHub();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
