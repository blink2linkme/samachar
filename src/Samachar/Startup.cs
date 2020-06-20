using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Samachar.Data.SqlServer;
using Samachar.Repository;
using Samachar.Service;

namespace Samachar
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
            //PostgreSQLs
            //services.AddEntityFrameworkNpgsql().AddDbContext<SamacharDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));
            services.AddDbContext<SamacharDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // PostgreSQL
            services.AddControllersWithViews();

            services.AddScoped(p => p.GetService<SamacharDbContext>());

            // Repository Registration
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            // Service Registration
            services.AddTransient<IUtilityService, UtilityService>();
            services.AddTransient<ICategoryService, CategoryService>();
 

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
