using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using HospitalSystem_Core.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HospitalSystem_Core.Mappings;
using HospitalSystem_Core.DataAcessLayer;
using HospitalSystem_Core.Business_Layer;

namespace HospitalSystem_Core
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var mapconfig = new MapperConfiguration(mc=>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper =mapconfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IBusinessLayer,BusinessLayer>();
            services.AddSingleton<IDataLayer, DataLayer>();
            services.AddDbContext<DoctorDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Doctor")));
            services.AddMvc(options=> options.EnableEndpointRouting=false);
            services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
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
                //app.UseStatusCodePages();
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            app.UseRouting();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=RegisterUser}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
