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

            services.AddDistributedMemoryCache().AddSession();


            //在容器里面注册类：注册了一个ITestDAO,由ITestDAO实现
            //config_file_first_kind
            services.AddTransient<Iconfig_file_first_kindBLL, config_file_first_kindBLL1>();
            services.AddTransient<Iconfig_file_first_kindDAO, config_file_first_kindDAO1>();
           
            //config_file_second_kind
            services.AddTransient<Iconfig_file_second_kindDAO, config_file_second_kindDAO1>();
            services.AddTransient<Iconfig_file_second_kindBLL, config_file_second_kindBLL1>();

            //config_file_third_kind
            services.AddTransient<Iconfig_file_third_kindBLL, config_file_third_kindBLL1>();
            services.AddTransient<Iconfig_file_third_kindDAO, config_file_third_kindDAO1>();

            //config_public_char
            services.AddTransient<Iconfig_public_charBLL, config_public_charBLL1>();
            services.AddTransient<Iconfig_public_charDAO, config_public_charDAO1>();

            //config_majorb
            services.AddTransient<Iconfig_majorbBLL, config_majorBLL1>();
            services.AddTransient<Iconfig_majorDAO, config_majorDAO1>();

            //config_major_kind
            services.AddTransient<Iconfig_major_kindBLL, config_major_kindBLL1>();
            services.AddTransient<Iconfig_major_kindDAO, config_major_kindDAO1>();

            //users
            services.AddTransient<IuserBLL, usersBLL1>();
            services.AddTransient<IusersDAO, usersDAO1>();

            //salary_standard
            services.AddTransient<Isalary_standardBLL, salary_standardBLL1>();
            services.AddTransient<Isalary_standardDAO, salary_standardDAO1>();

            //salary_standard_details
            services.AddTransient<Isalary_standard_detailsBLL, salary_standard_detailsBLL>();
            services.AddTransient<Isalary_standard_detailsDAO, salary_standard_detailsDAO>();
           
            //salary_grant
            services.AddTransient<Isalary_grantBLL, salary_grantBLL>();
            services.AddTransient<Isalary_grantDAO, salary_grantDAO>();

            //human_file
            services.AddTransient<Ihuman_fileBLL, human_fileBLL>();
            services.AddTransient<Ihuman_fileDAO, human_fileDAO1>();

            services.AddControllersWithViews();
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
            app.UseSession();

            //3
            app.UseRouting();
            //4
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name: "default",
                   pattern: "{controller=Users}/{action=login}/{id?}");
                    //pattern: "{controller=Users}/{action=index}/{id?}");
            });

            //1->2->3->4进
            //出4->3->2->1
        }
    }
}
