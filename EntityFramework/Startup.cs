using System;
using EntityFramework.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntityFramework
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
            services.AddDbContext<EntityFrameworkDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EntityFrameworkBaza;Trusted_Connection=True;"));

            //implementacja interface ISettingsRepository jako Scoped
            //Kiedykolwiek chcemy dostaæ interface ISettingsRepository to nam podrzuci implementacji Klasy
            services.AddScoped<ISettingsRepository,SettingsRepository>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //upewnia sie ¿e baza danych jest stworzona
            var database = serviceProvider.GetService<EntityFrameworkDbContext>();
            database.Database.EnsureCreated();
        }
    }
}
