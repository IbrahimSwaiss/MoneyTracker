using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Interfaces;
using MoneyTracker.Interfaces.Repositories;
using MoneyTracker.Interfaces.Utilities;
using MoneyTracker.Persistence;
using MoneyTracker.Persistence.Repositories;
using MoneyTracker.Utilities;

namespace MoneyTracker {
    public class Startup {
        readonly string _enabledSpecificOriginsName = "EnableCORS";
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IUoW, UoW>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddDbContext<MoneyTrackerDbContext>(db => db.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddSingleton<IClock, Clock>();

            services.AddSwaggerDocument();

            services.AddCors(options => {
                options.AddPolicy(_enabledSpecificOriginsName, builder => {
                    builder.WithOrigins(
                        Configuration["App:AllowedCorsOrigins"]
                            .Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray());
                });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(_enabledSpecificOriginsName);
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseSwagger();
            app.UseSwaggerUi3();
        }

        public IConfigurationRoot Configuration { get; }
    }
}
