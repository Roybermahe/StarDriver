using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StarDriver.application.core.QuestionsServices;
using StarDriver.domain.core.Contracts;
using StarDriver.domain.core.Factorys.Questions;
using StarDriver.infrastructure.core.Base;
using StarDriver.infrastructure.core.DomainContexts;

namespace WebApplication
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
            var connectionString = Configuration.GetConnectionString("AllContext");
            services.AddDbContext<DbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContext, StarDriverContext>();
            services.AddScoped<IDates, MyDate>();
            

            #region swagger doc generation
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Star Driver Api",
                    Description = "Star Driver API - ASP.NET Core Web API",
                    TermsOfService = new Uri("https://cla.dotnetfoundation.org/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Unicesar",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/Roybermahe/StarDriver"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licencia dotnet foundation"
                    }
                });
            });
            #endregion
            
            
            services.AddControllers();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            #region swagger activation
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "StarDriver api v1");
            });
            #endregion

            app.UseEndpoints(builder =>
            {
                builder.MapControllers();
            });
        }
    }
}