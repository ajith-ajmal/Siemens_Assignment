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
using Siemens.DataAccess.Service.DataModels;
using Siemens.Domain.Service.Enum;
using Siemens.Domain.Service.Implementation.Calculator;
using Siemens.Domain.Service.Implementation.Factory;
using Siemens.Domain.Service.Implementation.Helper;
using Siemens.Domain.Service.Implementation.Printer;
using Siemens.Domain.Service.Implementation.Repository;
using Siemens.Domain.Service.Interface;
using Siemens.Domain.Service.Interface.Factory;
using Siemens.Domain.Service.Interface.Helper;
using Siemens.Domain.Service.Interface.Repository;
using Siemens.DataIngestion.BackgroundJob;
using Siemens.API.Service.Middleware;
using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace Siemens.API.Service
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(XmlCommentsFilePath);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Siemens", Version = "v1" });
            });

            services.AddTransient<IPrinter, UnknownPrinter>();
            services.AddSingleton<IRepositoryService, Repository>();
            services.AddSingleton<IFactory, Factory>();
            services.AddSingleton<ITestDataIngestionService, TestDataIngestionService>();
            services.AddSingleton<IMath, Maths>();
            services.AddSingleton<ICalculatorService, GoldCaculator>();
            services.AddDbContext<SiemensContext>(opt => opt.UseInMemoryDatabase(Configuration.GetValue<string>("DatabaseName")), ServiceLifetime.Singleton);
            services.AddHostedService<BackgroundJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Tax APIs");
                });
            }
            //Global exception handling
            app.UseMiddleware(typeof(GlobalExceptionHandling));
            //To identify end point
            app.UseRouting();

            #region <Not Required for now>
            //To validate the incoming token
            ///app.UseAuthentication();
            //To validate the role from the token
            //app.UseAuthorization();
            #endregion

            //To exceute the end pointt
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

    }
}
