using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IrishHousingEstate.DataAccessApi.DataRepository;
using IrishHousingEstate.DataAccessApi.DBContext;
using IrishHousingEstate.ModelApp.DataRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IrishHousingEstate.ServiceApi
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

            services.AddEntityFrameworkNpgsql().AddDbContext<IrishHousingEstateDbContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("PostgresConnection"), migration => migration.MigrationsAssembly("IrishHousingEstate.ServiceApi"));

            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddTransient(typeof(IHouseDataRepository), typeof(HouseDataRepository));
            services.AddScoped(typeof(IHouseDataRepository), typeof(HouseDataRepository));

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v0.0.1";
                    document.Info.Title = "Irish Housing Estate API";
                    document.Info.Description = "Irish Housing Estate web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Ryan OC",
                        Email = "ryanroc8@gmail.com",
                        Url = "https://localhost:44340/swagger/index.html"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = "https://opensource.org/licenses/MIT"
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
