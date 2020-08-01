using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scm.Domain;
using Scm.Infra.CrossCutting.DTOs;
using Scm.Infra.Data;
using Scm.Infra.Data.Interface;
using Scm.Service;
using Scm.Service.Interface;
using SCM_API.Models.Student;
using Smc.Infra.Data;
using Smc.Infra.Data.Interface;

namespace SCM
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
            services.AddControllersWithViews();

            var mapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<SearchStudentDto, SearchStudentViewModel>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            
            services.AddSingleton(mapper);

            services.AddDbContext<ScmDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSection("ConnectionsStrings:SCM_Dev_ConnectionString").Value);                
            });

            services.AddScoped<ScmDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Student}/{action=Index}/{id?}");
            });
        }
    }
}
