using Api.RestFull.Business;
using Api.RestFull.Business.Implementation;
using Api.RestFull.HyperMedia;
using Api.RestFull.Model.Context;
using Api.RestFull.Repository;
using Api.RestFull.Repository.Generic;
using Api.RestFull.Repository.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tapioca.HATEOAS;
using WebApiContrib.Core.Formatter.Csv;

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

            var csvFormatterOptions = new CsvFormatterOptions();
            csvFormatterOptions.CsvDelimiter = ";";

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.OutputFormatters.Add(new CsvOutputFormatter(csvFormatterOptions));
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));

            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddXmlSerializerFormatters();

            var filterOption = new HyperMediaFilterOptions();
            filterOption.ObjectContentResponseEnricherList.Add(new PersonEnricher());

            services.AddSingleton(filterOption);

            //Api Version
            services.AddApiVersioning();

            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1",
                    new Info {
                        Title = "RestFull API With .Net Core 2.1",
                        Version = "v1"
                    });
            });

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

            app.UseSwagger();
            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

            app.UseMvc(routes => {
                routes.MapRoute(
                        name: "DefaultApi",
                        template: "{controller=Value}/{id}"
                    );
            });
        }
    }
}
