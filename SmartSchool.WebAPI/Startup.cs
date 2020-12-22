using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI
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
            services.AddDbContext<SmartSchoolContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("SmartSchoolContext")));
<<<<<<< HEAD

            services.AddControllers()
                    .AddNewtonsoftJson(opt =>
                      opt.SerializerSettings.ReferenceLoopHandling =
                      Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(
            "smartschoolapi",
            new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "SmartSchool API",
                    Version = "1.0"
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                opt.IncludeXmlComments(xmlCommentsFullPath);
            });
        }

=======

            services.AddControllers()
                    .AddNewtonsoftJson(opt =>
                      opt.SerializerSettings.ReferenceLoopHandling =
                      Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(
                    "smartschoolapi",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "SmartSchool API",
                        Version = "1.0",
                        TermsOfService = new Uri("http://termsexample.com"),
                        Description = "A descrição da WebAPI da SmartSchool",
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                            Name = "SmartSchool License",
                            Url = new Uri("http://example.com")
                        },
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Lucas Pagliarini",
                            Email = "example@example.com",
                            Url = new Uri("http://contact.com")
                        }
                    });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                opt.IncludeXmlComments(xmlCommentsFullPath);
            });
        }

>>>>>>> 1752f3abfe020c0dbf3704ae4322bcffff40e096
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

<<<<<<< HEAD
            app.UseCors();

            app.UseSwagger()
              .UseSwaggerUI(opt =>
              {
                  opt.SwaggerEndpoint("http://localhost:5000/swagger/smartschoolapi/swagger.json", "smartschoolapi");
=======
            app.UseSwagger()
              .UseSwaggerUI(opt =>
              {
                  opt.SwaggerEndpoint("http://localhost:24835/swagger/smartschoolapi/swagger.json", "smartschoolapi");
>>>>>>> 1752f3abfe020c0dbf3704ae4322bcffff40e096
                  opt.RoutePrefix = "";
              });

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
