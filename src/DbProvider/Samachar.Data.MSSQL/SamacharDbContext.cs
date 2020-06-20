using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Samachar.Data.MSSQL.Configuration;
using Samachar.Domain;

namespace Samachar.Data.MSSQL
{
    public class SamacharDbContext : IdentityDbContext<ApplicationUser>
    {
        public SamacharDbContext(DbContextOptions<SamacharDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleContentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        }

        public virtual DbSet<ApplicationUser> User { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleContent> ArticleContents { get; set; }
    }
}
