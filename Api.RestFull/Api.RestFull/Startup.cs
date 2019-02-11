using Api.RestFull.Model.Context;
using Api.RestFull.Business;
using Api.RestFull.Business.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.RestFull.Repository;
using Api.RestFull.Repository.Implementation;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Api.RestFull.Repository.Generic;

namespace Api.RestFull
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment _environment { get; }
        private readonly ILogger _logger;
        
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Connection Configuration
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration["SqlConnection:SqlConnectionString"]));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new SqlConnection(Configuration["SqlConnection:SqlConnectionString"]);

                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true
                    };

                    evolve.Migrate();
                }
                catch(Exception ex)
                {
                    _logger.LogCritical("Database migration failed", ex);
                    throw;
                }
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Api Version
            services.AddApiVersioning();

            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBookBusiness, BookBusiness>();

            //Generic repository dependency injection
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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
    }
}
