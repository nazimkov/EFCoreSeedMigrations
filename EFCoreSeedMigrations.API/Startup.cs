using EFCoreSeedMigrations.DataAccess;
using EFCoreSeedMigrations.DataAccess.Seed;
using EFCoreSeedMigrations.DataAccess.Seeds;
using EFCoreSeedMigrations.SeedMigration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreSeedMigrations.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddEntityFrameworkSqlServer();

            services.AddEfMigrationSeeds<MigrationSeedsConfiguration>();

            RegisterSeeds(services);

            services
                .AddDbContext<ProductsDbContext>(b =>
                b.UseSqlServer("Server=(local);Database=EFCoreSeedMigrations;Trusted_Connection=True;MultipleActiveResultSets=true")
                        .ReplaceService<IMigrationsAssembly, SeedAwareMigrationsAssembly>());
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void RegisterSeeds(IServiceCollection services)
        {
            services.AddScoped<IntitialMigrationSeed>();
        }
    }
}