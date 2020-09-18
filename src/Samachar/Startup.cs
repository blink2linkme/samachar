using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Samachar.Core.Extensions;
using Samachar.Core.Helper;
using Samachar.Data.MSSQL;
using Samachar.Domain;
using Samachar.Domain.User;
using Samachar.Repository;
using Samachar.Service;
using System;

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

            services.AddDbContext<SamacharDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<SamacharDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsPrincipalFactory>();
            services.Configure<IdentityOptions>(options =>
            {
                // Password
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout Settings
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.AllowedForNewUsers = true;

                //User
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                //options.Cookie.Expiration = TimeSpan.FromDays(180);
                options.ExpireTimeSpan = TimeSpan.FromDays(180);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            //PostgreSQLs
            //services.AddEntityFrameworkNpgsql().AddDbContext<SamacharDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));
            //services.AddDbContext<SamacharDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // PostgreSQL
            services.AddControllersWithViews();

            // Helper Registration
            services.AddTransient<IFileHelper, FileHelper>();

            // Repository Registration
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleTagsRepository, ArticleTagsRepository>();

            // Service Registration
            services.AddTransient<IUtilityService, UtilityService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IArticleTagsService, ArticleTagsService>();
            services.AddTransient<IEmailHelper, EmailHelper>();

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
