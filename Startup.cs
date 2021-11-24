using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PartyInvites.Context;
using Microsoft.EntityFrameworkCore;
using PartyInvites.DbOperations;
using PartyInvites.Models;

namespace PartyInvites
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
            services.AddControllersWithViews();
            // services.AddDbContext<CodeFirstContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDal<Category>, CategoryDal>();
            services.AddScoped<IDal<Party>, PartyDal>();
            services.AddScoped<IDal<User>, UserDal>();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CodeFirstContext>(options => options.UseSqlServer(connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<CodeFirstContext>().UseSqlServer(connectionString);

            using var dbcontext = new CodeFirstContext(optionsBuilder.Options);
            
            dbcontext.Database.Migrate();

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
                throw new Exception();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=Index}/{id?}");
            });
        }
    }
}
