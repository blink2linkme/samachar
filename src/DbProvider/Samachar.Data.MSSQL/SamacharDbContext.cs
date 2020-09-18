using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Samachar.Data.MSSQL.Configuration;
using Samachar.Domain;
using Samachar.Domain.User;

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
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleContentConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleTagsConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        public virtual DbSet<ApplicationUser> User { get; set; }
        public virtual DbSet<ApplicationRole> Role { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleContent> ArticleContents { get; set; }
        public virtual DbSet<ArticleTags> ArticleTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}
