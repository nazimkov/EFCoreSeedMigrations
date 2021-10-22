using EFCoreSeedMigrations.API.Migrations;
using EFCoreSeedMigrations.DataAccess;
using EFCoreSeedMigrations.DataAccess.Seed;
using EFCoreSeedMigrations.DataAccess.Seeds;
using EFCoreSeedMigrations.SeedMigration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreSeedMigrations.API
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
            services.AddEfMigrationSeeds<MigrationSeedsConfiguration, MigrationSeedsApplicabilitySpecification>();

            RegisterSeeds(services);

            services
                .AddDbContext<ProductsDbContext>(b =>
                b.UseSqlServer(Configuration.GetConnectionString("ProductsDb"))
                        .ReplaceService<IMigrationsAssembly, SeedAwareMigrationsAssembly>());

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterSeeds(IServiceCollection services)
        {
            services.AddScoped<IntitialMigrationSeed>();
        }
    }
}