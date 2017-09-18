using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReimbursementApp.Data.Contracts;
using ReimbursementApp.DatabaseHelpers;
using ReimbursementApp.DbContext;
using ReimbursementApp.EFRepository;
using ReimbursementApp.SampleData;


namespace ReimbursementApp
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
            /*services.AddEntityFrameworkSqlServer()
                .AddDbContext<ExpenseReviewDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:ExpenseReviewSPA:ConnectionString"],
                        b => b.MigrationsAssembly("ReimbursementApp.Data")));*/

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ExpenseReviewDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:ExpenseReviewSPA:ConnectionString"]));

            services.AddMvc();
            //Initiating Seed Data
            services.AddTransient<InitialData>();
            //DI Setup
            services.AddScoped<RepositoryFactories, RepositoryFactories>();
            services.AddScoped<IRepositoryProvider, RepositoryProvider>();
            services.AddScoped<IExpenseReviewUOW, ExpenseReviewUOW>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, InitialData seedDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
            //Initiating from here
            seedDbContext.SeedData();
        }
    }
}
