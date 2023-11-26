using System.Text.Json;
using Microsoft.Extensions.Configuration;
using NotebookforContacts1.Database;
using NotebookforContacts1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Hosting;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;


namespace NotebookforContacts1
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<NotebookContext1>(options =>
       options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //            Настройка middleware компонентов , используемых в приложении(данные из файла Program)
            app.UseDeveloperExceptionPage();


            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Notebooks/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Notebooks}/{action=Index}/{id?}");
            });

        }
    }
}

