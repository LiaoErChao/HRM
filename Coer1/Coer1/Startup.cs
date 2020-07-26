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

           

            //Ioc����

            services.AddDistributedMemoryCache().AddSession();


            //����������ע���ࣺע����һ��ITestDAO,��ITestDAOʵ��
            //config_file_first_kind
            services.AddTransient<Iconfig_file_first_kindBLL1, config_file_first_kindBLL1>();
            services.AddTransient<Iconfig_file_first_kindDAO1, config_file_first_kindDAO1>();
           
            //config_file_second_kind
            services.AddTransient<Iconfig_file_second_kindDAO1, config_file_second_kindDAO1>();
            services.AddTransient<Iconfig_file_second_kindBLL1, config_file_second_kindBLL1>();

            //config_file_third_kind
            services.AddTransient<Iconfig_file_third_kindBLL1, config_file_third_kindBLL1>();
            services.AddTransient<Iconfig_file_third_kindDAO1, config_file_third_kindDAO1>();

            //config_public_char
            services.AddTransient<Iconfig_public_charBLL1, config_public_charBLL1>();
            services.AddTransient<Iconfig_public_charDAO1, config_public_charDAO1>();

            //config_majorb
            services.AddTransient<Iconfig_majorbBLL1, config_majorBLL1>();
            services.AddTransient<Iconfig_majorDAO1, config_majorDAO1>();

            //config_major_kind
            services.AddTransient<Iconfig_major_kindBLL1, config_major_kindBLL1>();
            services.AddTransient<Iconfig_major_kindDAO1, config_major_kindDAO1>();
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache().AddSession();


            //��ȡ�����ַ���
            var conStr = configuration.GetConnectionString("SqlServerConnection");
           services.AddDbContext<TescDbContext1>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //1
            if (env.IsDevelopment())
            {//Ioc����
             //services
             //����������ע���ࣺע����һ��ITestDAO,��ITestDAOʵ��
             //services.AddTransient<ITestDAO, TestDAO>();
             //services.AddControllersWithViews();
             //��ȡ�����ַ���
                var conStr = configuration.GetConnectionString("SqlServerConnection");
                //services.AddDbContext<TestDbContext>();
                app.UseDeveloperExceptionPage();
            }
            //2
            app.UseStaticFiles();//���ؾ�̬�ļ������
            app.UseSession();

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
                    pattern: "{controller=Major_Kind}/{action=major_kind}/{id?}");
            });

            //1->2->3->4��
            //��4->3->2->1
        }
    }
}
