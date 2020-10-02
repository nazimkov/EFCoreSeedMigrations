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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEfMigrationSeeds<MigrationSeedsConfiguration, MigrationSeedsAplicabilitySpecification>();

            RegisterSeeds(services);

            services
                .AddDbContext<ProductsDbContext>(b =>
                b.UseSqlServer(Configuration.GetConnectionString("ProductsDb"))
                        .ReplaceService<IMigrationsAssembly, SeedAwareMigrationsAssembly>());

            services.AddControllers();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterSeeds(IServiceCollection services)
        {
            services.AddScoped<IntitialMigrationSeed>();
        }
    }
}