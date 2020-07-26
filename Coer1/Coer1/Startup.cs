 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IDAO;
using DAO;
using IBLL;
using BLL;
using EFEntity;

namespace Coer1
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Ioc容器
            //services
            //在容器里面注册类：注册了一个ITestDAO,由ITestDAO实现
            //config_file_first_kind
            services.AddTransient<Iconfig_file_first_kindBLL, config_file_first_kindBLL>();
            services.AddTransient<Iconfig_file_first_kindDAO, config_file_first_kindDAO>();
           
            //config_file_second_kind
            services.AddTransient<Iconfig_file_second_kindDAO, config_file_second_kindDAO>();
            services.AddTransient<Iconfig_file_second_kindBLL, config_file_second_kindBLL>();

            //config_file_third_kind
            services.AddTransient<Iconfig_file_third_kindBLL, config_file_third_kindBLL>();
            services.AddTransient<Iconfig_file_third_kindDAO, config_file_third_kindDAO>();

            //config_public_char
            services.AddTransient<Iconfig_public_charBLL, config_public_charBLL>();
            services.AddTransient<Iconfig_public_charDAO, config_public_charDAO>();

            //config_majorb
            services.AddTransient<Iconfig_majorbBLL, config_majorBLL>();
            services.AddTransient<Iconfig_majorDAO, config_majorDAO>();

            //config_major_kind
            services.AddTransient<Iconfig_major_kindBLL, config_major_kindBLL>();
            services.AddTransient<Iconfig_major_kindDAO, config_major_kindDAO>();

            //users
            services.AddTransient<IusersBLL, usersBLL>();
            services.AddTransient<IusersDAO, usersDAO>();
            //human_file
            services.AddTransient<Ihuman_fileBLL, human_fileBLL>();
            services.AddTransient<Ihuman_fileDAO, human_fileDAO>();
            //config_major_kind
            services.AddTransient<Iconfig_major_kindBLL, config_major_kindBLL>();
            services.AddTransient<Iconfig_major_kindDAO, config_major_kindDAO>();
            //major_change
            services.AddTransient<Imajor_changeBLL, major_changeBLL>();
            services.AddTransient<Imajor_changeDAO, major_changeDAO>();
            //
            services.AddTransient<Isalary_standardBLL, salary_standardBLL>();
            services.AddTransient<Isalary_standardDAO, salary_standardDAO>();
            //role
            services.AddTransient<IroleBLL, roleBLL>();
            services.AddTransient<IroleDAO, roleDAO>();

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache().AddSession();


            //读取连接字符串
            var conStr = configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<TescDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //1
            if (env.IsDevelopment())
            {//Ioc容器
             //services
             //在容器里面注册类：注册了一个ITestDAO,由ITestDAO实现
             //services.AddTransient<ITestDAO, TestDAO>();
             //services.AddControllersWithViews();
             //读取连接字符串
                var conStr = configuration.GetConnectionString("SqlServerConnection");
                //services.AddDbContext<TestDbContext>();
                app.UseDeveloperExceptionPage();
            }
            //2
            app.UseStaticFiles();//加载静态文件的组件

            //3
            app.UseRouting();
            app.UseSession();
            //4
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });

            //1->2->3->4进
            //出4->3->2->1
        }
    }
}
