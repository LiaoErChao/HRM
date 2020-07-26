using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EFEntity;
using IDAO;
using DAO;
using IBLL;
using BLL;

namespace WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<TescDbContext1>();

            services.AddTransient<Iconfig_public_charBLL1, config_public_charBLL1>();
            services.AddTransient<Iconfig_public_charDAO1, config_public_charDAO1>();

            //config_majorb
            services.AddTransient<Iconfig_majorbBLL1, config_majorBLL1>();
            services.AddTransient<Iconfig_majorDAO1, config_majorDAO1>();

            //config_major_kind
            services.AddTransient<Iconfig_major_kindBLL1, config_major_kindBLL1>();
            services.AddTransient<Iconfig_major_kindDAO1, config_major_kindDAO1>();

            //users
            services.AddTransient<IuserBLL1, usersBLL1>();
            services.AddTransient<IusersDAO1, usersDAO1>();

            //  services.AddControllersWithViews();
            //øÁ”Ú
            services.AddCors(option => option.AddPolicy("AllowCors", bu => bu.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseRouting();
            
            app.UseCors("AllowCors");
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                // Ù–‘¬∑”…
                endpoints.MapControllers();
            });
        }
    }
}
